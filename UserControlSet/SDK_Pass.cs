using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace UserControlSet
{
    public partial class SDK_Pass : UserControl
    {
        public SDK_Pass(Dictionary<string, object> u, data.Web web)
        {
            InitializeComponent();

            // QR Code Generator
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("http://sdkhse.com/qr?n=" + u["passNo"], QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, true);
            QRCodeImage.Image = (Image)qrCodeImage;
            QRCodeImage.SizeMode = PictureBoxSizeMode.StretchImage;

            // Profile Image
            if (u["profile"].ToString() == "0")
            {

            }
            else
            {
                Dictionary<string, object> ProfileImg = data.bindData.GetKeyToDict(web.GetRequest("inform/profileimg", new Dictionary<string, object>() { { "PassNo", u["passNo"].ToString() } }));
                ProfileImage.Load("http://" + web.Host + "/download/resource?Idx=" + ProfileImg["NRIC.jpg"].ToString());
                ProfileImage.Image = MakeCircularCrop(ProfileImage);
                ProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            // Data Input
            NameTxt.Text = u["name"].ToString();
            NRICTxt.Text = u["nric"].ToString();
            DesignationTxt.Text = u["occupation"].ToString();
            CompanyTxt.Text = u["company"].ToString();
            DateOfSICTxt.Text = u["dateOfSIC"].ToString();
            PassNoTxt.Text = u["passNo"].ToString().PadLeft(5,'0');

            // Background
            switch (u["category"].ToString())
            {
                case "0":
                    this.BackgroundImage = UserControlSet.Properties.Resources.Maincon;
                    break;
                case "1":
                    this.BackgroundImage = UserControlSet.Properties.Resources.sub_con;
                    break;
                case "2":
                    this.BackgroundImage = UserControlSet.Properties.Resources.mohh_whc;
                    break;
                case "3":
                    this.BackgroundImage = UserControlSet.Properties.Resources.Consultant;
                    break;
            }
        }

        private Image MakeCircularCrop(PictureBox image)
        {
            image.SizeMode = PictureBoxSizeMode.StretchImage;

            Bitmap bitmap = new Bitmap(image.Image.Width, image.Image.Height);
            Graphics g = Graphics.FromImage(bitmap);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, image.Image.Width, image.Image.Height);
            Region region = new Region(path);
            g.SetClip(region, CombineMode.Replace);
            Bitmap bmp = (Bitmap)image.Image;
            g.DrawImage(bmp, new Rectangle(0, 0, image.Image.Width, image.Image.Height)
                           , new Rectangle(0, 0, image.Image.Width, image.Image.Height)
                           , GraphicsUnit.Pixel);

            return bitmap;
        }
    }
}
