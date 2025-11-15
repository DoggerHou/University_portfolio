using ChatClient.ServiceChat;
using System;
using System.Windows.Forms;


namespace ChatClient
{
    public partial class Form1 : Form, IServiceChatCallback
    {

        bool isConnected = false;
        ServiceChat.ServiceChatClient client;
        int ID;
        public Form1()
        {
            InitializeComponent();
        }

        public void MessageCallback(string msg)
        {
            listBox1.Items.Add(msg);
        }

        //Подключиться
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(textBox3.Text);
                isConnected = true;
                textBox3.Enabled = false;
            }
        }

        //Отключиться
        private void button2_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                isConnected = false;
                textBox3.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                isConnected = false;
                textBox3.Enabled = true;
            }
        }

        //Отправить сообщение
        private void button3_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.SendMessage(textBox4.Text, ID);
                textBox4.Text = string.Empty;
            }

        }
    }

}
