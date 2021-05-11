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
    public partial class PU_DatePick : Form
    {
        public string GetDate
        {
            get
            {

                return Calender.SelectionStart.Date.ToString("dd/MM/yyyy").Replace("-", "/");
            }
        }
        public PU_DatePick()
        {
            InitializeComponent();

            this.TopMost = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
