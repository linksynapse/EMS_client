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
    public partial class MD_ModifyEmployee : Form
    {
        private data.Web web;

        private bool nPhoto = false;
        private bool nDocument = false;

        private string PassNo;
        private Dictionary<string, object> u;

        public MD_ModifyEmployee(data.Web web, string PassNo)
        {
            InitializeComponent();

            this.web = web;
            this.PassNo = PassNo;
            CSOCCb.SelectedIndex = 0;
        }

        private void DateOfSICTxt_DoubleClick(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            PU_DatePick datePick = new PU_DatePick();
            datePick.Location = Cursor.Position;
            if (datePick.ShowDialog() == DialogResult.OK)
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
                                            ApplyData();
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

        private void MD_AddEmployee_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> Company = data.bindData.GetCompanyToDict(web.GetRequest("inform/getCompany", new Dictionary<string, object>()));
            CompanyCb.DataSource = new BindingSource(Company, null);
            CompanyCb.DisplayMember = "Key";
            CompanyCb.ValueMember = "Value";

            Dictionary<string, object> CompanyRole = data.bindData.GetKeyToDict(web.GetRequest("inform/getCompanyRole", new Dictionary<string, object>()));
            CompanyRoleCb.DataSource = new BindingSource(CompanyRole, null);
            CompanyRoleCb.DisplayMember = "Key";
            CompanyRoleCb.ValueMember = "Value";

            Dictionary<string, object> Additional = data.bindData.GetKeyToDict(web.GetRequest("inform/getAdditionalCourse", new Dictionary<string, object>()));
            AdditionalCb.DataSource = new BindingSource(Additional, null);
            AdditionalCb.DisplayMember = "Key";
            AdditionalCb.ValueMember = "Value";

            Dictionary<string, object> Category = data.bindData.GetKeyToDict(web.GetRequest("inform/getCategory", new Dictionary<string, object>()));
            CategoryCb.DataSource = new BindingSource(Category, null);
            CategoryCb.DisplayMember = "Key";
            CategoryCb.ValueMember = "Value";

            Dictionary<string, object> r = data.bindData.GetEmployee(web.GetRequest("inform/getEmployee", new Dictionary<string, object>() { { "PassNo", PassNo } }));
            u = r;
            NameTxt.Text = r["name"].ToString();
            foreach (var x in Category)
            {
                if (x.Value.ToString() == r["category"].ToString())
                    CategoryCb.SelectedItem = x.Key;
            }
            AdditionalToTxt.Text = r["additionalCourseTo"] is null ? "" : r["additionalCourseTo"].ToString();
            foreach (var x in Additional)
            {
                if (x.Value.ToString() == r["additionalCourse"].ToString())
                    AdditionalCb.SelectedIndex = Convert.ToInt32(x.Value.ToString());
            }
            AdditionalFromTxt.Text = r["additionalCourseFrom"] is null ? "" : r["additionalCourseFrom"].ToString();
            NRICTxt.Text = r["nric"].ToString();
            foreach (var x in CompanyRole)
            {
                if (x.Value.ToString() == r["companyRole"].ToString())
                    CompanyRoleCb.SelectedIndex = Convert.ToInt32(x.Value.ToString());
            }
            foreach (var x in Company)
            {
                if (x.Value.ToString() == r["company"].ToString())
                    CompanyCb.SelectedItem = x.Key;
            }
            OccupationTxt.Text = r["occupation"].ToString();
            PassNoTxt.Text = r["passNo"].ToString();
            MobileTxt.Text = r["mobile"].ToString();
            EmailTxt.Text = r["email"].ToString();
            DateOfSICTxt.Text = r["dateOfSIC"] is null ? "" : r["dateOfSIC"].ToString();
            RemarkTxt.Text = r["remark"].ToString();
            CSOCCb.SelectedIndex = Convert.ToInt32(r["csoc"].ToString());
            NationalityCb.SelectedItem = r["nationality"].ToString();
            ExpireDateTxt.Text = r["csoc_ExpireDate"] is null ? "" : r["csoc_ExpireDate"].ToString();

            foreach(KeyValuePair<string, object> x in CategoryCb.Items)
            {
                if(x.Value.ToString() == r["category"].ToString())
                {
                    CategoryCb.SelectedItem = x;
                }
            }

            foreach(KeyValuePair<string, object> x in CompanyCb.Items)
            {
                if (x.Value.ToString() == r["company"].ToString())
                {
                    CompanyCb.SelectedItem = x;
                }
            }

            Dictionary<string, object> ProfileImg = data.bindData.GetKeyToDict(web.GetRequest("inform/profileimg", new Dictionary<string, object>() { { "PassNo", PassNo } }));
            Dictionary<string, object> Document = data.bindData.GetKeyToDict(web.GetRequest("inform/document", new Dictionary<string, object>() { { "PassNo", PassNo } }));

            if (ProfileImg.Count > 0)
            {
                ProfileImage.Load("http://" + web.Host + "/download/resource?Idx=" + ProfileImg["NRIC.jpg"].ToString());
                ProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
                PhotoLabel.Visible = false;
            }

            if (Document.Count > 0)
            {
                if (CSOCCb.SelectedIndex == 0)
                {
                    ((ListBox)AdditionalDocumentList).DataSource = new BindingSource(Document, null);
                    ((ListBox)AdditionalDocumentList).DisplayMember = "Key";
                    ((ListBox)AdditionalDocumentList).ValueMember = "Value";
                }
                else
                {
                    ((ListBox)CSOCDocumentList).DataSource = new BindingSource(Document, null);
                    ((ListBox)CSOCDocumentList).DisplayMember = "Key";
                    ((ListBox)CSOCDocumentList).ValueMember = "Value";
                }
            }
        }

        private void CategoryCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            param.Add("Remark", RemarkTxt.Text);
            param.Add("PassNo", PassNoTxt.Text);
            param.Add("CSOC", CSOCCb.SelectedIndex);
            param.Add("CSOC_ExpireDate", ExpireDateTxt.Text);
            param.Add("AdditionalCourse", AdditionalCb.SelectedValue);
            param.Add("AdditionalCourseFrom", AdditionalFromTxt.Text);
            param.Add("AdditionalCourseTo", AdditionalToTxt.Text);

            if (data.bindData.GetInstDelResult(web.GetRequest("update/modifyEmployee", param)))
            {
                if (nPhoto)
                {
                    data.bindData.GetInstDelResult(web.GetRequest("update/deleteUserPhoto", new Dictionary<string, object>() { { "PassNo", PassNoTxt.Text } }));
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

                if (nDocument)
                {
                    data.bindData.GetInstDelResult(web.GetRequest("update/deleteUserDocument", new Dictionary<string, object>() { { "PassNo", PassNoTxt.Text } }));

                    foreach (var x in CSOCDocumentList.CheckedItems)
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

                MessageBox.Show("Employee " + NameTxt.Text + " was modified.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
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

                nPhoto = true;
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

                nPhoto = true;
            }
        }

        private void CSOCFileAddButton_Click(object sender, EventArgs e)
        {
            if (!nDocument)
            {
                if (MessageBox.Show("If you modify, all current files uploaded to the server will be deleted. Would you like to go on?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CSOCDocumentList.Items.Clear();
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Pdf Files|*.pdf";
                    ofd.Title = "Document Upload";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        nDocument = true;
                        CSOCDocumentList.Items.Add(new KeyValuePair<string, object>(Path.GetFileNameWithoutExtension(ofd.FileName), ofd.FileName), true);
                        ((ListBox)CSOCDocumentList).DisplayMember = "Key";
                        ((ListBox)CSOCDocumentList).ValueMember = "Value";
                    }
                }
            }
            else
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
        }

        private void CSOCFileDelButton_Click(object sender, EventArgs e)
        {
            if (!nDocument)
            {
                if (MessageBox.Show("If you modify, all current files uploaded to the server will be deleted. Would you like to go on?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    nDocument = true;
                    ((ListBox)CSOCDocumentList).DataSource = null;
                }
            }
            else
            {
                CSOCDocumentList.Items.Clear();
            }
        }

        private void AdditionalFileAddButton_Click(object sender, EventArgs e)
        {
            if (!nDocument)
            {
                if (MessageBox.Show("If you modify, all current files uploaded to the server will be deleted. Would you like to go on?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    AdditionalDocumentList.Items.Clear();
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Pdf Files|*.pdf";
                    ofd.Title = "Document Upload";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        nDocument = true;
                        AdditionalDocumentList.Items.Add(new KeyValuePair<string, object>(Path.GetFileNameWithoutExtension(ofd.FileName), ofd.FileName), true);
                        ((ListBox)AdditionalDocumentList).DisplayMember = "Key";
                        ((ListBox)AdditionalDocumentList).ValueMember = "Value";
                    }
                }
            }
            else
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
        }

        private void AdditionalFileDelButton_Click(object sender, EventArgs e)
        {
            if (!nDocument)
            {
                if (MessageBox.Show("If you modify, all current files uploaded to the server will be deleted. Would you like to go on?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    nDocument = true;
                    ((ListBox)AdditionalDocumentList).DataSource = null;
                }
            }
            else
            {
                AdditionalDocumentList.Items.Clear();
            }
        }

        private void CSOCCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedIndex == 0 && CategoryCb.SelectedIndex < 2)
            {
                ExpireDateTxt.Enabled = false;
                CSOCDocumentList.Enabled = false;
                CSOCFileAddButton.Enabled = false;
                CSOCFileDelButton.Enabled = false;
                gbAdditionalCourse.Enabled = true;

                ExpireDateTxt.Text = "";
                if (nDocument)
                {
                    CSOCDocumentList.Items.Clear();
                }
                else
                {
                    ((ListBox)CSOCDocumentList).DataSource = null;
                }
                
            }
            else if (combo.SelectedIndex == 1)
            {
                ExpireDateTxt.Enabled = true;
                CSOCDocumentList.Enabled = true;
                CSOCFileAddButton.Enabled = true;
                CSOCFileDelButton.Enabled = true;
                gbAdditionalCourse.Enabled = false;

                AdditionalFromTxt.Text = "";
                AdditionalToTxt.Text = "";
                if (nDocument)
                {
                    AdditionalDocumentList.Items.Clear();
                }
                else
                {
                    ((ListBox)AdditionalDocumentList).DataSource = null;
                }
                AdditionalCb.SelectedIndex = 0;
            }
        }
    }
}
