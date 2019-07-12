using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICIPinkWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ciao mondo!!");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int a1 = int.Parse(addendo1.Text);
            int a2 = int.Parse(addendo2.Text);

            MessageBox.Show("La somma dei due addendi è " + (a1 + a2));
        }
    }
}
