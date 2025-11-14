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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            progressBar1.Value = 10*trackBar1.Value;
            if (progressBar1.Value == 100)
                MessageBox.Show("До конца прокрутил");
        }

        private void progressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Visible = true;
        }

        private void progressBar1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
                MessageBox.Show("Хороший выбор");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(tabControl1.SelectedIndex.ToString());
        }

        private void button_indexChancge_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fnt = new Font("Arial",16);
            g.DrawString("Это Новая строка", fnt, System.Drawing.Brushes.Blue, new Point(0, 0));
        }
    }
}
