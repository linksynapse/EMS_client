
namespace UserControlSet
{
    partial class SDK_Pass
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameTxt = new System.Windows.Forms.Label();
            this.NRICTxt = new System.Windows.Forms.Label();
            this.DesignationTxt = new System.Windows.Forms.Label();
            this.CompanyTxt = new System.Windows.Forms.Label();
            this.DateOfSICTxt = new System.Windows.Forms.Label();
            this.QRCodeImage = new System.Windows.Forms.PictureBox();
            this.ProfileImage = new System.Windows.Forms.PictureBox();
            this.PassNoTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTxt
            // 
            this.NameTxt.AutoSize = true;
            this.NameTxt.BackColor = System.Drawing.Color.Transparent;
            this.NameTxt.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameTxt.Location = new System.Drawing.Point(258, 563);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(88, 36);
            this.NameTxt.TabIndex = 1;
            this.NameTxt.Text = "Eden";
            // 
            // NRICTxt
            // 
            this.NRICTxt.AutoSize = true;
            this.NRICTxt.BackColor = System.Drawing.Color.Transparent;
            this.NRICTxt.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NRICTxt.Location = new System.Drawing.Point(258, 617);
            this.NRICTxt.Name = "NRICTxt";
            this.NRICTxt.Size = new System.Drawing.Size(189, 36);
            this.NRICTxt.TabIndex = 2;
            this.NRICTxt.Text = "G1234567U";
            // 
            // DesignationTxt
            // 
            this.DesignationTxt.AutoSize = true;
            this.DesignationTxt.BackColor = System.Drawing.Color.Transparent;
            this.DesignationTxt.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DesignationTxt.Location = new System.Drawing.Point(258, 670);
            this.DesignationTxt.Name = "DesignationTxt";
            this.DesignationTxt.Size = new System.Drawing.Size(156, 36);
            this.DesignationTxt.TabIndex = 3;
            this.DesignationTxt.Text = "Developer";
            // 
            // CompanyTxt
            // 
            this.CompanyTxt.AutoSize = true;
            this.CompanyTxt.BackColor = System.Drawing.Color.Transparent;
            this.CompanyTxt.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CompanyTxt.Location = new System.Drawing.Point(258, 728);
            this.CompanyTxt.Name = "CompanyTxt";
            this.CompanyTxt.Size = new System.Drawing.Size(278, 36);
            this.CompanyTxt.TabIndex = 4;
            this.CompanyTxt.Text = "BLUZEN PTE LTD";
            // 
            // DateOfSICTxt
            // 
            this.DateOfSICTxt.AutoSize = true;
            this.DateOfSICTxt.BackColor = System.Drawing.Color.Transparent;
            this.DateOfSICTxt.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DateOfSICTxt.Location = new System.Drawing.Point(258, 777);
            this.DateOfSICTxt.Name = "DateOfSICTxt";
            this.DateOfSICTxt.Size = new System.Drawing.Size(181, 36);
            this.DateOfSICTxt.TabIndex = 5;
            this.DateOfSICTxt.Text = "2021-01-01";
            // 
            // QRCodeImage
            // 
            this.QRCodeImage.BackColor = System.Drawing.Color.Transparent;
            this.QRCodeImage.Location = new System.Drawing.Point(547, 875);
            this.QRCodeImage.Name = "QRCodeImage";
            this.QRCodeImage.Size = new System.Drawing.Size(176, 176);
            this.QRCodeImage.TabIndex = 6;
            this.QRCodeImage.TabStop = false;
            // 
            // ProfileImage
            // 
            this.ProfileImage.BackColor = System.Drawing.Color.Transparent;
            this.ProfileImage.Location = new System.Drawing.Point(200, 230);
            this.ProfileImage.Name = "ProfileImage";
            this.ProfileImage.Size = new System.Drawing.Size(344, 311);
            this.ProfileImage.TabIndex = 7;
            this.ProfileImage.TabStop = false;
            // 
            // PassNoTxt
            // 
            this.PassNoTxt.AutoSize = true;
            this.PassNoTxt.BackColor = System.Drawing.Color.Transparent;
            this.PassNoTxt.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PassNoTxt.Location = new System.Drawing.Point(257, 829);
            this.PassNoTxt.Name = "PassNoTxt";
            this.PassNoTxt.Size = new System.Drawing.Size(33, 36);
            this.PassNoTxt.TabIndex = 9;
            this.PassNoTxt.Text = "1";
            // 
            // SDK_Pass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserControlSet.Properties.Resources.Consultant;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.PassNoTxt);
            this.Controls.Add(this.ProfileImage);
            this.Controls.Add(this.QRCodeImage);
            this.Controls.Add(this.DateOfSICTxt);
            this.Controls.Add(this.CompanyTxt);
            this.Controls.Add(this.DesignationTxt);
            this.Controls.Add(this.NRICTxt);
            this.Controls.Add(this.NameTxt);
            this.DoubleBuffered = true;
            this.Name = "SDK_Pass";
            this.Size = new System.Drawing.Size(750, 1080);
            ((System.ComponentModel.ISupportInitialize)(this.QRCodeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameTxt;
        private System.Windows.Forms.Label NRICTxt;
        private System.Windows.Forms.Label DesignationTxt;
        private System.Windows.Forms.Label CompanyTxt;
        private System.Windows.Forms.Label DateOfSICTxt;
        private System.Windows.Forms.PictureBox QRCodeImage;
        private System.Windows.Forms.PictureBox ProfileImage;
        private System.Windows.Forms.Label PassNoTxt;
    }
}
