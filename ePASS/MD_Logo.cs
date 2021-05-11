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
    public partial class MD_LOGO : Form
    {
        public MD_LOGO()
        {
            InitializeComponent();
        }

        private void MD_LOGO_Load(object sender, EventArgs e)
        {
            
        }

        private void MD_LOGO_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MD_LOGO_Shown(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 3000;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            timer.Stop();
            this.Close();
        }
    }
}
