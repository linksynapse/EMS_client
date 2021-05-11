using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlSet
{
    public partial class ImageSet : UserControl
    {
        public string GetImageBase64
        {
            get
            {
                using (MemoryStream m = new MemoryStream())
                {
                    ProfileImg.Image.Save(m, ProfileImg.Image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    return Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                }
            }
        }

        public string GetNRIC
        {
            get
            {
                return NRIC.Text;
            }
        }

        public void SetSuccessed()
        {
            ProfileImg.Image = Properties.Resources.Success;
        }

        public void SetFailed()
        {
            ProfileImg.Image = Properties.Resources.Fail;
        }
        public ImageSet(Image img, string NRIC)
        {
            InitializeComponent();

            ProfileImg.Image = img;
            this.NRIC.Text = NRIC;

            ProfileImg.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
