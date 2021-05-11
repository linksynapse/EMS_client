using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePASS
{
    public partial class MD_DetailEmployee : Form
    {
        private data.Web web;
        private string PassNo;

        public MD_DetailEmployee(data.Web web, string PassNo)
        {
            InitializeComponent();

            this.web = web;
            this.PassNo = PassNo;
            CSOCCb.SelectedIndex = 0;
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

            Dictionary<string, object> r = data.bindData.GetEmployee(web.GetRequest("inform/getEmployee", new Dictionary<string, object>(){{ "PassNo", PassNo }}));
            NameTxt.Text = r["name"].ToString();
            foreach(var x in Category)
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

            foreach (KeyValuePair<string, object> x in CategoryCb.Items)
            {
                if (x.Value.ToString() == r["category"].ToString())
                {
                    CategoryCb.SelectedItem = x;
                }
            }

            foreach (KeyValuePair<string, object> x in CompanyCb.Items)
            {
                if (x.Value.ToString() == r["company"].ToString())
                {
                    CompanyCb.SelectedItem = x;
                }
            }

            Dictionary<string, object> ProfileImg = data.bindData.GetKeyToDict(web.GetRequest("inform/profileimg", new Dictionary<string, object>() { { "PassNo", PassNo } }));
            Dictionary<string, object> Document = data.bindData.GetKeyToDict(web.GetRequest("inform/document", new Dictionary<string, object>() { { "PassNo", PassNo } }));

            if(ProfileImg.Count > 0)
            {
                ProfileImage.Load("http://" + web.Host + "/download/resource?Idx=" + ProfileImg["NRIC.jpg"].ToString());
                ProfileImage.SizeMode = PictureBoxSizeMode.StretchImage;
                PhotoLabel.Visible = false;
            }
            
            if(Document.Count > 0)
            {
                if(CSOCCb.SelectedIndex == 0)
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

        MD_Progress progress;
        private void AdditionalFileDownButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            progress = new MD_Progress();
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                foreach (var x in AdditionalDocumentList.CheckedItems)
                {
                    using (WebClient wc = new WebClient())
                    {
                        progress.Show();
                        wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                        wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                        wc.DownloadFileTaskAsync(
                            // Param1 = Link of file
                            new System.Uri("http://" + web.Host + "/download/resource?Idx=" + ((KeyValuePair<string, object>)x).Value.ToString()),
                            // Param2 = Path to save
                            fbd.SelectedPath + "\\" + ((KeyValuePair<string, object>)x).Key
                        );
                    }
                }
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lock (e.UserState)
            {
                progress.SetStatusLabel("Download Complete.");
                MessageBox.Show("Download Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progress.Close();
                Monitor.Pulse(e.UserState);
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lock(e.UserState)
            {
                progress.Value = e.ProgressPercentage;
                Monitor.Pulse(e.UserState);
            }
        }

        private void CSOCFileDownButton_Click(object sender, EventArgs e)
        {
            progress = new MD_Progress();
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {

                foreach (var x in AdditionalDocumentList.CheckedItems)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                        wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                        wc.DownloadFileTaskAsync(
                            // Param1 = Link of file
                            new System.Uri("http://" + web.Host + "/download/resource?Idx=" + ((KeyValuePair<string, object>)x).Value.ToString()),
                            // Param2 = Path to save
                            fbd.SelectedPath + "\\" + ((KeyValuePair<string, object>)x).Key
                        );
                    }
                }
            }
        }
    }
}
