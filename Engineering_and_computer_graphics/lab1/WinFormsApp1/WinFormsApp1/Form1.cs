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

            // чтобы не ковыряться в дизайнере — подписываемся на Paint в коде
            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            // Фон: небо и трава
            g.FillRectangle(Brushes.SkyBlue, 0, 0, Width, Height / 2);
            g.FillRectangle(Brushes.ForestGreen, 0, Height / 2, Width, Height / 2);

            // Дом: каркас
            var houseRect = new Rectangle(230, 230, 300, 200);
            g.FillRectangle(Brushes.Bisque, houseRect);
            g.DrawRectangle(new Pen(Color.Red, 5), houseRect);

            // Крыша (треугольник)
            Point p1 = new Point(200, 230);
            Point p2 = new Point(380, 60);
            Point p3 = new Point(560, 230);
            g.FillPolygon(Brushes.SaddleBrown, new[] { p1, p2, p3 });
            g.DrawPolygon(new Pen(Color.Brown, 5), new[] { p1, p2, p3 });

            // Труба
            g.FillRectangle(Brushes.Sienna, 290, 80, 25, 65);
            g.DrawRectangle(new Pen(Color.Brown, 3), 290, 80, 25, 65);

            // Основное окно
            var windowOuter = new Rectangle(260, 260, 120, 120);
            var windowInner = new Rectangle(270, 270, 100, 100);
            g.FillRectangle(Brushes.LightSkyBlue, windowInner);
            g.DrawRectangle(Pens.Black, windowOuter);
            g.DrawRectangle(new Pen(Color.Black, 2), windowInner);
            g.DrawLine(new Pen(Color.Black, 3), 320, 270, 320, 370);
            g.DrawLine(new Pen(Color.Black, 3), 270, 320, 370, 320);

            // Окно на чердаке
            var attic = new Rectangle(360, 120, 40, 40);
            g.FillEllipse(Brushes.LightYellow, attic);
            g.DrawEllipse(Pens.Black, attic);

            // Дверь
            var doorRect = new Rectangle(430, 270, 70, 160);
            g.FillRectangle(Brushes.SaddleBrown, doorRect);
            g.DrawRectangle(new Pen(Color.Brown, 4), doorRect);
            g.FillEllipse(Brushes.Gold, 490, 350, 10, 10); // ручка

            // Солнце
            g.FillEllipse(Brushes.Gold, 60, 40, 60, 60);

            // Облака
            DrawCloud(g, 320, 30);
            DrawCloud(g, 360, 20);
            DrawCloud(g, 390, 35);

            // Забор (две линии + столбики в цикле)
            var fencePen = new Pen(Color.BurlyWood, 6);
            g.DrawLine(fencePen, 533, 330, 770, 330);
            g.DrawLine(fencePen, 533, 400, 770, 400);

            var postPen = new Pen(Color.BurlyWood, 4);
            for (int x = 540; x <= 780; x += 30)
            {
                g.DrawRectangle(postPen, x, 300, 20, 130);
            }
        }

        private void DrawCloud(Graphics g, int x, int y)
        {
            using (var brush = new SolidBrush(Color.LightGray))
            {
                g.FillEllipse(brush, x, y, 30, 30);
                g.FillEllipse(brush, x + 15, y - 10, 35, 35);
                g.FillEllipse(brush, x + 30, y + 5, 30, 30);
            }
        }
    }
}
