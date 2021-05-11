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

namespace ePASS
{
    public partial class MD_BulkUploadImg : Form
    {
        public data.Web web;
        public MD_BulkUploadImg(data.Web web)
        {
            InitializeComponent();

            this.web = web;
        }

        private void SelecteFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Title = "Image Upload";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (String x in ofd.FileNames)
                {
                    string NRIC = Path.GetFileNameWithoutExtension(x);
                    Image image = Image.FromFile(x);

                    UserControlSet.ImageSet imageSet = new UserControlSet.ImageSet(image, NRIC);
                    ImageLayouts.Controls.Add(imageSet);
                }

                UploadFilesButton.Enabled = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadFilesButton_Click(object sender, EventArgs e)
        {
            MD_Progress progress = new MD_Progress(max:ImageLayouts.Controls.Count);
            progress.Show();
            var enumerator = ImageLayouts.Controls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                UserControlSet.ImageSet Temp = enumerator.Current as UserControlSet.ImageSet;
                progress.SetStatusLabel("Uploading " + Temp.GetNRIC + " ..");
                param.Add("NRIC", Temp.GetNRIC);
                param.Add("imgdata", Temp.GetImageBase64);
                try
                {
                    if (data.bindData.GetInstDelResult(web.PostRequest("update/modifyUserPhoto", param)))
                    {
                        Temp.SetSuccessed();
                    }
                    else
                    {
                        Temp.SetFailed();
                    }
                }
                catch
                {
                    Temp.SetFailed();
                }

                progress.PerformStep();
            }
            MessageBox.Show("Files upload is completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progress.Close();
        }
    }
}
