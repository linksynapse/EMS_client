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
    public partial class MD_AddCompany : Form
    {
        private data.Web web;

        public MD_AddCompany(Dictionary<string, object> ComboBind, data.Web web)
        {
            InitializeComponent();

            this.web = web;

            TypeOfWorkBox.DataSource = new BindingSource(ComboBind, null);
            TypeOfWorkBox.DisplayMember = "Key";
            TypeOfWorkBox.ValueMember = "Value";
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTxt.Text != "")
                {
                    if (TypeOfWorkBox.SelectedIndex != -1)
                    {
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        dict.Add("Name", NameTxt.Text);
                        dict.Add("UEN", UENTxt.Text);
                        dict.Add("TypeOfWork", TypeOfWorkBox.SelectedValue);
                        string r = web.GetRequest("update/CreateCompany", dict);
                        if (data.bindData.GetInstDelResult(r))
                        {
                            MessageBox.Show("Company \"" + NameTxt.Text + "\" was created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Your session has expired or another problem has occurred. Please restart the plug-in and try again. If the problem persists, please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.None;
                            this.Close();
                        }

                    }
                    else
                    {
                        ToolTip t = new ToolTip();
                        t.Show("Must select TypeOfWork", TypeOfWorkBox, 1000);
                    }
                }
                else
                {
                    ToolTip t = new ToolTip();
                    t.Show("Must input company name", NameTxt, 1000);
                }
            }
            catch
            {
                MessageBox.Show("If errors occur continuously, try again after relogin and then restart plug-in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
