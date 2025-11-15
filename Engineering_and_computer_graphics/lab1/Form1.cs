using System.Drawing;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Text = "ИКГ — Лаба 1: Домик в деревне";
            ClientSize = new Size(900, 500);
            DoubleBuffered = true;

            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            Pen redPen = new Pen(Color.Red, 5);
            Pen roofPen = new Pen(Color.BurlyWood, 5);
            Pen brownPen = new Pen(Color.Brown, 5);
            Pen blackPen5 = new Pen(Color.Black, 5);
            Pen blackPen4 = new Pen(Color.Black, 4);
            Pen blackPen3 = new Pen(Color.Black, 3);
            Pen blackPen2 = new Pen(Color.Black, 2);
            Pen fencePen = new Pen(Color.BurlyWood, 6);
            Pen fencePostPen = new Pen(Color.BurlyWood, 4);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush smokeBrush = new SolidBrush(Color.Gray);

            //Рисуем каркас дома
            g.DrawRectangle(redPen, 230, 230, 300, 200);

            //Рисуем крышу
            g.DrawLine(roofPen, 200, 230, 380, 60);
            g.DrawLine(roofPen, 380, 60, 560, 230);
            g.DrawLine(roofPen, 200, 230, 560, 230);

            //Рисуем трубу
            g.DrawLine(brownPen, 290, 145, 290, 80);
            g.DrawLine(brownPen, 290, 80, 315, 80);
            g.DrawLine(brownPen, 315, 80, 315, 122);

            //Рисуем окно
            g.DrawRectangle(blackPen5, 260, 260, 120, 120);
            g.DrawRectangle(blackPen2, 270, 270, 100, 100);
            g.DrawLine(blackPen3, 320, 270, 320, 370);
            g.DrawLine(blackPen3, 270, 320, 370, 320);

            //Рисуем окно на чердаке
            g.DrawEllipse(blackPen5, 340, 130, 80, 80);
            g.DrawLine(blackPen3, 380, 130, 380, 210);
            g.DrawLine(blackPen3, 340, 170, 420, 170);

            //Рисуем дверь
            g.DrawRectangle(blackPen4, 430, 290, 80, 137);
            g.FillEllipse(blackBrush, 435, 360, 12, 12);

            //Рисуем Дым
            g.FillEllipse(smokeBrush, 300, 50, 10, 10);
            g.FillEllipse(smokeBrush, 320, 55, 10, 10);
            g.FillEllipse(smokeBrush, 315, 50, 15, 15);
            g.FillEllipse(smokeBrush, 290, 48, 10, 10);
            g.FillEllipse(smokeBrush, 300, 70, 10, 10);
            g.FillEllipse(smokeBrush, 350, 68, 8, 8);
            g.FillEllipse(smokeBrush, 286, 66, 10, 10);
            g.FillEllipse(smokeBrush, 320, 35, 13, 13);
            g.FillEllipse(smokeBrush, 307, 38, 8, 8);
            g.FillEllipse(smokeBrush, 330, 80, 8, 8);
            g.FillEllipse(smokeBrush, 344, 30, 15, 15);
            g.FillEllipse(smokeBrush, 339, 17, 16, 16);
            g.FillEllipse(smokeBrush, 328, 20, 10, 10);
            g.FillEllipse(smokeBrush, 309, 24, 10, 10);

            //Рисуем забор
            g.DrawLine(fencePen, 533, 330, 770, 330);
            g.DrawLine(fencePen, 533, 400, 770, 400);

            for (int x = 540; x <= 780; x += 30)
            {
                g.DrawRectangle(fencePostPen, x, 300, 20, 130);
            }
        }
    }
}
