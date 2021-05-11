using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ListBox = System.Windows.Forms.ListBox;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ePASS
{
    public partial class MD_BulkUploadExcel : Form
    {
        data.Web web;
        Dictionary<string, object> CompanyList;
        Dictionary<string, object> CategoryList;
        Dictionary<string, object> ImportList;
        bool CompleteBinding = false;
        public MD_BulkUploadExcel(data.Web web)
        {
            InitializeComponent();

            this.web = web;

            GetCompanyFromServer();
            GetCategoryFromServer();
        }

        public void GetCompanyFromServer()
        {
            CompanyList = data.bindData.GetCompanyToDict(web.GetRequest("inform/getCompany", new Dictionary<string, object>()));
        }

        public void GetCategoryFromServer()
        {
            CategoryList = data.bindData.GetKeyToDict(web.GetRequest("inform/getCategory", new Dictionary<string, object>()));
        }

        public int GetCompanyKeyWord(string keyword)
        {
            foreach(KeyValuePair<string, object> x in CompanyList)
            {
                if(x.Key.ToUpper().IndexOf(keyword.ToUpper()) != -1)
                {
                    return Convert.ToInt32(x.Value);
                }
            }
            return -1;
        }

        public int GetCategoryKeyWord(string keyword)
        {
            foreach (KeyValuePair<string, object> x in CategoryList)
            {
                if (x.Key.ToUpper().IndexOf(keyword.ToUpper()) != -1)
                {
                    return Convert.ToInt32(x.Value);
                }
            }
            return -1;
        }

        private void SelectExcelButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel file (*.xlsx) | *.xlsx";
            ofd.Title = "Excel upload";

            MD_Progress progress = new MD_Progress(4, 0, 0, 1);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                progress.Show();
                progress.SetStatusLabel("Loading data from excel to plugin.");
                List<Dictionary<string, object>> r = DataImporting(ofd.FileName);
                var enumerator = r.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Dictionary<string, object> data = enumerator.Current as Dictionary<string, object>;
                    int Temp = GetCompanyKeyWord(data["Company"].ToString());
                    if (Temp == -1)
                    {
                        r.Remove(data);
                        enumerator = r.GetEnumerator();
                    }
                    else
                    {
                        data["Company"] = Temp;
                    }
                }
                progress.PerformStep();
                progress.SetStatusLabel("Convert category data to server format.");
                enumerator = r.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Dictionary<string, object> data = enumerator.Current as Dictionary<string, object>;
                    int Temp = GetCategoryKeyWord(data["Category"].ToString());
                    if (Temp == -1)
                    {
                        r.Remove(data);
                        enumerator = r.GetEnumerator();
                    }
                    else
                    {
                        data["Category"] = Temp;
                    }
                }
                progress.PerformStep();
                progress.SetStatusLabel("Convert company data to server format.");
                ImportList = new Dictionary<string, object>();
                enumerator = r.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    try
                    {
                        Dictionary<string, object> data = enumerator.Current as Dictionary<string, object>;
                        ImportList.Add(data["Name"].ToString(), data);
                    }
                    catch
                    {

                    }
                }
                progress.PerformStep();
                progress.SetStatusLabel("Data binding to listbox.");
                EmployeeList.DataSource = new BindingSource(ImportList, null);
                EmployeeList.DisplayMember = "Key";
                EmployeeList.ValueMember = "Value";

                UploadButton.Enabled = true;
                SelectExcelButton.Enabled = false;

                CompleteBinding = true;
                progress.PerformStep();
                progress.SetStatusLabel("Completed.");
                progress.Close();
            }
        }

        private List<Dictionary<string, object>> DataImporting(string path)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Workbook wb = null;
            Worksheet ws = null;
            try
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                wb = excelApp.Workbooks.Open(path);
                ws = wb.Worksheets.get_Item(1) as Worksheet;
                Range rng = ws.UsedRange;
                object[,] data = rng.Value;
                for (int r = 2 ; r <= data.GetLength(0); r++)
                {
                    Dictionary<string, object> Temp = new Dictionary<string, object>();
                    Temp["Category"] = data[r, 2] is null ? string.Empty : data[r, 2].ToString();
                    Temp["Company"] = data[r, 3] is null ? string.Empty : data[r, 3].ToString();
                    Temp["NRIC"] = data[r, 4] is null ? string.Empty : data[r, 4].ToString();
                    Temp["Name"] = data[r, 5] is null ? string.Empty : data[r, 5].ToString();
                    Temp["Mobile"] = data[r, 6] is null ? string.Empty : data[r, 6].ToString();
                    Temp["Occupation"] = data[r, 7] is null ? string.Empty : data[r, 7].ToString();
                    Temp["Nationality"] = data[r, 8] is null ? string.Empty : data[r, 8].ToString();
                    Temp["DateOfSIC"] = data[r, 9] is null ? string.Empty : data[r, 9].ToString();
                    result.Add(Temp);
                }
                wb.Close(true);
                excelApp.Quit();
            }
            catch
            {
                throw;
            }
            finally
            {
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
            }

            return result;
        }

        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void EmployeeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CompleteBinding)
            {
                ListBox listbox = sender as ListBox;
                Dictionary<string, object> value = listbox.SelectedValue as Dictionary<string, object>;

                NameTxt.Text = value["Name"].ToString();
                NRICTxt.Text = value["NRIC"].ToString();
                MobileTxt.Text = value["Mobile"].ToString();
                OccupationTxt.Text = value["Occupation"].ToString();
                NationalityTxt.Text = value["Nationality"].ToString();
                CategoryTxt.Text = CategoryList.FirstOrDefault(x => x.Value.ToString() == value["Category"].ToString()).Key;
                DateOfSICTxt.Text = value["DateOfSIC"].ToString();
                CompanyTxt.Text = CompanyList.FirstOrDefault(x => x.Value.ToString() == value["Company"].ToString()).Key;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            MD_Progress progress = new MD_Progress(max: EmployeeList.Items.Count);
            progress.Show();

            foreach(KeyValuePair<string, object> x in ImportList)
            {
                try
                {
                    Dictionary<string, object> temp = x.Value as Dictionary<string, object>;
                    progress.SetStatusLabel("Uploading " + temp["Name"].ToString() + " to Server");
                    if (data.bindData.GetInstDelResult(web.GetRequest("update/createEmployeeBulk", temp)))
                    {
                        progress.PerformStep();
                    }
                }
                catch
                {
                    progress.PerformStep();
                }
            }

            progress.Close();
            this.Close();
        }
    }
}
