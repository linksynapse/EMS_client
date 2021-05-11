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
    public partial class MD_AddEmployee : Form
    {
        private data.Web web;

        private bool nCSOC = false;
        private bool nAdditional = true;

        public MD_AddEmployee(data.Web web)
        {
            InitializeComponent();

            this.web = web;
            CSOCCb.SelectedIndex = 0;
        }

        private void DateOfSICTxt_DoubleClick(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            PU_DatePick datePick = new PU_DatePick();
            datePick.Location = Cursor.Position;
            if(datePick.ShowDialog() == DialogResult.OK)
            {
                box.Text = datePick.GetDate;
            }
        }

        private void ExpireDateTxt_DoubleClick(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            PU_DatePick datePick = new PU_DatePick();
            datePick.Location = Cursor.Position;
            if (datePick.ShowDialog() == DialogResult.OK)
            {
                box.Text = datePick.GetDate;
            }
        }

        private void AdditionalFromTxt_DoubleClick(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            PU_DatePick datePick = new PU_DatePick();
            datePick.Location = Cursor.Position;
            if (datePick.ShowDialog() == DialogResult.OK)
            {
                box.Text = datePick.GetDate;
            }
        }

        private void AdditionalToTxt_DoubleClick(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            PU_DatePick datePick = new PU_DatePick();
            datePick.Location = Cursor.Position;
            if (datePick.ShowDialog() == DialogResult.OK)
            {
                box.Text = datePick.GetDate;
            }
        }

        private void EmployeeApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTxt.Text != "")
                {
                    if (NRICTxt.Text != "")
                    {
                        if (OccupationTxt.Text != "")
                        {
                            if (CategoryCb.SelectedIndex != -1)
                            {
                                if (CompanyCb.SelectedIndex != -1)
                                {
                                    if (NationalityCb.SelectedIndex != -1)
                                    {
                                        if (CompanyRoleCb.SelectedIndex != -1)
                                        {
                                            if (nCSOC)
                                            {
                                                if (ExpireDateTxt.Text != "")
                                                {
                                                    if (CSOCDocumentList.Items.Count != 0)
                                                    {
                                                        ApplyData();
                                                    }
                                                    else
                                                    {
                                                        ToolTip t = new ToolTip();
                                                        t.Show("Must upload proof of CSOC Document", CSOCDocumentList, 1000);
                                                    }
                                                }
                                                else
                                                {
                                                    ToolTip t = new ToolTip();
                                                    t.Show("Must select expire date for CSOC", ExpireDateTxt, 1000);
                                                }
                                            }
                                            else
                                            {
                                                if (nAdditional)
                                                {
                                                    // Additional Course apply
                                                    if (AdditionalCb.SelectedIndex > 0)
                                                    {
                                                        if (AdditionalFromTxt.Text != "")
                                                        {
                                                            if (AdditionalToTxt.Text != "")
                                                            {
                                                                ApplyData();
                                                            }
                                                            else
                                                            {
                                                                ToolTip t = new ToolTip();
                                                                t.Show("Must select Additional course from date", AdditionalToTxt, 1000);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ToolTip t = new ToolTip();
                                                            t.Show("Must select Additional course to date", AdditionalFromTxt, 1000);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ToolTip t = new ToolTip();
                                                        t.Show("Must select additional course", AdditionalCb, 1000);
                                                    }
                                                }
                                                else
                                                {
                                                    // MOHH & Consultant
                                                    ApplyData();
                                                }
                                            }

                                        }
                                        else
                                        {
                                            ToolTip t = new ToolTip();
                                            t.Show("Must select company role", CompanyRoleCb, 1000);
                                        }
                                    }
                                    else
                                    {
                                        ToolTip t = new ToolTip();
                                        t.Show("Must select nationality", NationalityCb, 1000);
                                    }
                                }
                                else
                                {
                                    ToolTip t = new ToolTip();
                                    t.Show("Must select company", CompanyCb, 1000);
                                }
                            }
                            else
                            {
                                ToolTip t = new ToolTip();
                                t.Show("Must select category", CategoryCb, 1000);
                            }
                        }
                        else
                        {
                            ToolTip t = new ToolTip();
                            t.Show("Must input Occupation", OccupationTxt, 1000);
                        }
                    }
                    else
                    {
                        ToolTip t = new ToolTip();
                        t.Show("Must input NRIC/FIN", NRICTxt, 1000);
                    }
                }
                else
                {
                    ToolTip t = new ToolTip();
                    t.Show("Must input employee name", NameTxt, 1000);
                }
            }
            catch
            {
                MessageBox.Show("Checking upload Image must be below 500kb size. If errors occur continuously, try again after relogin and then restart plug-in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CSOCCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if(combo.SelectedIndex == 0 && CategoryCb.SelectedIndex < 2)
            {
                nAdditional = true;
                nCSOC = false;
                ExpireDateTxt.Enabled = false;
                CSOCDocumentList.Enabled = false;
                CSOCFileAddButton.Enabled = false;
                CSOCFileDelButton.Enabled = false;
                gbAdditionalCourse.Enabled = true;

                ExpireDateTxt.Text = "";
                CSOCDocumentList.Items.Clear();
            }
            else if(combo.SelectedIndex > 0)
            {
                nAdditional = false;
                nCSOC = true;
                ExpireDateTxt.Enabled = true;
                CSOCDocumentList.Enabled = true;
                CSOCFileAddButton.Enabled = true;
                CSOCFileDelButton.Enabled = true;
                gbAdditionalCourse.Enabled = false;

                AdditionalFromTxt.Text = "";
                AdditionalToTxt.Text = "";
                AdditionalDocumentList.Items.Clear();
                AdditionalCb.SelectedIndex = 0;
            }
        }

        private void MD_AddEmployee_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> r = data.bindData.GetCompanyToDict(web.GetRequest("inform/getCompany", new Dictionary<string, object>()));
            CompanyCb.DataSource = new BindingSource(r, null);
            CompanyCb.DisplayMember = "Key";
            CompanyCb.ValueMember = "Value";

            r = data.bindData.GetKeyToDict(web.GetRequest("inform/getCompanyRole", new Dictionary<string, object>()));
            CompanyRoleCb.DataSource = new BindingSource(r, null);
            CompanyRoleCb.DisplayMember = "Key";
            CompanyRoleCb.ValueMember = "Value";

            r = data.bindData.GetKeyToDict(web.GetRequest("inform/getAdditionalCourse", new Dictionary<string, object>()));
            AdditionalCb.DataSource = new BindingSource(r, null);
            AdditionalCb.DisplayMember = "Key";
            AdditionalCb.ValueMember = "Value";

            r = data.bindData.GetKeyToDict(web.GetRequest("inform/getCategory", new Dictionary<string, object>()));
            CategoryCb.DataSource = new BindingSource(r, null);
            CategoryCb.DisplayMember = "Key";
            CategoryCb.ValueMember = "Value";
        }

        private void CategoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CategoryCb.SelectedIndex == 2 || CategoryCb.SelectedIndex == 3)
            {
                gbCSOC.Enabled = false;
                gbAdditionalCourse.Enabled = false;

                CSOCCb.SelectedIndex = 0;
                AdditionalCb.SelectedIndex = 0;

                ExpireDateTxt.Text = "";
                CSOCDocumentList.Items.Clear();

                AdditionalFromTxt.Text = "";
                AdditionalToTxt.Text = "";
                AdditionalDocumentList.Items.Clear();

                nCSOC = false;
                nAdditional = false;
            }
            else
            {
                gbCSOC.Enabled = true;
                gbAdditionalCourse.Enabled = true;
            }
        }

        private void ApplyData()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("CompanyRole", CompanyRoleCb.SelectedValue);
            param.Add("Name", NameTxt.Text);
            param.Add("Mobile", MobileTxt.Text);
            param.Add("Occupation", OccupationTxt.Text);
            param.Add("Email", EmailTxt.Text);
            param.Add("NRIC", NRICTxt.Text);
            param.Add("Category", CategoryCb.SelectedValue);
            param.Add("Company", CompanyCb.SelectedValue);
            param.Add("Nationality", NationalityCb.SelectedItem.ToString());
            param.Add("DateOfSIC", DateOfSICTxt.Text);
            param.Add("CSOC", CSOCCb.SelectedIndex);
            param.Add("CSOC_ExpireDate", ExpireDateTxt.Text);
            param.Add("Remark", RemarkTxt.Text);
            param.Add("AdditionalCourse", AdditionalCb.SelectedValue);
            param.Add("AdditionalCourseFrom", AdditionalFromTxt.Text);
            param.Add("AdditionalCourseTo", AdditionalToTxt.Text);

            if(data.bindData.GetInstDelResult(web.GetRequest("update/createEmployee", param)))
            {
                if (nCSOC)
                {
                    foreach(var x in CSOCDocumentList.CheckedItems)
                    {
                        KeyValuePair<string, object> Temp = (KeyValuePair<string, object>)x;
                        bool r = data.bindData.GetInstDelResult(web.PostMultipart("upload/uploadFile", new Dictionary<string, object>()
                                                {
                                                    {
                                                        "File", new data.FormFile()
                                                        {
                                                        Name = Path.GetFileName(Temp.Value.ToString()),
                                                        ContentType = "application/pdf",
                                                        FilePath = Temp.Value.ToString()
                                                        }
                                                     },
                                                     {
                                                         "NRIC",NRICTxt.Text
                                                     }
                                                }));
                        
                    }
                }

                if (nAdditional)
                {
                    foreach (var x in AdditionalDocumentList.CheckedItems)
                    {
                        KeyValuePair<string, object> Temp = (KeyValuePair<string, object>)x;
                        bool r = data.bindData.GetInstDelResult(web.PostMultipart("upload/uploadFile", new Dictionary<string, object>()
                                                {
                                                    {
                                                        "File", new data.FormFile()
                                                        {
                                                        Name = Path.GetFileName(Temp.Value.ToString()),
                                                        ContentType = "application/pdf",
                                                        FilePath = Temp.Value.ToString()
                                                        }
                                                     },
                                                     {
                                                         "NRIC",NRICTxt.Text
                                                     }
                                                }));

                    }
                }
                if (!PhotoLabel.Visible)
                {
                    Dictionary<string, object> ImgUpload = new Dictionary<string, object>();
                    ImgUpload.Add("NRIC", NRICTxt.Text);
                    using (MemoryStream m = new MemoryStream())
                    {
                        ProfileImage.Image.Save(m, ProfileImage.Image.RawFormat);
                        byte[] imageBytes = m.ToArray();
                        string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                        ImgUpload.Add("imgdata", base64String);
                    }
                    if (data.bindData.GetInstDelResult(web.PostRequest("upload/imgUpload", ImgUpload)))
                    {

                    }
                }
                MessageBox.Show("Employee " + NameTxt.Text + " was created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CSOCFileAddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pdf Files|*.pdf";
            ofd.Title = "Document Upload";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CSOCDocumentList.Items.Add(new KeyValuePair<string, object>(Path.GetFileNameWithoutExtension(ofd.FileName), ofd.FileName), true);
                ((ListBox)CSOCDocumentList).DisplayMember = "Key";
                ((ListBox)CSOCDocumentList).ValueMember = "Value";
            }
        }

        private void AdditionalFileAddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pdf Files|*.pdf";
            ofd.Title = "Document Upload";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AdditionalDocumentList.Items.Add(new KeyValuePair<string, object>(Path.GetFileNameWithoutExtension(ofd.FileName), ofd.FileName), true);
                ((ListBox)AdditionalDocumentList).DisplayMember = "Key";
                ((ListBox)AdditionalDocumentList).ValueMember = "Value";
            }
        }

        private void CSOCFileDelButton_Click(object sender, EventArgs e)
        {
            CSOCDocumentList.Items.Clear();
        }

        private void AdditionalFileDelButton_Click(object sender, EventArgs e)
        {
            CSOCDocumentList.Items.Clear();
        }

        private void ProfileImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Title = "Image Upload";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(ofd.FileName);
                ProfileImage.Image = image;
                ProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
                PhotoLabel.Visible = false;
                PhotoLabel.Enabled = false;
            }
        }

        private void PhotoLabel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Title = "Image Upload";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(ofd.FileName);
                ProfileImage.Image = image;
                ProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
                PhotoLabel.Visible = false;
                PhotoLabel.Enabled = false;
            }
        }
    }
}
