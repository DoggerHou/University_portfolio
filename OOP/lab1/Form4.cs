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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                label_Chose.Text = "Вы дополнили список: "+comboBox1.Text;
                checkedListBox_Chose.Items.Add(comboBox1.Text);
            }
        }

        private void button_Checking_Click(object sender, EventArgs e)
        {
            string s = "";
            for(int i = 0; i < checkedListBox_Chose.Items.Count; i++)
            {
                if(checkedListBox_Chose.GetItemChecked(i)==false)
                    s=s+ (i + 1).ToString()+") " + checkedListBox_Chose.Items[i].ToString() + "\n";
            }
            if (s == "")
                s = "Вы собрали студента на пары!";
            else
                s = "Ну как же студент посетит Угату, вы ведь забыли:\n" + s;
            MessageBox.Show(s);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_Chose.Items.Count; i++)
                if (checkedListBox_Chose.GetItemChecked(i))
                    checkedListBox_Chose.Items.RemoveAt(i);
        }

        private void dateTimePicker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string s = dateTimePicker.Text;
                if (s == "1 сентября 1939 г.")
                    MessageBox.Show("Все верно!");
                else
                    MessageBox.Show("Кринж....\n"+dateTimePicker.Text);
            }
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            MessageBox.Show("DA");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Сменилось");
        }
    }
}
