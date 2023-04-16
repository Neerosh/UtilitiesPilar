namespace UtilitiesPilar
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gbSqlAnywhere = new System.Windows.Forms.GroupBox();
            this.lbStatusSqlAnywhere = new System.Windows.Forms.Label();
            this.btStartSqlAnywhere = new System.Windows.Forms.Button();
            this.btSelectFileSqlAnywhere = new System.Windows.Forms.Button();
            this.lbFilePathSqlAnywhere = new System.Windows.Forms.Label();
            this.txtFilePathSqlAnywhere = new System.Windows.Forms.TextBox();
            this.lbDescriptionSqlAnywhere = new System.Windows.Forms.Label();
            this.txtDescriptionSqlAnywhere = new System.Windows.Forms.TextBox();
            this.gbTTDS = new System.Windows.Forms.GroupBox();
            this.lbStatusTTDS = new System.Windows.Forms.Label();
            this.btStartTTDS = new System.Windows.Forms.Button();
            this.btSelectFileTTDS = new System.Windows.Forms.Button();
            this.lbFilePathTTDS = new System.Windows.Forms.Label();
            this.txtFilePathTTDS = new System.Windows.Forms.TextBox();
            this.lbDescriptionTTDS = new System.Windows.Forms.Label();
            this.txtDescriptionTTDS = new System.Windows.Forms.TextBox();
            this.lbProcessIdTTDS = new System.Windows.Forms.Label();
            this.lbProcessIdSqlAnywhere = new System.Windows.Forms.Label();
            this.btUpdateDatabase = new System.Windows.Forms.Button();
            this.lbProcessStatusIdTTDS = new System.Windows.Forms.Label();
            this.lbProcessStatusTTDS = new System.Windows.Forms.Label();
            this.lbProcessStatusIdSqlAnywhere = new System.Windows.Forms.Label();
            this.lbProcessStatusSqlAnywhere = new System.Windows.Forms.Label();
            this.tlPanel.SuspendLayout();
            this.gbSqlAnywhere.SuspendLayout();
            this.gbTTDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlPanel
            // 
            this.tlPanel.ColumnCount = 3;
            this.tlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.Controls.Add(this.gbSqlAnywhere, 1, 2);
            this.tlPanel.Controls.Add(this.gbTTDS, 1, 1);
            this.tlPanel.Controls.Add(this.btUpdateDatabase, 1, 3);
            this.tlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPanel.Location = new System.Drawing.Point(0, 0);
            this.tlPanel.Name = "tlPanel";
            this.tlPanel.RowCount = 5;
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.Size = new System.Drawing.Size(684, 461);
            this.tlPanel.TabIndex = 0;
            // 
            // gbSqlAnywhere
            // 
            this.gbSqlAnywhere.Controls.Add(this.lbProcessStatusIdSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.lbProcessStatusSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.lbProcessIdSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.lbStatusSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.btStartSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.btSelectFileSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.lbFilePathSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.txtFilePathSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.lbDescriptionSqlAnywhere);
            this.gbSqlAnywhere.Controls.Add(this.txtDescriptionSqlAnywhere);
            this.gbSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gbSqlAnywhere.ForeColor = System.Drawing.Color.White;
            this.gbSqlAnywhere.Location = new System.Drawing.Point(92, 212);
            this.gbSqlAnywhere.Name = "gbSqlAnywhere";
            this.gbSqlAnywhere.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.gbSqlAnywhere.Size = new System.Drawing.Size(500, 140);
            this.gbSqlAnywhere.TabIndex = 8;
            this.gbSqlAnywhere.TabStop = false;
            this.gbSqlAnywhere.Text = "SQL Anywhere";
            // 
            // lbStatusSqlAnywhere
            // 
            this.lbStatusSqlAnywhere.AutoSize = true;
            this.lbStatusSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbStatusSqlAnywhere.Location = new System.Drawing.Point(225, 89);
            this.lbStatusSqlAnywhere.Name = "lbStatusSqlAnywhere";
            this.lbStatusSqlAnywhere.Size = new System.Drawing.Size(59, 17);
            this.lbStatusSqlAnywhere.TabIndex = 7;
            this.lbStatusSqlAnywhere.Text = "Example";
            this.lbStatusSqlAnywhere.Visible = false;
            // 
            // btStartSqlAnywhere
            // 
            this.btStartSqlAnywhere.BackColor = System.Drawing.Color.DimGray;
            this.btStartSqlAnywhere.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btStartSqlAnywhere.FlatAppearance.BorderSize = 2;
            this.btStartSqlAnywhere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btStartSqlAnywhere.ForeColor = System.Drawing.Color.White;
            this.btStartSqlAnywhere.Location = new System.Drawing.Point(12, 89);
            this.btStartSqlAnywhere.Name = "btStartSqlAnywhere";
            this.btStartSqlAnywhere.Size = new System.Drawing.Size(137, 36);
            this.btStartSqlAnywhere.TabIndex = 6;
            this.btStartSqlAnywhere.Text = "Start SQL Anywhere";
            this.btStartSqlAnywhere.UseVisualStyleBackColor = false;
            this.btStartSqlAnywhere.Click += new System.EventHandler(this.btStartSqlAnywhere_Click);
            // 
            // btSelectFileSqlAnywhere
            // 
            this.btSelectFileSqlAnywhere.BackColor = System.Drawing.Color.DimGray;
            this.btSelectFileSqlAnywhere.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btSelectFileSqlAnywhere.FlatAppearance.BorderSize = 2;
            this.btSelectFileSqlAnywhere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSelectFileSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btSelectFileSqlAnywhere.ForeColor = System.Drawing.Color.White;
            this.btSelectFileSqlAnywhere.Location = new System.Drawing.Point(459, 20);
            this.btSelectFileSqlAnywhere.Name = "btSelectFileSqlAnywhere";
            this.btSelectFileSqlAnywhere.Size = new System.Drawing.Size(32, 29);
            this.btSelectFileSqlAnywhere.TabIndex = 5;
            this.btSelectFileSqlAnywhere.Text = "...";
            this.btSelectFileSqlAnywhere.UseVisualStyleBackColor = false;
            this.btSelectFileSqlAnywhere.Click += new System.EventHandler(this.btSelectFileSqlAnywhere_Click);
            // 
            // lbFilePathSqlAnywhere
            // 
            this.lbFilePathSqlAnywhere.AutoSize = true;
            this.lbFilePathSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbFilePathSqlAnywhere.Location = new System.Drawing.Point(9, 27);
            this.lbFilePathSqlAnywhere.Name = "lbFilePathSqlAnywhere";
            this.lbFilePathSqlAnywhere.Size = new System.Drawing.Size(52, 15);
            this.lbFilePathSqlAnywhere.TabIndex = 3;
            this.lbFilePathSqlAnywhere.Text = "FilePath:";
            // 
            // txtFilePathSqlAnywhere
            // 
            this.txtFilePathSqlAnywhere.Location = new System.Drawing.Point(86, 22);
            this.txtFilePathSqlAnywhere.Name = "txtFilePathSqlAnywhere";
            this.txtFilePathSqlAnywhere.Size = new System.Drawing.Size(367, 25);
            this.txtFilePathSqlAnywhere.TabIndex = 2;
            // 
            // lbDescriptionSqlAnywhere
            // 
            this.lbDescriptionSqlAnywhere.AutoSize = true;
            this.lbDescriptionSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbDescriptionSqlAnywhere.Location = new System.Drawing.Point(9, 57);
            this.lbDescriptionSqlAnywhere.Name = "lbDescriptionSqlAnywhere";
            this.lbDescriptionSqlAnywhere.Size = new System.Drawing.Size(71, 15);
            this.lbDescriptionSqlAnywhere.TabIndex = 1;
            this.lbDescriptionSqlAnywhere.Text = "Description:";
            // 
            // txtDescriptionSqlAnywhere
            // 
            this.txtDescriptionSqlAnywhere.Location = new System.Drawing.Point(86, 54);
            this.txtDescriptionSqlAnywhere.Name = "txtDescriptionSqlAnywhere";
            this.txtDescriptionSqlAnywhere.Size = new System.Drawing.Size(405, 25);
            this.txtDescriptionSqlAnywhere.TabIndex = 0;
            // 
            // gbTTDS
            // 
            this.gbTTDS.Controls.Add(this.lbProcessStatusIdTTDS);
            this.gbTTDS.Controls.Add(this.lbProcessStatusTTDS);
            this.gbTTDS.Controls.Add(this.lbProcessIdTTDS);
            this.gbTTDS.Controls.Add(this.lbStatusTTDS);
            this.gbTTDS.Controls.Add(this.btStartTTDS);
            this.gbTTDS.Controls.Add(this.btSelectFileTTDS);
            this.gbTTDS.Controls.Add(this.lbFilePathTTDS);
            this.gbTTDS.Controls.Add(this.txtFilePathTTDS);
            this.gbTTDS.Controls.Add(this.lbDescriptionTTDS);
            this.gbTTDS.Controls.Add(this.txtDescriptionTTDS);
            this.gbTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gbTTDS.ForeColor = System.Drawing.Color.White;
            this.gbTTDS.Location = new System.Drawing.Point(92, 66);
            this.gbTTDS.Name = "gbTTDS";
            this.gbTTDS.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.gbTTDS.Size = new System.Drawing.Size(500, 140);
            this.gbTTDS.TabIndex = 0;
            this.gbTTDS.TabStop = false;
            this.gbTTDS.Text = "TTDS";
            // 
            // lbStatusTTDS
            // 
            this.lbStatusTTDS.AutoSize = true;
            this.lbStatusTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbStatusTTDS.ForeColor = System.Drawing.Color.White;
            this.lbStatusTTDS.Location = new System.Drawing.Point(225, 89);
            this.lbStatusTTDS.Name = "lbStatusTTDS";
            this.lbStatusTTDS.Size = new System.Drawing.Size(59, 17);
            this.lbStatusTTDS.TabIndex = 7;
            this.lbStatusTTDS.Text = "Example";
            this.lbStatusTTDS.Visible = false;
            // 
            // btStartTTDS
            // 
            this.btStartTTDS.BackColor = System.Drawing.Color.DimGray;
            this.btStartTTDS.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btStartTTDS.FlatAppearance.BorderSize = 2;
            this.btStartTTDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btStartTTDS.ForeColor = System.Drawing.Color.White;
            this.btStartTTDS.Location = new System.Drawing.Point(12, 89);
            this.btStartTTDS.Name = "btStartTTDS";
            this.btStartTTDS.Size = new System.Drawing.Size(137, 36);
            this.btStartTTDS.TabIndex = 6;
            this.btStartTTDS.Text = "Start TTDS";
            this.btStartTTDS.UseVisualStyleBackColor = false;
            this.btStartTTDS.Click += new System.EventHandler(this.btStartTTDS_Click);
            // 
            // btSelectFileTTDS
            // 
            this.btSelectFileTTDS.BackColor = System.Drawing.Color.DimGray;
            this.btSelectFileTTDS.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btSelectFileTTDS.FlatAppearance.BorderSize = 2;
            this.btSelectFileTTDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSelectFileTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btSelectFileTTDS.ForeColor = System.Drawing.Color.White;
            this.btSelectFileTTDS.Location = new System.Drawing.Point(459, 20);
            this.btSelectFileTTDS.Name = "btSelectFileTTDS";
            this.btSelectFileTTDS.Size = new System.Drawing.Size(32, 29);
            this.btSelectFileTTDS.TabIndex = 5;
            this.btSelectFileTTDS.Text = "...";
            this.btSelectFileTTDS.UseVisualStyleBackColor = false;
            this.btSelectFileTTDS.Click += new System.EventHandler(this.btSelectFileTTDS_Click);
            // 
            // lbFilePathTTDS
            // 
            this.lbFilePathTTDS.AutoSize = true;
            this.lbFilePathTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbFilePathTTDS.Location = new System.Drawing.Point(9, 27);
            this.lbFilePathTTDS.Name = "lbFilePathTTDS";
            this.lbFilePathTTDS.Size = new System.Drawing.Size(52, 15);
            this.lbFilePathTTDS.TabIndex = 3;
            this.lbFilePathTTDS.Text = "FilePath:";
            // 
            // txtFilePathTTDS
            // 
            this.txtFilePathTTDS.Location = new System.Drawing.Point(86, 22);
            this.txtFilePathTTDS.Name = "txtFilePathTTDS";
            this.txtFilePathTTDS.Size = new System.Drawing.Size(367, 25);
            this.txtFilePathTTDS.TabIndex = 2;
            // 
            // lbDescriptionTTDS
            // 
            this.lbDescriptionTTDS.AutoSize = true;
            this.lbDescriptionTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbDescriptionTTDS.Location = new System.Drawing.Point(9, 57);
            this.lbDescriptionTTDS.Name = "lbDescriptionTTDS";
            this.lbDescriptionTTDS.Size = new System.Drawing.Size(71, 15);
            this.lbDescriptionTTDS.TabIndex = 1;
            this.lbDescriptionTTDS.Text = "Description:";
            // 
            // txtDescriptionTTDS
            // 
            this.txtDescriptionTTDS.Location = new System.Drawing.Point(86, 54);
            this.txtDescriptionTTDS.Name = "txtDescriptionTTDS";
            this.txtDescriptionTTDS.Size = new System.Drawing.Size(405, 25);
            this.txtDescriptionTTDS.TabIndex = 0;
            // 
            // lbProcessIdTTDS
            // 
            this.lbProcessIdTTDS.AutoSize = true;
            this.lbProcessIdTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbProcessIdTTDS.Location = new System.Drawing.Point(225, 106);
            this.lbProcessIdTTDS.Name = "lbProcessIdTTDS";
            this.lbProcessIdTTDS.Size = new System.Drawing.Size(59, 17);
            this.lbProcessIdTTDS.TabIndex = 8;
            this.lbProcessIdTTDS.Text = "Example";
            this.lbProcessIdTTDS.Visible = false;
            // 
            // lbProcessIdSqlAnywhere
            // 
            this.lbProcessIdSqlAnywhere.AutoSize = true;
            this.lbProcessIdSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbProcessIdSqlAnywhere.Location = new System.Drawing.Point(225, 106);
            this.lbProcessIdSqlAnywhere.Name = "lbProcessIdSqlAnywhere";
            this.lbProcessIdSqlAnywhere.Size = new System.Drawing.Size(59, 17);
            this.lbProcessIdSqlAnywhere.TabIndex = 9;
            this.lbProcessIdSqlAnywhere.Text = "Example";
            this.lbProcessIdSqlAnywhere.Visible = false;
            // 
            // btUpdateDatabase
            // 
            this.btUpdateDatabase.BackColor = System.Drawing.Color.DimGray;
            this.btUpdateDatabase.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btUpdateDatabase.FlatAppearance.BorderSize = 2;
            this.btUpdateDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUpdateDatabase.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btUpdateDatabase.ForeColor = System.Drawing.Color.White;
            this.btUpdateDatabase.Location = new System.Drawing.Point(92, 358);
            this.btUpdateDatabase.Name = "btUpdateDatabase";
            this.btUpdateDatabase.Size = new System.Drawing.Size(119, 36);
            this.btUpdateDatabase.TabIndex = 9;
            this.btUpdateDatabase.Text = "Update Database";
            this.btUpdateDatabase.UseVisualStyleBackColor = false;
            this.btUpdateDatabase.Click += new System.EventHandler(this.btUpdateDatabase_Click);
            // 
            // lbProcessStatusIdTTDS
            // 
            this.lbProcessStatusIdTTDS.AutoSize = true;
            this.lbProcessStatusIdTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbProcessStatusIdTTDS.Location = new System.Drawing.Point(170, 106);
            this.lbProcessStatusIdTTDS.Name = "lbProcessStatusIdTTDS";
            this.lbProcessStatusIdTTDS.Size = new System.Drawing.Size(24, 17);
            this.lbProcessStatusIdTTDS.TabIndex = 10;
            this.lbProcessStatusIdTTDS.Text = "ID:";
            // 
            // lbProcessStatusTTDS
            // 
            this.lbProcessStatusTTDS.AutoSize = true;
            this.lbProcessStatusTTDS.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbProcessStatusTTDS.ForeColor = System.Drawing.Color.White;
            this.lbProcessStatusTTDS.Location = new System.Drawing.Point(170, 89);
            this.lbProcessStatusTTDS.Name = "lbProcessStatusTTDS";
            this.lbProcessStatusTTDS.Size = new System.Drawing.Size(49, 17);
            this.lbProcessStatusTTDS.TabIndex = 9;
            this.lbProcessStatusTTDS.Text = "Status:";
            // 
            // lbProcessStatusIdSqlAnywhere
            // 
            this.lbProcessStatusIdSqlAnywhere.AutoSize = true;
            this.lbProcessStatusIdSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbProcessStatusIdSqlAnywhere.Location = new System.Drawing.Point(170, 106);
            this.lbProcessStatusIdSqlAnywhere.Name = "lbProcessStatusIdSqlAnywhere";
            this.lbProcessStatusIdSqlAnywhere.Size = new System.Drawing.Size(24, 17);
            this.lbProcessStatusIdSqlAnywhere.TabIndex = 11;
            this.lbProcessStatusIdSqlAnywhere.Text = "ID:";
            // 
            // lbProcessStatusSqlAnywhere
            // 
            this.lbProcessStatusSqlAnywhere.AutoSize = true;
            this.lbProcessStatusSqlAnywhere.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbProcessStatusSqlAnywhere.Location = new System.Drawing.Point(170, 89);
            this.lbProcessStatusSqlAnywhere.Name = "lbProcessStatusSqlAnywhere";
            this.lbProcessStatusSqlAnywhere.Size = new System.Drawing.Size(49, 17);
            this.lbProcessStatusSqlAnywhere.TabIndex = 10;
            this.lbProcessStatusSqlAnywhere.Text = "Status:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.tlPanel);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilities PILAR";
            this.tlPanel.ResumeLayout(false);
            this.gbSqlAnywhere.ResumeLayout(false);
            this.gbSqlAnywhere.PerformLayout();
            this.gbTTDS.ResumeLayout(false);
            this.gbTTDS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlPanel;
        private System.Windows.Forms.GroupBox gbTTDS;
        private System.Windows.Forms.Label lbStatusTTDS;
        private System.Windows.Forms.Button btStartTTDS;
        private System.Windows.Forms.Button btSelectFileTTDS;
        private System.Windows.Forms.Label lbFilePathTTDS;
        private System.Windows.Forms.TextBox txtFilePathTTDS;
        private System.Windows.Forms.Label lbDescriptionTTDS;
        private System.Windows.Forms.TextBox txtDescriptionTTDS;
        private System.Windows.Forms.GroupBox gbSqlAnywhere;
        private System.Windows.Forms.Label lbStatusSqlAnywhere;
        private System.Windows.Forms.Button btStartSqlAnywhere;
        private System.Windows.Forms.Button btSelectFileSqlAnywhere;
        private System.Windows.Forms.Label lbFilePathSqlAnywhere;
        private System.Windows.Forms.TextBox txtFilePathSqlAnywhere;
        private System.Windows.Forms.Label lbDescriptionSqlAnywhere;
        private System.Windows.Forms.TextBox txtDescriptionSqlAnywhere;
        private System.Windows.Forms.Label lbProcessIdSqlAnywhere;
        private System.Windows.Forms.Label lbProcessIdTTDS;
        private System.Windows.Forms.Button btUpdateDatabase;
        private System.Windows.Forms.Label lbProcessStatusIdSqlAnywhere;
        private System.Windows.Forms.Label lbProcessStatusSqlAnywhere;
        private System.Windows.Forms.Label lbProcessStatusIdTTDS;
        private System.Windows.Forms.Label lbProcessStatusTTDS;
    }
}

