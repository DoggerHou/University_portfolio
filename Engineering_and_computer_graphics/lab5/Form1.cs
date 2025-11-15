using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using IKG_5_lab.Properties;
using OpenTK.Graphics.OpenGL;
namespace IKG_5_lab
{
    public partial class Form1 : Form
    {
        private float rot_1, rot_2;
        private const int MaxIter = 12;
        private double[,] GeometricArray = new double[MaxIter * MaxIter, 3];
        private double[,,] ResultGeometric = new double[MaxIter * MaxIter, MaxIter * MaxIter, 3];
        private int count_elements = 0;
        private int image_height = 0;
        private int image_width = 0;
        private double Angle = 2 * Math.PI / MaxIter;
        bool flagrotate = false;

        PolygonMode mode = PolygonMode.Fill;
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
        }


        private void AnT_Load(object sender, EventArgs e)
        {
            // очистка окна
            GL.ClearColor(Color.White);
            // очистка буферов цвета и глубины
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // установка порта вывода в соответствии с размерами элемента Anт
            GL.Viewport(0, 0, AnT.Width, AnT.Height);
            // настройка проекции
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Frustum(-0.1 * AnT.Width / AnT.Height, 0.1 * AnT.Width / AnT.Height, -0.1, 0.1, 0.1, 200);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            // настройка параметров OpenGL для визуализации
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

            comboBox2.SelectedIndex = 0;

            // задание параметров текстуры
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            // количество элементов последовательности геометрии, на основе которых будет строиться тело вращения
            count_elements = MaxIter;

            GeometricArray[11, 0] = 0;
            GeometricArray[11, 1] = 0;
            GeometricArray[11, 2] = 13;

            GeometricArray[10, 0] = 0.6;
            GeometricArray[10, 1] = 0;
            GeometricArray[10, 2] = 12.75;

            GeometricArray[9, 0] = 0.3;
            GeometricArray[9, 1] = 0;
            GeometricArray[9, 2] = 12.5;

            //шарик после пимпочки
            GeometricArray[9, 0] = 2;
            GeometricArray[9, 1] = 0;
            GeometricArray[9, 2] = 11.5;

            GeometricArray[8, 0] = 1.5;
            GeometricArray[8, 1] = 0;
            GeometricArray[8, 2] = 10.5;

            GeometricArray[7, 0] = 2.5;
            GeometricArray[7, 1] = 0;
            GeometricArray[7, 2] = 10.25;

            GeometricArray[6, 0] = 1.3;
            GeometricArray[6, 1] = 0;
            GeometricArray[6, 2] = 10;

            //Начало тела Слона
            GeometricArray[5, 0] = 1.2;
            GeometricArray[5, 1] = 0;
            GeometricArray[5, 2] = 7;

            GeometricArray[4, 0] = 1.6;
            GeometricArray[4, 1] = 0;
            GeometricArray[4, 2] = 4;
            //Начало ножки Слона
            GeometricArray[3, 0] = 4;
            GeometricArray[3, 1] = 0;
            GeometricArray[3, 2] = 2;

            GeometricArray[2, 0] = 2.5;
            GeometricArray[2, 1] = 0;
            GeometricArray[2, 2] = 0.5;

            GeometricArray[1, 0] = 3;
            GeometricArray[1, 1] = 0;
            GeometricArray[1, 2] = 0.25;

            GeometricArray[0, 0] = 0;
            GeometricArray[0, 1] = 0;
            GeometricArray[0, 2] = 0;

            // непосредственное заполнение точек


            // по умолчанию мы будем отрисовывать фигуру в режиме GL.POINTS
            comboBox1.SelectedIndex = 2;

            // построение геометрии тела вращения
            // принцип сводится к двум циклам: на основе первого перебираются
            // вершины в геометрической последовательности,
            // а второй использует параметр Iter и производит поворот последней линии геометрии вокруг центра тела вращения
            // при этом используется заранее определенный угол angle, который определяется как 2 * Pi / количество медиан объекта
            // за счет выполнения этого алгоритма получается набор вершин, описывающих оболочку тела вращения.
            // остается только соединить эти точки в режиме рисования примитивов для получения
            // визуализированного объекта
            // цикл по последовательности точек кривой, на основе которой будет построено тело вращения
            for (int ax = 0; ax < count_elements; ax++)
            {
                // цикла по медианам объекта, заранее определенным в программе
                for (int bx = 0; bx < MaxIter; bx++)
                {

                    // для всех (bx > 0) элементов алгоритма используется предыдущая построенная последовательность
                    // для ее поворота на установленный угол
                    if (bx > 0)
                    {
                        double new_x = ResultGeometric[ax, bx - 1, 0] * Math.Cos(Angle) - ResultGeometric[ax, bx - 1, 1] * Math.Sin(Angle);
                        double new_y = ResultGeometric[ax, bx - 1, 0] * Math.Sin(Angle) + ResultGeometric[ax, bx - 1, 1] * Math.Cos(Angle);
                        ResultGeometric[ax, bx, 0] = new_x;
                        ResultGeometric[ax, bx, 1] = new_y;
                        ResultGeometric[ax, bx, 2] = GeometricArray[ax, 2];
                    }
                    else
                    // для построения первой медианы мы используем начальную кривую,описывая ее нулевым значением угла поворота
                    {
                        double new_x = GeometricArray[ax, 0] * Math.Cos(0) - GeometricArray[ax, 1] * Math.Sin(0);
                        double new_y = GeometricArray[ax, 1] * Math.Sin(0) + GeometricArray[ax, 1] * Math.Cos(0);
                        ResultGeometric[ax, bx, 0] = new_x;
                        ResultGeometric[ax, bx, 1] = new_y;
                        ResultGeometric[ax, bx, 2] = GeometricArray[ax, 2];
                    }
                }
            }
        }

        private void Draw(bool change_rotation, bool flag_rotate)
        {
            // два параметра, которые мы будем использовать для непрерывного вращения сцены вокруг 2 координатных осей
            if (change_rotation)
            {
                rot_1++; rot_2++;
            }
            // очистка буферов цвета и глубины
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // поворот изображения
            GL.LoadIdentity();

            GL.Translate(0, 0, -70 + trackBar1.Value);

            if (flag_rotate)
            {
                GL.Rotate(rot_1 * (-1), 1, 0, 0);
                GL.Rotate(rot_2 * (-1), 0, 1, 0);
            }
            else
            {
                GL.Rotate(rot_1, 1, 0, 0);
                GL.Rotate(rot_2, 0, 1, 0);
            }

            // устанавливаем размер точек, равный 5
            GL.PointSize(5.0f);
            // условие switch определяет установленный режим отображения, на основе выбранного пункта элемента
            // comboBox, установленного в форме программы
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    // отображение в виде точек
                    {
                        // режим вывода геометрии - точки
                        GL.Begin(PrimitiveType.Points);
                        // выводим всю ранее просчитанную геометрию объекта
                        for (int ax = 0; ax < count_elements; ax++)
                        {
                            for (int bx = 0; bx < MaxIter; bx++)
                            {
                                // отрисовка точки
                                GL.Vertex3(ResultGeometric[ax, bx, 0], ResultGeometric[ax, bx, 1], ResultGeometric[ax, bx, 2]);
                            }
                        }
                        // завершаем режим рисования
                        GL.End();
                        break;
                    }
                case 1:
                    //отображение объекта в сеточном режиме, используя режим GL_LINES-STRIP
                    {
                        //устанавливаем режим отрисовки линиями (последовательность линий)
                        GL.Begin(PrimitiveType.LineStrip);
                        for (int ax = 0; ax < count_elements; ax++)
                        {
                            for (int bx = 0; bx < MaxIter; bx++)
                            {
                                GL.Vertex3(ResultGeometric[ax, bx, 0], ResultGeometric[ax, bx, 1], ResultGeometric[ax, bx, 2]);
                                GL.Vertex3(ResultGeometric[ax + 1, bx, 0], ResultGeometric[ax + 1, bx, 1], ResultGeometric[ax + 1, bx, 2]);
                                if (bx + 1 < MaxIter)
                                {
                                    GL.Vertex3(ResultGeometric[ax + 1, bx + 1, 0], ResultGeometric[ax + 1, bx + 1, 1], ResultGeometric[ax + 1, bx + 1, 2]);
                                }
                                else
                                {
                                    GL.Vertex3(ResultGeometric[ax + 1, 0, 0], ResultGeometric[ax + 1, 0, 1], ResultGeometric[ax + 1, 0, 2]);
                                }
                            }
                        }
                        GL.End();
                        break;
                    }
                case 2:
                    //отрисовка оболочки с расчетом нормалей для корректного затенения граней объекта
                    {
                        if (comboBox2.SelectedIndex > 0)
                            GL.Enable(EnableCap.Texture2D); // включаем режим наложения текстуры
                        GL.Color3(0.9f, 0.9f, 0.9f);
                        GL.PolygonMode(MaterialFace.FrontAndBack, mode);
                        GL.Begin(PrimitiveType.Quads); // задаем тип примитивов
                        //режим отрисовки полигонов состоящих из 4  вершин
                        for (int ax = 0; ax < count_elements; ax++)
                        {
                            for (int bx = 0; bx < MaxIter; bx++)
                            {
                                //вспомогательные переменные для более наглядного использования кода при расчете нормалей
                                double x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0, z1 = 0, z2 = 0, z3 = 0, z4 = 0;
                                //первая вершина
                                x1 = ResultGeometric[ax, bx, 0];
                                y1 = ResultGeometric[ax, bx, 1];
                                z1 = ResultGeometric[ax, bx, 2];
                                if (ax + 1 < count_elements)
                                //если текуший ax не последний
                                {
                                    //берем следующую точку последовательности
                                    x2 = ResultGeometric[ax + 1, bx, 0];
                                    y2 = ResultGeometric[ax + 1, bx, 1];
                                    z2 = ResultGeometric[ax + 1, bx, 2];
                                    if (bx + 1 < MaxIter)
                                    //если текущий bx не последний
                                    {
                                        //берем следующую точку послудовательности и следующий медиан
                                        x3 = ResultGeometric[ax + 1, bx + 1, 0];
                                        y3 = ResultGeometric[ax + 1, bx + 1, 1];
                                        z3 = ResultGeometric[ax + 1, bx + 1, 2];
                                        //точка, соответствующая по номеру, только на соседнем медиане
                                        x4 = ResultGeometric[ax, bx + 1, 0];
                                        y4 = ResultGeometric[ax, bx + 1, 1];
                                        z4 = ResultGeometric[ax, bx + 1, 2];
                                    }
                                    else
                                    {
                                        //если это последний медиан, то в качестве след. мы берем начальный (замыкаем геометрию фигуры)
                                        x3 = ResultGeometric[ax + 1, 0, 0];
                                        y3 = ResultGeometric[ax + 1, 0, 1];
                                        z3 = ResultGeometric[ax + 1, 0, 2];

                                        x4 = ResultGeometric[ax, 0, 0];
                                        y4 = ResultGeometric[ax, 0, 1];
                                        z4 = ResultGeometric[ax, 0, 2];
                                    }
                                }
                                else
                                //данный элемент ax последний, следовательно, мы будем использовать начальный (нулевой) всместо данного ax
                                {
                                    //следующий точкой будет нулевая ax
                                    x2 = ResultGeometric[0, bx, 0];
                                    y2 = ResultGeometric[0, bx, 1];
                                    z2 = ResultGeometric[0, bx, 2];
                                    if (bx + 1 < MaxIter)
                                    {
                                        x3 = ResultGeometric[0, bx + 1, 0];
                                        y3 = ResultGeometric[0, bx + 1, 1];
                                        z3 = ResultGeometric[0, bx + 1, 2];

                                        x4 = ResultGeometric[ax, bx + 1, 0];
                                        y4 = ResultGeometric[ax, bx + 1, 1];
                                        z4 = ResultGeometric[ax, bx + 1, 2];
                                    }
                                    else
                                    {
                                        x3 = ResultGeometric[0, 0, 0];
                                        y3 = ResultGeometric[0, 0, 1];
                                        z3 = ResultGeometric[0, 0, 2];

                                        x4 = ResultGeometric[ax, 0, 0];
                                        y4 = ResultGeometric[ax, 0, 1];
                                        z4 = ResultGeometric[ax, 0, 2];
                                    }
                                }
                                //переменные для расчета нормали
                                double n1 = 0, n2 = 0, n3 = 0;
                                //нормаль будем рассчитывать как векторное произведение граней полигона
                                //для нулевого элементаа нормаль мы будем считать немного по-дургому
                                //на самом деле разница в расчете нормали актуальна  только для первого и последнего полигона на медиане
                                if (ax == 0)
                                //при расчете нормали для ax мы будем использовать точки 1,2,3
                                {
                                    n1 = (y2 - y1) * (z3 - z1) - (y3 - y1) * (z2 - z1);
                                    n2 = (z2 - z1) * (x3 - x1) - (z3 - z1) * (x2 - x1);
                                    n3 = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);
                                }
                                else
                                //для остальных - 1,3,4
                                {
                                    n1 = (y4 - y3) * (z1 - z3) - (y1 - y3) * (z4 - z3);
                                    n2 = (z4 - z3) * (x1 - x3) - (z1 - z3) * (x4 - x3);
                                    n3 = (x4 - x3) * (y1 - y3) - (x1 - x3) * (y4 - y3);
                                }
                                //если не включен режим NORMILIZE, то мы должны в обязательном порядке
                                //произвести нормализацию вектора нормали перед тем как передать информацию о нормали
                                double n5 = (double)Math.Sqrt(n1 * n1 + n2 * n2 + n3 * n3);
                                n1 /= (n5 + 0.01);
                                n2 /= (n5 + 0.01);
                                n3 /= (n5 + 0.01);
                                //передам информацию о нормали 
                                GL.Normal3(-n1, -n2, -n3);
                                //передаем 4 вершины для отрисовки полигона
                                //Debug.WriteLine("TexCoords: {0}, {1}", bx, ax);
                                GL.TexCoord2((double)bx / MaxIter, (double)(ax) / MaxIter);
                                GL.Vertex3(x1, y1, z1);
                                GL.TexCoord2((double)bx / MaxIter, (double)(ax + 1) / MaxIter);
                                GL.Vertex3(x2, y2, z2);
                                GL.TexCoord2((double)(bx + 1) / MaxIter, (double)(ax + 1) / MaxIter);
                                GL.Vertex3(x3, y3, z3);
                                GL.TexCoord2((double)(bx + 1) / MaxIter, (double)(ax) / MaxIter);
                                GL.Vertex3(x4, y4, z4);
                            }
                        }
                        //завершаем выбранный режим рисования полигонов 
                        GL.End();
                        if (comboBox2.SelectedIndex > 0)
                            GL.Disable(EnableCap.Texture2D);
                        break;
                    }
            }
            //возвращаем сохраненную матрицу
            GL.PopMatrix();
            //завершаем рисование
            GL.Flush();
            //обновляем элемент AnT
            AnT.SwapBuffers();
        }

        private void AnT_MouseHover(object sender, EventArgs e)
        {
            RenderTimer.Start();
        }

        private void AnT_MouseLeave(object sender, EventArgs e)
        {
            RenderTimer.Stop();
        }
        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            RenderTimer.Start();
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            flagrotate = !flagrotate;
            Draw(true, flagrotate);
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value == 0)
            {
                trackBar2.Value = 1;
            }
            else
            {
                RenderTimer.Interval = 100 - trackBar2.Value;
            }

        }

        private void AnT_Resize(object sender, EventArgs e)
        {
            SetupViewport();
            AnT.Invalidate();
        }

        private void SetupViewport()
        {
            int w = AnT.Width;
            int h = AnT.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1, 1, -1, 1, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.Viewport(0, 0, w, h);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                case 1:
                    bitmap = (Bitmap)Resources.ResourceManager.GetObject("image5");
                    break;
            }
            image_height = bitmap.Height;
            image_width = bitmap.Width;
            GLTexture.LoadTexture(bitmap);
            Draw(false, flagrotate);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw(false, flagrotate);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Draw(false, flagrotate);
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw(true, flagrotate);
        }
    }
    class GLTexture
    {
        public static void LoadTexture(Bitmap bmp)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, data.Width, data.Height, 0,
            OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);
        }
    }
}
