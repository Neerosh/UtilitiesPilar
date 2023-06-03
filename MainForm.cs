using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitiesPilar.Classes;

namespace UtilitiesPilar
{
    public partial class MainForm : Form
    {
        private Tool toolTTDS;
        private Tool toolSqlAnywhere;
        private FileFilterSetting defaultFileFilterSetting;
        private ProcessUtil processTTDS = new ProcessUtil();
        private ProcessUtil processSqlAnywhere = new ProcessUtil();
        private Classes.Database database = new Classes.Database();
        public MainForm()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow() {
            BindingList<FileFilter> fileFiltersList = database.SelectAllFileFilters(null);

            cbFileFilter.DataSource = fileFiltersList;
            cbFileFilter.DisplayMember = "Name";
            cbFileFilter.ValueMember = "Id";

            toolTTDS = database.SelectTool("TTDS");
            toolSqlAnywhere = database.SelectTool("SQL Anywhere");
            defaultFileFilterSetting = database.SelectFileFilterSetting("Default");
            Task.Run(() => { VerifyProcessStatus(); });

            if (defaultFileFilterSetting == null)
                defaultFileFilterSetting = new FileFilterSetting(0, 0, "Default");
            else
            {
                txtFolderOrigin.Text = defaultFileFilterSetting.FolderOrigin;
                txtFolderOriginAux.Text = defaultFileFilterSetting.FolderOriginAux;
                txtSaveTo.Text = defaultFileFilterSetting.FolderDestination;
                txtZipFilename.Text = defaultFileFilterSetting.ZipFilename;
                cbFileFilter.SelectedValue = defaultFileFilterSetting.FileFilterId;
                chOverwriteFiles.Checked = defaultFileFilterSetting.OverwriteFiles;
                chZipFiles.Checked = defaultFileFilterSetting.ZipFiles;
            }

            if (toolTTDS == null)
                toolTTDS = new Tool(0,"TTDS");
            else
            { 
                txtDescriptionTTDS.Text = toolTTDS.Description;
                txtFilePathTTDS.Text = toolTTDS.FilePath;
            }

            if (toolSqlAnywhere == null)
                toolSqlAnywhere = new Tool(1,"SQL Anywhere");
            else
            { 
                txtDescriptionSqlAnywhere.Text = toolSqlAnywhere.Description;
                txtFilePathSqlAnywhere.Text = toolSqlAnywhere.FilePath;
            }
            btStartTTDS_Click(this, new EventArgs());
            btStartSqlAnywhere_Click(this, new EventArgs());
        }
        private string SelectFile()
        {
            string returnValue = "";

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Executable File(*.exe)|*.exe";

            if (fileDialog.ShowDialog(this) == DialogResult.OK)
                returnValue = fileDialog.FileName;

            return returnValue;
        }
        private string SelectFolder()
        {
            string returnValue = "";

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog(this) == DialogResult.OK)
                returnValue = folderDialog.SelectedPath;

            return returnValue;
        }
        private void VerifyProcessStatus()
        { 
            string statusTTDS;
            string statusSqlAnywhere;
            int status = 0;
            while (status == 0)
            {
                Thread.Sleep(3000);
                if (processTTDS.HasStarted())
                {
                    statusTTDS = processTTDS.CheckStatusProcess();
                    if (statusTTDS != lbStatusTTDS.Text)
                    {
                        Invoke((new Action(() => {
                            DisplayProcessInfo(statusTTDS, "TTDS");
                        })));
                    }
                          
                }

                if (processSqlAnywhere.HasStarted())
                {
                    statusSqlAnywhere = processSqlAnywhere.CheckStatusProcess();
                    if (statusSqlAnywhere != lbStatusSqlAnywhere.Text)
                    {
                        Invoke((new Action(() => {
                            DisplayProcessInfo(statusSqlAnywhere, "SQL Anywhere");
                        })));
                    }
                }
            }
        }
        private void DisplayProcessInfo(string status, string processName)
        {
            System.Windows.Forms.Label lbStatus = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lbProcessId = new System.Windows.Forms.Label();
            System.Windows.Forms.Button btProcess = new System.Windows.Forms.Button();

            ProcessUtil process = null;

            switch (processName)
            {
                case "SQL Anywhere":
                    lbStatus = lbStatusSqlAnywhere;
                    lbProcessId = lbProcessIdSqlAnywhere;
                    process = processSqlAnywhere;
                    btProcess = btStartSqlAnywhere;
                    break;
                case "TTDS":
                    lbStatus = lbStatusTTDS;
                    lbProcessId = lbProcessIdTTDS;
                    process = processTTDS;
                    btProcess = btStartTTDS;
                    break;
            }

            lbStatus.Text = status;
            lbProcessId.Text = process.GetProcessId().ToString();

            if (lbStatus.Text.Contains("Terminated"))
            {
                lbStatus.ForeColor = Color.Yellow;
                lbProcessId.Text = "";
                btProcess.Text = btProcess.Text.Replace("Stop", "Start");
            }
            else
            { 
                lbStatus.ForeColor = Color.Lime;
            }

            lbStatus.Visible = true;
            lbProcessId.Visible = true;

        }
        private void btSelectFileTTDS_Click(object sender, EventArgs e)
        {
            string filepath = SelectFile();
            if (filepath != "")
                txtFilePathTTDS.Text = filepath;
        }

        private void btSelectFileSqlAnywhere_Click(object sender, EventArgs e)
        {
            string filepath = SelectFile();
            if (filepath != "")
                txtFilePathSqlAnywhere.Text = filepath;
        }

        private void btStartTTDS_Click(object sender, EventArgs e)
        {
            if (btStartTTDS.Text.Contains("Start") && File.Exists(txtFilePathTTDS.Text))
            {
                processTTDS.StartProcess(txtFilePathTTDS.Text);
                if (processTTDS.HasStarted())
                    btStartTTDS.Text = btStartTTDS.Text.Replace("Start", "Stop");
            }
            else
            {
                processTTDS.KillProcess();
                btStartTTDS.Text = btStartTTDS.Text.Replace("Stop", "Start");
            }
        }

        private void btStartSqlAnywhere_Click(object sender, EventArgs e)
        {
            if (btStartSqlAnywhere.Text.Contains("Start") && File.Exists(txtFilePathSqlAnywhere.Text))
            {
                processSqlAnywhere.StartProcess(txtFilePathSqlAnywhere.Text);
                if (processSqlAnywhere.HasStarted())
                    btStartSqlAnywhere.Text = btStartSqlAnywhere.Text.Replace("Start", "Stop");
            }
            else
            {
                processSqlAnywhere.KillProcess();
                btStartSqlAnywhere.Text = btStartSqlAnywhere.Text.Replace("Stop", "Start");
            }
        }

        private void btUpdateDatabase_Click(object sender, EventArgs e)
        {
            if (toolTTDS != null)
            {
                toolTTDS.Description = txtDescriptionTTDS.Text;
                toolTTDS.FilePath = txtFilePathTTDS.Text;
                database.UpdateTool(toolTTDS);
            }

            if (toolSqlAnywhere != null)
            {
                toolSqlAnywhere.Description = txtDescriptionSqlAnywhere.Text;
                toolSqlAnywhere.FilePath = txtFilePathSqlAnywhere.Text;
                database.UpdateTool(toolSqlAnywhere);
            }

            if (defaultFileFilterSetting != null)
            {
                defaultFileFilterSetting = new FileFilterSetting(0, (Int32)cbFileFilter.SelectedValue, "Default",
                    txtFolderOrigin.Text, txtSaveTo.Text, txtZipFilename.Text, chZipFiles.Checked, chOverwriteFiles.Checked, txtFolderOriginAux.Text);
                database.UpdateFileFilterSetting(defaultFileFilterSetting);
            }
            MessageBox.Show("Database Updated Successfully.","Database Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btSelectFolderOrigin_Click(object sender, EventArgs e)
        {
            string folderPath = SelectFolder();
            if (folderPath != "")
                txtFolderOrigin.Text = folderPath;
        }

        private void btSelectFolderOriginAux_Click(object sender, EventArgs e)
        {
            string folderPath = SelectFolder();
            if (folderPath != "")
                txtFolderOriginAux.Text = folderPath;
        }

        private void btSelectFolderSaveTo_Click(object sender, EventArgs e)
        {
            string folderPath = SelectFolder();
            if (folderPath != "")
                txtSaveTo.Text = folderPath;
        }

        private void btFilterFiles_Click(object sender, EventArgs e)
        {
            FileFilterService.FilterFiles(defaultFileFilterSetting, this);
        }
    }
}
