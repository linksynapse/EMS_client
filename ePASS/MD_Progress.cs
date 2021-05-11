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
    public partial class MD_Progress : Form
    {
        public int Value
        {
            get
            {
                return Progress.Value;
            }
            set => Progress.Value = value;
        }

        public MD_Progress(int max = 100, int min = 0, int value = 0, int step = 1)
        {
            InitializeComponent();

            Progress.Maximum = max;
            Progress.Minimum = min;
            Progress.Value = value;
            Progress.Step = step;
            
            this.TopMost = true;
        }

        public void PerformStep()
        {
            Progress.PerformStep();
        }

        public void SetStatusLabel(string str)
        {
            StatusLabel.Text = str;
        }

        private void MD_Progress_Shown(object sender, EventArgs e)
        {
        }
    }
}
