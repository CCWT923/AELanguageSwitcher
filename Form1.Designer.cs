namespace AELanguageSwitcher
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_InstallPath = new System.Windows.Forms.Label();
            this.TextBox_AEInstallPath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_BrowseFolder = new System.Windows.Forms.Button();
            this.ComboBox_LanguageList = new System.Windows.Forms.ComboBox();
            this.Btn_SetLanguage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBox_LaunchApp = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_InstallPath
            // 
            this.Lbl_InstallPath.AutoSize = true;
            this.Lbl_InstallPath.Location = new System.Drawing.Point(3, 8);
            this.Lbl_InstallPath.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.Lbl_InstallPath.Name = "Lbl_InstallPath";
            this.Lbl_InstallPath.Size = new System.Drawing.Size(91, 15);
            this.Lbl_InstallPath.TabIndex = 0;
            this.Lbl_InstallPath.Text = "AE 安装路径";
            // 
            // TextBox_AEInstallPath
            // 
            this.TextBox_AEInstallPath.Location = new System.Drawing.Point(100, 3);
            this.TextBox_AEInstallPath.Name = "TextBox_AEInstallPath";
            this.TextBox_AEInstallPath.Size = new System.Drawing.Size(276, 25);
            this.TextBox_AEInstallPath.TabIndex = 1;
            this.TextBox_AEInstallPath.TextChanged += new System.EventHandler(this.TextBox_AEInstallPath_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.Lbl_InstallPath);
            this.flowLayoutPanel1.Controls.Add(this.TextBox_AEInstallPath);
            this.flowLayoutPanel1.Controls.Add(this.Btn_BrowseFolder);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(500, 42);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // Btn_BrowseFolder
            // 
            this.Btn_BrowseFolder.Location = new System.Drawing.Point(382, 3);
            this.Btn_BrowseFolder.Name = "Btn_BrowseFolder";
            this.Btn_BrowseFolder.Size = new System.Drawing.Size(113, 29);
            this.Btn_BrowseFolder.TabIndex = 2;
            this.Btn_BrowseFolder.Text = "手动选择";
            this.Btn_BrowseFolder.UseVisualStyleBackColor = true;
            this.Btn_BrowseFolder.Click += new System.EventHandler(this.Btn_BrowseFolder_Click);
            // 
            // ComboBox_LanguageList
            // 
            this.ComboBox_LanguageList.FormattingEnabled = true;
            this.ComboBox_LanguageList.Items.AddRange(new object[] {
            "",
            "简体中文",
            "英语"});
            this.ComboBox_LanguageList.Location = new System.Drawing.Point(112, 60);
            this.ComboBox_LanguageList.Name = "ComboBox_LanguageList";
            this.ComboBox_LanguageList.Size = new System.Drawing.Size(121, 23);
            this.ComboBox_LanguageList.TabIndex = 3;
            // 
            // Btn_SetLanguage
            // 
            this.Btn_SetLanguage.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_SetLanguage.FlatAppearance.BorderSize = 0;
            this.Btn_SetLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_SetLanguage.ForeColor = System.Drawing.Color.White;
            this.Btn_SetLanguage.Location = new System.Drawing.Point(394, 116);
            this.Btn_SetLanguage.Name = "Btn_SetLanguage";
            this.Btn_SetLanguage.Size = new System.Drawing.Size(118, 39);
            this.Btn_SetLanguage.TabIndex = 4;
            this.Btn_SetLanguage.Text = "确定";
            this.Btn_SetLanguage.UseVisualStyleBackColor = false;
            this.Btn_SetLanguage.Click += new System.EventHandler(this.Btn_SetLanguage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择语言：";
            // 
            // CheckBox_LaunchApp
            // 
            this.CheckBox_LaunchApp.AutoSize = true;
            this.CheckBox_LaunchApp.Checked = true;
            this.CheckBox_LaunchApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_LaunchApp.Location = new System.Drawing.Point(265, 64);
            this.CheckBox_LaunchApp.Name = "CheckBox_LaunchApp";
            this.CheckBox_LaunchApp.Size = new System.Drawing.Size(75, 19);
            this.CheckBox_LaunchApp.TabIndex = 5;
            this.CheckBox_LaunchApp.Text = "启动AE";
            this.CheckBox_LaunchApp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 167);
            this.Controls.Add(this.CheckBox_LaunchApp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_SetLanguage);
            this.Controls.Add(this.ComboBox_LanguageList);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "AE 中英文切换工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_InstallPath;
        private System.Windows.Forms.TextBox TextBox_AEInstallPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Btn_BrowseFolder;
        private System.Windows.Forms.ComboBox ComboBox_LanguageList;
        private System.Windows.Forms.Button Btn_SetLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBox_LaunchApp;
    }
}

