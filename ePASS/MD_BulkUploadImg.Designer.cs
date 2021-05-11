
namespace ePASS
{
    partial class MD_BulkUploadImg
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
            this.ImageLayouts = new System.Windows.Forms.FlowLayoutPanel();
            this.SelecteFileButton = new System.Windows.Forms.Button();
            this.UploadFilesButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImageLayouts
            // 
            this.ImageLayouts.AutoScroll = true;
            this.ImageLayouts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImageLayouts.Location = new System.Drawing.Point(12, 12);
            this.ImageLayouts.Name = "ImageLayouts";
            this.ImageLayouts.Size = new System.Drawing.Size(594, 240);
            this.ImageLayouts.TabIndex = 0;
            // 
            // SelecteFileButton
            // 
            this.SelecteFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelecteFileButton.Location = new System.Drawing.Point(12, 258);
            this.SelecteFileButton.Name = "SelecteFileButton";
            this.SelecteFileButton.Size = new System.Drawing.Size(105, 43);
            this.SelecteFileButton.TabIndex = 1;
            this.SelecteFileButton.Text = "Select Files";
            this.SelecteFileButton.UseVisualStyleBackColor = true;
            this.SelecteFileButton.Click += new System.EventHandler(this.SelecteFileButton_Click);
            // 
            // UploadFilesButton
            // 
            this.UploadFilesButton.Enabled = false;
            this.UploadFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadFilesButton.Location = new System.Drawing.Point(123, 258);
            this.UploadFilesButton.Name = "UploadFilesButton";
            this.UploadFilesButton.Size = new System.Drawing.Size(105, 43);
            this.UploadFilesButton.TabIndex = 2;
            this.UploadFilesButton.Text = "Upload Files";
            this.UploadFilesButton.UseVisualStyleBackColor = true;
            this.UploadFilesButton.Click += new System.EventHandler(this.UploadFilesButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(501, 258);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(105, 43);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MD_BulkUploadImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(618, 312);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.UploadFilesButton);
            this.Controls.Add(this.SelecteFileButton);
            this.Controls.Add(this.ImageLayouts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MD_BulkUploadImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDK :: ImgUpload";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ImageLayouts;
        private System.Windows.Forms.Button SelecteFileButton;
        private System.Windows.Forms.Button UploadFilesButton;
        private System.Windows.Forms.Button CancelButton;
    }
}