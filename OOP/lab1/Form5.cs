using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Laba_1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void linkLabel_Anekdot_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.anekdot.ru/");
        }

        private void button_Activ_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                MessageBox.Show("Не лень кликать было?");
                progressBar1.Value = 0;
            }
            progressBar1.Value += 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;

        }
    }
}
