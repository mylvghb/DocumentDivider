namespace DocumentDivider
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
            this.lblDocPath = new System.Windows.Forms.Label();
            this.lblSaveDir = new System.Windows.Forms.Label();
            this.txtDocPath = new System.Windows.Forms.TextBox();
            this.txtSaveDir = new System.Windows.Forms.TextBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDocPath
            // 
            this.lblDocPath.Location = new System.Drawing.Point(12, 26);
            this.lblDocPath.Name = "lblDocPath";
            this.lblDocPath.Size = new System.Drawing.Size(66, 18);
            this.lblDocPath.TabIndex = 0;
            this.lblDocPath.Text = "文档路径：";
            // 
            // lblSaveDir
            // 
            this.lblSaveDir.Location = new System.Drawing.Point(12, 59);
            this.lblSaveDir.Name = "lblSaveDir";
            this.lblSaveDir.Size = new System.Drawing.Size(66, 18);
            this.lblSaveDir.TabIndex = 1;
            this.lblSaveDir.Text = "保存目录：";
            // 
            // txtDocPath
            // 
            this.txtDocPath.Location = new System.Drawing.Point(75, 23);
            this.txtDocPath.Name = "txtDocPath";
            this.txtDocPath.Size = new System.Drawing.Size(281, 21);
            this.txtDocPath.TabIndex = 2;
            this.txtDocPath.Click += new System.EventHandler(this.txtDocPath_Click);
            // 
            // txtSaveDir
            // 
            this.txtSaveDir.Location = new System.Drawing.Point(75, 56);
            this.txtSaveDir.Name = "txtSaveDir";
            this.txtSaveDir.Size = new System.Drawing.Size(281, 21);
            this.txtSaveDir.TabIndex = 3;
            this.txtSaveDir.Click += new System.EventHandler(this.txtSaveDir_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(184, 106);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 4;
            this.btnSplit.Text = "分割";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(279, 106);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Word 文档（*.doc,*.docx）|*.doc;*.docx";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "请选择保存分割后的文件夹";
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(75, 89);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(281, 17);
            this.lblMessage.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 141);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.txtSaveDir);
            this.Controls.Add(this.txtDocPath);
            this.Controls.Add(this.lblSaveDir);
            this.Controls.Add(this.lblDocPath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文档分割器";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMessage;

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

        private System.Windows.Forms.OpenFileDialog openFileDialog;

        private System.Windows.Forms.Label lblDocPath;
        private System.Windows.Forms.Label lblSaveDir;
        private System.Windows.Forms.TextBox txtDocPath;
        private System.Windows.Forms.TextBox txtSaveDir;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnQuit;

        #endregion
    }
}