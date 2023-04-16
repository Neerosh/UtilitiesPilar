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
        private Process processTTDS;
        private Process processSqlAnywhere;
        private Tool toolTTDS;
        private Tool toolSqlAnywhere;
        private Classes.Database database = new Classes.Database();

        public MainForm()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow() {
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

        private Process StartProcess(string filepath)
        {
            Process process = null;
            if (File.Exists(filepath))
            {
                process = Process.Start(filepath);
            }
            return process;
        }

        private bool KillProcess(Process process)
        {
            if (!process.HasExited)
                process.Kill();
            return process.HasExited;
        }

        private string CheckStatusProcess(Process process) 
        {
            string status = "Process Not Found";

            if (process.Id !=  0) 
            {
                if (process.HasExited)
                    status = "Process Terminated";
                if (!process.HasExited)
                    status = "Process Running";
            }

            return status;
        }

        private void VerifyProcessStatus()
        { 
            string statusTTDS;
            string statusSqlAnywhere;
            int status = 0;
            while (status == 0)
            {
                Thread.Sleep(3000);
                if (processTTDS != null)
                {
                    if (processTTDS.StartInfo.FileName != "")
                    {
                        statusTTDS = CheckStatusProcess(processTTDS);
                        if (statusTTDS != lbStatusTTDS.Text)
                        {
                            Invoke((new Action(() => {
                                DisplayProcessInfo(statusTTDS, "TTDS");
                            })));
                        }
                            

                    }
                }

                if (processSqlAnywhere != null)
                {
                    if (processSqlAnywhere.StartInfo.FileName != "")
                    {
                        statusSqlAnywhere = CheckStatusProcess(processSqlAnywhere);
                        if (statusSqlAnywhere != lbStatusSqlAnywhere.Text)
                        {
                            Invoke((new Action(() => {
                                DisplayProcessInfo(statusSqlAnywhere, "SQL Anywhere");
                            })));
                        }
                    }
                }
            }
        }

        private void DisplayProcessInfo(string status, string processName)
        {
            System.Windows.Forms.Label lbStatus = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lbProcessId = new System.Windows.Forms.Label();
            System.Windows.Forms.Button btProcess = new System.Windows.Forms.Button();

            Process process = null;

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
            lbProcessId.Text = process.Id.ToString();

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
            if (btStartTTDS.Text.Contains("Start"))
            {
                processTTDS = StartProcess(txtFilePathTTDS.Text);
                if (processTTDS != null)
                    btStartTTDS.Text = "Stop TTDS";
            }
            else
            {
                KillProcess(processTTDS);
                btStartTTDS.Text = "Start TTDS";
            }
        }

        private void btStartSqlAnywhere_Click(object sender, EventArgs e)
        {
            if (btStartSqlAnywhere.Text.Contains("Start"))
            {
                processSqlAnywhere = StartProcess(txtFilePathSqlAnywhere.Text);
                if (processSqlAnywhere != null)
                    btStartSqlAnywhere.Text = "Stop TTDS";
            }
            else
            {
                KillProcess(processSqlAnywhere);
                btStartSqlAnywhere.Text = "Start TTDS";
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
