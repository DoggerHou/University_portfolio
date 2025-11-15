using System;
using System.Net;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Laba_1__IP
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            byte[] start_adress_bytes = IPAddress.Parse(textBoxStartIP.Text).GetAddressBytes();
            byte[] end_adress_bytes = IPAddress.Parse(textBoxEndIP.Text).GetAddressBytes();
            byte[] mask = new byte[4];
            byte[] broadcast = new byte[4];
            byte[] adressSeti = new byte[4];


            bool edge = false;
            for (int i = 0; i < 4; i++)//Рассчет маски
            {
                for (byte b = 128; b >= 1; b /= 2)
                {
                    if (!edge && (start_adress_bytes[i] & b) == (end_adress_bytes[i] & b))
                        mask[i] |= b;
                    else
                    {
                        edge = true;
                        mask[i] = (byte)(mask[i] & ~b);
                    }
                }
            }


            for (int i = 0; i < 4; i++)//считаем адрес сети и Широковещательный
            {
                adressSeti[i] = (byte)(start_adress_bytes[i] & mask[i]);
                broadcast[i] = (byte)(start_adress_bytes[i] |~ mask[i]);
            }

            //Выводим данные в 4 текстБокса
            textBoxMask.Text = mask[0].ToString() + '.' +
                        mask[1].ToString() + '.' + mask[2].ToString()
                        + '.' + mask[3].ToString();

            textBoxAdress.Text = adressSeti[0].ToString() + '.' +
                        adressSeti[1].ToString() + '.' + adressSeti[2].ToString()
                        + '.' + adressSeti[3].ToString();

            textBoxBroadcast.Text = broadcast[0].ToString() + '.' +
                        broadcast[1].ToString() + '.' + broadcast[2].ToString()
                        + '.' + broadcast[3].ToString();

            textBoxMacAdress.Text = NetworkInterface.GetAllNetworkInterfaces()
                        .Where(nic => nic.OperationalStatus == OperationalStatus.Up &&
                        nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                        .Select(nic => nic.GetPhysicalAddress().ToString())
                        .FirstOrDefault();


            int rows_index = 0;
            while (start_adress_bytes[0] != end_adress_bytes[0] ||
                start_adress_bytes[1] != end_adress_bytes[1] ||
                start_adress_bytes[2] != end_adress_bytes[2] ||
                start_adress_bytes[3] != end_adress_bytes[3])
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[rows_index].Cells[0].Value =
                start_adress_bytes[0].ToString() + '.' +
                start_adress_bytes[1].ToString() + '.' +
                start_adress_bytes[2].ToString() + '.' +
                start_adress_bytes[3].ToString();

                IPHostEntry host1;
                IPAddress DNS = new IPAddress(start_adress_bytes);
                try
                {
                    host1 = Dns.GetHostEntry(DNS);
                    dataGridView1.Rows[rows_index].Cells[1].Value = host1.HostName;
                    dataGridView1.Rows[rows_index].Cells[2].Value = "OK";
                }
                catch (Exception ex)
                {
                    dataGridView1.Rows[rows_index].Cells[1].Value = "------";
                    dataGridView1.Rows[rows_index].Cells[2].Value = "Not OK";
                }
                rows_index += 1;

                if (start_adress_bytes[3] + 1 > 255)
                {
                    if (start_adress_bytes[2] + 1 > 255)
                    {
                        if (start_adress_bytes[1] + 1 > 255)
                        {
                            start_adress_bytes[0] += 1;
                            start_adress_bytes[1] = 0;
                            start_adress_bytes[2] = 0;
                            start_adress_bytes[3] = 0;
                        }
                        start_adress_bytes[1] += 1;
                        start_adress_bytes[2] = 0;
                        start_adress_bytes[3] = 0;
                    }
                    start_adress_bytes[2] += 1;
                    start_adress_bytes[3] = 0;
                }
                start_adress_bytes[3] += 1;
            }
            dataGridView1.Rows.Add();
            dataGridView1.Rows[rows_index].Cells[0].Value =
                start_adress_bytes[0].ToString() + '.' +
                start_adress_bytes[1].ToString() + '.' +
                start_adress_bytes[2].ToString() + '.' +
                start_adress_bytes[3].ToString();

            IPHostEntry host2;
            IPAddress DNS2 = new IPAddress(start_adress_bytes);
            try
            {
                host2 = Dns.GetHostEntry(DNS2);
                dataGridView1.Rows[rows_index].Cells[1].Value = host2.HostName;
                dataGridView1.Rows[rows_index].Cells[2].Value = "OK";
            }
            catch (Exception ex)
            {
                dataGridView1.Rows[rows_index].Cells[1].Value = "------";
                dataGridView1.Rows[rows_index].Cells[2].Value = "Not OK";

            }
        }
    }
}

