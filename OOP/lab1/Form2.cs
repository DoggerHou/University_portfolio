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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox_First_TextChanged(object sender, EventArgs e)
        {
            textBox_Second.Text = textBox_First.Text;
        }

        private void textBox_Second_TextChanged(object sender, EventArgs e)
        {
            textBox_First.Text = textBox_Second.Text;
        }

        private void checkBox_Bright_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_Bright.CheckState != 0)
                pictureBox_Heaven.Visible = true;
            else
                pictureBox_Heaven.Visible = false;
        }

        private void checkBox_Dark_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_Dark.CheckState != 0)
                pictureBox_Hell.Visible = true;
            else
                pictureBox_Hell.Visible = false;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBox_Miracle.CheckState != 0)
            {
                System.Windows.Forms.PictureBox pictureBox_Face= new System.Windows.Forms.PictureBox();
                pictureBox_Face.BackgroundImage = global::OOP_Laba_1.Properties.Resources.Pep;
                pictureBox_Face.Size = new System.Drawing.Size(40, 40);
                pictureBox_Face.Location = new System.Drawing.Point(e.X, e.Y);

                this.Controls.Add(pictureBox_Face);
            }
        }
    }
}
