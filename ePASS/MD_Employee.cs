using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePASS
{
    public partial class MD_Employee : Form
    {
        private data.Web web;
        private PrintDocument pd;
        public MD_Employee(data.Web web)
        {
            InitializeComponent();

            this.web = web;
            pd = new PrintDocument();

            CreateOne.Click += CreateOne_Click;
            DeleteEmployee.Click += DeleteEmployee_Click;
            ModifyEmployee.Click += ModifyEmployee_Click;
            Print.Click += Print_Click;
            pd.PrintPage += Pd_PrintPage;
            BulkImgUpload.Click += BulkImgUpload_Click;
            ImportExcel.Click += ImportExcel_Click;
            Export.Click += Export_Click;

            if (web.permit == 1)
            {
                AddEmployee.Visible = false;
                AddEmployee.Enabled = false;
                ModifyEmployee.Visible = false;
                ModifyEmployee.Enabled = false;
                DeleteEmployee.Enabled = false;
                DeleteEmployee.Visible = false;
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Employee data to CSV";
            sfd.OverwritePrompt = true;
            sfd.Filter = "CSV File(*.csv)|*.csv";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                MD_Progress progress = new MD_Progress(2, 0, 0, 1);
                progress.SetStatusLabel("Prepare CSV File..");
                progress.Show();
                DataTable dt = data.bindData.JsonToExcel(web.GetRequest("inform/getEmployeeString", new Dictionary<string, object>()));
                progress.PerformStep();
                data.bindData.ToCSV(dt, sfd.FileName);
                progress.PerformStep();
                progress.Close();
            }
        }

        private void ImportExcel_Click(object sender, EventArgs e)
        {
            MD_BulkUploadExcel bulkUploadExcel = new MD_BulkUploadExcel(web);
            bulkUploadExcel.ShowDialog();
        }

        private void BulkImgUpload_Click(object sender, EventArgs e)
        {
            MD_BulkUploadImg bulkUploadImg = new MD_BulkUploadImg(web);
            bulkUploadImg.ShowDialog();
        }

        IEnumerator enumerator;
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            UserControlSet.SDK_Pass pass = new UserControlSet.SDK_Pass((Dictionary<string, object>)enumerator.Current, web);

            Bitmap bit = new Bitmap(pass.Width, pass.Height);
            pass.DrawToBitmap(bit, pass.ClientRectangle);

            e.Graphics.DrawImage(bit, 20,20);
            if (!enumerator.MoveNext())
            {
                e.HasMorePages = false;
                return;
            }
            else
            {
                e.HasMorePages = true;
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            List<Dictionary<string, object>> obj = new List<Dictionary<string, object>>();
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cell.Value))
                {
                    obj.Add(data.bindData.GetEmployee(web.GetRequest("inform/epass", new Dictionary<string, object>() { { "PassNo", row.Cells[1].Value.ToString() } })));
                }
            }

            enumerator = obj.GetEnumerator();
            enumerator.MoveNext();

            PrintDialog pdialog = new PrintDialog();
            if(pdialog.ShowDialog() == DialogResult.OK)
            {
                pd.PrinterSettings = pdialog.PrinterSettings;
                pd.Print();
            }
        }

        private void ModifyEmployee_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cell.Value))
                {
                    MD_ModifyEmployee modifyEmployee = new MD_ModifyEmployee(web, row.Cells[1].Value.ToString());
                    modifyEmployee.Show();
                }
            }
        }

        private void DeleteEmployee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure delete selected items?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(cell.Value))
                    {
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        dict.Add("PassNo", row.Cells[1].Value.ToString());
                        if (data.bindData.GetInstDelResult(web.GetRequest("update/deleteEmployee", dict)))
                        {
                            continue;
                        }
                        else
                        {
                            MessageBox.Show("Your session has expired or another problem has occurred. Please restart the plug-in and try again. If the problem persists, please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }

                MessageBox.Show("Companys was deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SearchButton_Click(sender, e);
            }
        }

        private void CreateOne_Click(object sender, EventArgs e)
        {
            MD_AddEmployee addEmployee = new MD_AddEmployee(web);
            if(addEmployee.ShowDialog() == DialogResult.OK)
            {
                SearchButton_Click(sender, e);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int k = 0;
            foreach(var x in CompanyList.CheckedItems)
            {
                k++;
            }

            if(k == 0)
            {
                MessageBox.Show("Must select company over 1.","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGrid.Columns.Clear();

            Dictionary<string, object> param = new Dictionary<string, object>();
            int j = 0;
            string dummy = "";
            foreach (var x in CompanyList.CheckedItems)
            {
                for(int i = 0; i < j; i++) {
                    dummy += "$";
                }
                param.Add(dummy+"CompanyList[]", ((KeyValuePair<string, object>)x).Value.ToString());
                j++;
            }
            param.Add(SearchCategory.Text, SearchKeywordBox.Text);
            DataTable dt = data.bindData.GetEmployeeOmit(web.GetRequest("inform/getEmployeeOmit", param));
            if (dt == null)
            {
                MessageBox.Show("No Record", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lbTxtTotalCount.Text = "0";
                return;
            }
            // Additional Checkbox
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1
            = new DataGridViewCheckBoxColumn();
            dataGridViewCheckBoxColumn1.HeaderText = "#";
            dataGridViewCheckBoxColumn1.TrueValue = true;
            dataGridViewCheckBoxColumn1.FalseValue = false;
            dataGridViewCheckBoxColumn1.ThreeState = false;
            dataGridViewCheckBoxColumn1.ValueType = typeof(bool);

            dataGrid.DataSource = dt;

            dataGrid.Columns.Insert(0, dataGridViewCheckBoxColumn1);
            dataGrid.Columns[0].FillWeight = 20;
            dataGrid.Columns[0].MinimumWidth = 20;

            dataGrid.Columns[0].ReadOnly = false;
            dataGrid.Columns[1].ReadOnly = true;
            dataGrid.Columns[2].ReadOnly = true;
            dataGrid.Columns[3].ReadOnly = true;
            dataGrid.Columns[4].ReadOnly = true;
            dataGrid.Columns[5].ReadOnly = true;
            dataGrid.Columns[6].ReadOnly = true;
            dataGrid.Columns[7].ReadOnly = true;

            lbTxtTotalCount.Text = dt.Rows.Count.ToString();
        }

        private void MD_Employee_Shown(object sender, EventArgs e)
        {
            Dictionary<string, object> r = data.bindData.GetCompanyToDict(web.GetRequest("inform/getCompany", new Dictionary<string, object>()));
            ((ListBox)CompanyList).DataSource = new BindingSource(r, null);
            ((ListBox)CompanyList).DisplayMember = "Key";
            ((ListBox)CompanyList).ValueMember = "Value";
        }

        private void CompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGrid.SelectedCells[0].OwningRow;

            if (dataGrid.SelectedCells[0].ColumnIndex == 0 && dataGrid.SelectedCells[0].Value as bool? == true)
            {
                row.Cells[0].Value = false;
            }
            else if (dataGrid.SelectedCells[0].ColumnIndex == 0 && dataGrid.SelectedCells[0].Value as bool? == false)
            {
                row.Cells[0].Value = true;
            }
            else if (dataGrid.SelectedCells[0].ColumnIndex == 0 && dataGrid.SelectedCells[0].Value is null)
            {
                row.Cells[0].Value = true;
            }
        }

        private void WholeSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (cell.Value == null)
                {
                    cell.Value = true;
                    continue;
                }
                cell.Value = !(bool)cell.Value;
            }
        }

        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGrid.SelectedCells[0].OwningRow;
            MD_DetailEmployee detailEmployee = new MD_DetailEmployee(web, row.Cells[1].Value.ToString());
            if(detailEmployee.ShowDialog() == DialogResult.OK)
            {
                SearchButton_Click(sender, e);
            }
        }
    }
}
