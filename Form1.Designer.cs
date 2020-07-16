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
            this.components = new System.ComponentModel.Container();
            this.Lbl_InstallPath = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Lbl_AEInstallPath = new System.Windows.Forms.Label();
            this.Btn_SetLanguage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_CurrentLanguage = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_InstallPath
            // 
            this.Lbl_InstallPath.AutoSize = true;
            this.Lbl_InstallPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_InstallPath.Location = new System.Drawing.Point(3, 8);
            this.Lbl_InstallPath.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.Lbl_InstallPath.Name = "Lbl_InstallPath";
            this.Lbl_InstallPath.Size = new System.Drawing.Size(143, 27);
            this.Lbl_InstallPath.TabIndex = 0;
            this.Lbl_InstallPath.Text = "AE 安装路径：";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.Lbl_InstallPath);
            this.flowLayoutPanel1.Controls.Add(this.Lbl_AEInstallPath);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(543, 90);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // Lbl_AEInstallPath
            // 
            this.Lbl_AEInstallPath.AutoSize = true;
            this.Lbl_AEInstallPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_AEInstallPath.Location = new System.Drawing.Point(3, 43);
            this.Lbl_AEInstallPath.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.Lbl_AEInstallPath.Name = "Lbl_AEInstallPath";
            this.Lbl_AEInstallPath.Size = new System.Drawing.Size(0, 20);
            this.Lbl_AEInstallPath.TabIndex = 0;
            this.Lbl_AEInstallPath.TextChanged += new System.EventHandler(this.Lbl_AEInstallPath_TextChanged);
            this.Lbl_AEInstallPath.Click += new System.EventHandler(this.Btn_BrowseFolder_Click);
            // 
            // Btn_SetLanguage
            // 
            this.Btn_SetLanguage.BackColor = System.Drawing.Color.Crimson;
            this.Btn_SetLanguage.FlatAppearance.BorderSize = 0;
            this.Btn_SetLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_SetLanguage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_SetLanguage.ForeColor = System.Drawing.Color.White;
            this.Btn_SetLanguage.Location = new System.Drawing.Point(176, 174);
            this.Btn_SetLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_SetLanguage.Name = "Btn_SetLanguage";
            this.Btn_SetLanguage.Size = new System.Drawing.Size(176, 60);
            this.Btn_SetLanguage.TabIndex = 4;
            this.Btn_SetLanguage.Text = "切换语言";
            this.toolTip1.SetToolTip(this.Btn_SetLanguage, "按住 Ctrl 键单击以启动 AE");
            this.Btn_SetLanguage.UseVisualStyleBackColor = false;
            this.Btn_SetLanguage.Click += new System.EventHandler(this.Btn_SetLanguage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前语言：";
            // 
            // Lbl_CurrentLanguage
            // 
            this.Lbl_CurrentLanguage.AutoSize = true;
            this.Lbl_CurrentLanguage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lbl_CurrentLanguage.ForeColor = System.Drawing.Color.MediumBlue;
            this.Lbl_CurrentLanguage.Location = new System.Drawing.Point(122, 104);
            this.Lbl_CurrentLanguage.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.Lbl_CurrentLanguage.Name = "Lbl_CurrentLanguage";
            this.Lbl_CurrentLanguage.Size = new System.Drawing.Size(0, 27);
            this.Lbl_CurrentLanguage.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 254);
            this.Controls.Add(this.Lbl_CurrentLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_SetLanguage);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Btn_SetLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lbl_AEInstallPath;
        private System.Windows.Forms.Label Lbl_CurrentLanguage;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

