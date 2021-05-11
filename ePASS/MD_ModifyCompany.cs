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
    public partial class MD_ModifyCompany : Form
    {
        private data.Web web;
        private Action Callback;

        public MD_ModifyCompany(string Nonce, string Name, string UEN, string TypeOfWork, Dictionary<string, object> ComboBind, data.Web web, Action Callback = null)
        {
            InitializeComponent();

            this.web = web;
            this.Callback = Callback;

            TypeOfWorkBox.DataSource = new BindingSource(ComboBind, null);
            TypeOfWorkBox.DisplayMember = "Key";
            TypeOfWorkBox.ValueMember = "Value";

            NonceTxt.Text = Nonce;
            NameTxt.Text = Name;
            UENTxt.Text = UEN;
            TypeOfWorkBox.SelectedItem = TypeOfWork;
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
                        dict.Add("Nonce", NonceTxt.Text);
                        dict.Add("Name", NameTxt.Text);
                        dict.Add("UEN", UENTxt.Text);
                        dict.Add("TypeOfWork", TypeOfWorkBox.SelectedValue);
                        string r = web.GetRequest("update/modifyCompany", dict);
                        if (data.bindData.GetInstDelResult(r))
                        {
                            MessageBox.Show("Company \"" + NameTxt.Text + "\" was modified.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            this.Close();
                            if (Callback != null)
                            {
                                Callback();
                            }
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
