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
    public partial class Form_MainForm : Form
    {
        public int buffer = 0;
        public Form_MainForm()
        {
            InitializeComponent();
            

        }

        private void button_Form_Button_1_Click(object sender, EventArgs e)
        {
            new Form3().ShowDialog();
        }

        private void button_Form_Button_2_Click(object sender, EventArgs e)
        {
            new Form4().ShowDialog();
        }

        private void button_Form_Button_3_Click(object sender, EventArgs e)
        {
            new Form5().ShowDialog();
        }

        private void button_Form_Button_4_Click(object sender, EventArgs e)
        {
            new Form6().ShowDialog();
        }

        private void button_Form_Button_5_Click(object sender, EventArgs e)
        {
            new Form7().ShowDialog();
        }


        private void Form_MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            label_MouseX.Text = e.X.ToString();
            label_MouseY.Text = e.Y.ToString();
        }
        
        private void pictureBox_BlackMetal_Click(object sender, EventArgs e)
        {
            buffer++;
            if (buffer == 10)
            {
                label_Chose.Text = "Ave Satan";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\2 Kurs\OOP\OOP_Laba 1\OOP_Laba 1\Resources\msuic.wav");
                player.Play();
                pictureBox_Stalin.Visible = true;
                buffer = 0;
            }
        }
    }
}
