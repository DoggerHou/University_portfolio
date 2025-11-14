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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button_No_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int r1 = rnd.Next();
            int r2 = rnd.Next();
            button_No.Location = new System.Drawing.Point(r1%700, r2%600);
            MessageBox.Show("Что-то пошло не так, пожалуйста повторите");
        }

        private void button_Yes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ура, круто, спасибо!");
            this.Close();
        }
    }
}
