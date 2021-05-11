using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePASS
{
    public partial class MD_Company : Form
    {
        private data.Web web;

        public MD_Company(string[] args)
        {
            InitializeComponent();

            web = data.Web.Parse(args[0]);

            Employee.Click += Employee_Click;
            Modify.Click += Modify_Click;
            CreateOne.Click += CreateOne_Click;
            Delete.Click += Delete_Click;


            if(web.permit == 1)
            {
                ModifyCompany.Visible = false;
                ModifyCompany.Enabled = false;
                AddCompany.Visible = false;
                AddCompany.Enabled = false;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure delete selected items?","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(cell.Value))
                    {
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        dict.Add("Nonce", row.Cells[1].Value.ToString());
                        if(data.bindData.GetInstDelResult(web.GetRequest("update/deleteCompany", dict)))
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
            Dictionary<string, object> dict = data.bindData.GetTypeOfWork(web.GetRequest("inform/getTypeOfWork", new Dictionary<string, object>()));
            MD_AddCompany addCompany = new MD_AddCompany(dict, web);
            if(addCompany.ShowDialog() == DialogResult.OK)
            {
                SearchButton_Click(sender, e);
            }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            Dictionary<string,object> dict = data.bindData.GetTypeOfWork(web.GetRequest("inform/getTypeOfWork", new Dictionary<string, object>()));
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                try
                {
                    DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if ((bool)cell.Value)
                    {
                        string Nonce = row.Cells[1].Value.ToString();
                        string Name = row.Cells[2].Value.ToString();
                        string UEN = row.Cells[3].Value.ToString();
                        string TypeOfWork = row.Cells[1].Value.ToString();

                        MD_ModifyCompany modifyCompany = new MD_ModifyCompany(Nonce, Name, UEN, TypeOfWork, dict, web, () => SearchButton_Click(sender, e));
                        modifyCompany.Show();
                    }
                }
                catch
                {

                }
                
            }
        }

        private void Employee_Click(object sender, EventArgs e)
        {
            MD_Employee employee = new MD_Employee(web);
            employee.Show();
        }

        private void MD_Company_Load(object sender, EventArgs e)
        {
            MD_LOGO logo = new MD_LOGO();
            logo.ShowDialog();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            dataGrid.Columns.Clear();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add(SearchCategory.Text, SearchKeywordBox.Text);

            string r = web.GetRequest("inform/getCompany", param);

            DataTable dt = data.bindData.GetCompany(r);
            if(dt == null)
            {
                MessageBox.Show("No Record", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void WholeSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if(cell.Value == null)
                {
                    cell.Value = true;
                    continue;
                }
                cell.Value = !(bool)cell.Value;
            }
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGrid.SelectedCells[0].OwningRow;

            if(dataGrid.SelectedCells[0].ColumnIndex == 0 && dataGrid.SelectedCells[0].Value as bool ? == true)
            {
                row.Cells[0].Value = false;
            }
            else if (dataGrid.SelectedCells[0].ColumnIndex == 0 && dataGrid.SelectedCells[0].Value as bool? == false)
            {
                row.Cells[0].Value = true;
            }
            else if(dataGrid.SelectedCells[0].ColumnIndex == 0 && dataGrid.SelectedCells[0].Value is null)
            {
                row.Cells[0].Value = true;
            }
        }
    }
}
