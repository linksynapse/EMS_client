
namespace UserControlSet
{
    partial class ImageSet
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProfileImg = new System.Windows.Forms.PictureBox();
            this.NRIC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfileImg
            // 
            this.ProfileImg.Location = new System.Drawing.Point(0, 0);
            this.ProfileImg.Name = "ProfileImg";
            this.ProfileImg.Size = new System.Drawing.Size(133, 147);
            this.ProfileImg.TabIndex = 0;
            this.ProfileImg.TabStop = false;
            // 
            // NRIC
            // 
            this.NRIC.Location = new System.Drawing.Point(0, 150);
            this.NRIC.Name = "NRIC";
            this.NRIC.Size = new System.Drawing.Size(133, 28);
            this.NRIC.TabIndex = 1;
            this.NRIC.Text = "1234U";
            this.NRIC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.NRIC);
            this.Controls.Add(this.ProfileImg);
            this.Name = "ImageSet";
            this.Size = new System.Drawing.Size(133, 178);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ProfileImg;
        private System.Windows.Forms.Label NRIC;
    }
}
