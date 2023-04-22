using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitiesPilar.Classes;

namespace UtilitiesPilar
{
    public partial class MainForm : Form
    {
        private ProcessUtil processTTDS;
        private ProcessUtil processSqlAnywhere;
        private Tool toolTTDS;
        private Tool toolSqlAnywhere;
        private Classes.Database database = new Classes.Database();

        public MainForm()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow() {
            processTTDS = new ProcessUtil();
            processSqlAnywhere = new ProcessUtil();
            toolTTDS = database.SelectTool("TTDS");
            toolSqlAnywhere = database.SelectTool("SQL Anywhere");
            Task.Run(() => { VerifyProcessStatus(); });

            if (toolTTDS == null)
                toolTTDS = new Tool("TTDS");
            else
            { 
                txtDescriptionTTDS.Text = toolTTDS.Description;
                txtFilePathTTDS.Text = toolTTDS.FilePath;
            }

            if (toolSqlAnywhere == null)
                toolSqlAnywhere = new Tool("SQL Anywhere");
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

        }
    }
}
