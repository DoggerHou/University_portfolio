using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {

        private float rot_1, rot_2;

        private const int Inter = 12;

        private double[,] GeometricArray = new double[Inter * Inter, 3];
        private double[,,] ResaultGeometric = new double[Inter * Inter, Inter * Inter, 3];
        private int count_elements = 0;

        private double Angle = 2 * Math.PI / Inter;


        private int k = 1;


        public Form1()
        {
            InitializeComponent();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void AnT_Load(object sender, EventArgs e)
        {
            // очистка окна
            GL.ClearColor(Color.White);
            // очистка буферов цвета и глубины
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // установка порта вывода в соответствии с размерами элемента АпТ
            GL.Viewport(0, 0, AnT.Width, AnT.Height);

            // настройка проекции
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Frustum(-0.1 * AnT.Width / AnT.Height, 0.1 * AnT.Width / AnT.Height,
                -0.1, 0.1, 0.1, 200);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // настройка параметров OpenGL для визуализации
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

            // количество элементов последовательности геометрии, на основе
            // которых будет строитьсятело вращения
            count_elements = Inter;

            // непосредственное заполнение точек

            //пимпочка

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



            // по умолчанию мы будем отрисовывать фигуру в режиме GL.POINTS
            comboBox1.SelectedIndex = 2;

            // построение геометрии тела вращения

            // принцип сводится к двум циклам: на основе первого перебираются
            // вершины в геометрической последовательности,
            // А второй использует параметр Iter и производит поворот последней линии
            //геометрии вокруг центра тела вращения

            // при этом используется заранее определенный угол angle, который
            //определяется как 2 * Pi / количество медиан объекта

            // за счет выполнения этого алгоритма получается набор вершин, описывающих
            //оболочку тела вращения.

            // остается только соединить эти точки в режиме рисования
            // примитивов для получения визуализированного объекта

            // цикл по последовательности точек кривой, на основе которой будет
            //построено тело вращения И цикла по медианам объекта, заранее определенным в программе
            for (int ax = 0; ax < count_elements; ax++)
            {
                // цикла по медианам объекта, заранее определенным в программе
                for (int bx = 0; bx < Inter; bx++)
                {

                    // для всех (bx > 0) элементов алгоритма используется предыдущая построенная последовательность
                    // для ее поворота на установленный угол
                    if (bx > 0)
                    {
                        double new_x = ResaultGeometric[ax, bx - 1, 0] * Math.Cos(Angle) - ResaultGeometric[ax, bx - 1, 1] * Math.Sin(Angle);
                        double new_y = ResaultGeometric[ax, bx - 1, 0] * Math.Sin(Angle) + ResaultGeometric[ax, bx - 1, 1] * Math.Cos(Angle);
                        ResaultGeometric[ax, bx, 0] = new_x;
                        ResaultGeometric[ax, bx, 1] = new_y;
                        ResaultGeometric[ax, bx, 2] = GeometricArray[ax, 2];
                    }
                    else
                    // для построения первой медианы мы используем начальную кривую,описывая ее нулевым значением угла поворота
                    {
                        double new_x = GeometricArray[ax, 0] * Math.Cos(0) - GeometricArray[ax, 1] * Math.Sin(0);
                        double new_y = GeometricArray[ax, 1] * Math.Sin(0) + GeometricArray[ax, 1] * Math.Cos(0);
                        ResaultGeometric[ax, bx, 0] = new_x;
                        ResaultGeometric[ax, bx, 1] = new_y;
                        ResaultGeometric[ax, bx, 2] = GeometricArray[ax, 2];
                    }
                }
            }
            // активация таймера
            RenderTimer.Start();
        }

        private void AnT_MouseEnter(object sender, EventArgs e)
        {
            RenderTimer.Start();
        }

        private void AnT_MouseLeave(object sender, EventArgs e)
        {
            RenderTimer.Stop();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value == 0)
                RenderTimer.Stop();
            else
            {
                RenderTimer.Interval = trackBar2.Value;
            }
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            rot_1 *= -1;
            rot_2 *= -1;
            k *= -1;

            GL.Rotate(rot_1, k, 0, 0);
            GL.Rotate(rot_2, 0, k, 0);
        }

        private void Draw()
        {
            //два параметра, которые мы будем использовать для непрерывного вращения
            //сцены вокруг 2 координатных осей
            rot_1++; rot_2++;

            //очистка буфера цвета и буфера глубины
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.White);
            //очищение текущей матрицы
            GL.LoadIdentity();

            //установка положения камеры(наблюдателя).Как видно из кода,
            //дополнительно на положение наблюдателя по оси &влияет значение,
            //установленное в ползунке, доступном для пользователя.

            //таким образом, при перемещении ползунка, наблюдатель будет отдаляться или
            //объекту наблюдения

            GL.Translate(0, 0, -20 - trackBar1.Value);

            //2 поворота(углы rot_1 и rot_2)
            GL.Rotate(rot_1, k, 0, 0);
            GL.Rotate(rot_2, 0, k, 0);
            //устанавливаем размер точек, равный 5
            GL.PointSize(5.0f);

            // условие switch определяет установленный режим отображения, Ha основе
            // выбранного пунктаэлемента comboBox, установленного в форме программы
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
                            for (int bx = 0; bx < Inter; bx++)
                            {
                                // отрисовка точки
                                GL.Vertex3(ResaultGeometric[ax, bx, 0],
                                    ResaultGeometric[ax, bx, 1],
                                    ResaultGeometric[ax, bx, 2]);
                            }
                        }
                        // завершаем режим рисования
                        GL.End();
                        break;
                    }
                case 1:
                    // отображение объекта в сеточном режиме, используя режим GL_LINES_STRIP
                    {
                        // устанавливаем режим отрисовки линиями (последовательность линий)
                        GL.Begin(PrimitiveType.LineStrip);
                        for (int ax = 0; ax < count_elements; ax++)
                        {
                            for (int bx = 0; bx < Inter; bx++)
                            {
                                GL.Vertex3(ResaultGeometric[ax, bx, 0], ResaultGeometric[ax, bx, 1], ResaultGeometric[ax, bx, 2]);
                                GL.Vertex3(ResaultGeometric[ax + 1, bx, 0], ResaultGeometric[ax + 1, bx, 1], ResaultGeometric[ax + 1, bx, 2]);
                                if (bx + 1 < Inter)
                                {
                                    GL.Vertex3(ResaultGeometric[ax + 1, bx + 1, 0], ResaultGeometric[ax + 1, bx + 1, 1], ResaultGeometric[ax + 1, bx + 1, 2]);
                                }
                                else
                                {
                                    GL.Vertex3(ResaultGeometric[ax + 1, 0, 0], ResaultGeometric[ax + 1, 0, 1], ResaultGeometric[ax + 1, 0, 2]);
                                }
                            }
                        }
                        GL.End();
                        break;
                    }
                case 2:
                    // отрисовка оболочки с расчетом нормалей для корректного затенения
                    //граней объекта
                    {
                        GL.Begin(PrimitiveType.Quads);
                        // режим отрисовки полигонов состоящих из 4 вершин
                        for (int ax = 0; ax < count_elements; ax++)
                        {
                            for (int bx = 0; bx < Inter; bx++)
                            {
                                // вспомогательные переменные для более наглядного
                                //использования кода при расчете нормалей
                                double x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0, z1 = 0, z2 = 0, z3 = 0, z4 = 0;
                                //первая вершина
                                x1 = ResaultGeometric[ax, bx, 0];
                                y1 = ResaultGeometric[ax, bx, 1];
                                z1 = ResaultGeometric[ax, bx, 2];
                                if (ax + 1 < count_elements)
                                // если текущий ax He последний
                                {
                                    //берем следующую точку последовательности
                                    x2 = ResaultGeometric[ax + 1, bx, 0];
                                    y2 = ResaultGeometric[ax + 1, bx, 1];
                                    z2 = ResaultGeometric[ax + 1, bx, 2];
                                    if (bx + 1 < Inter)
                                    //если текущий bx не последний
                                    {
                                        //берем следующую точку послудовательности и следующий медиан
                                        x3 = ResaultGeometric[ax + 1, bx + 1, 0];
                                        y3 = ResaultGeometric[ax + 1, bx + 1, 1];
                                        z3 = ResaultGeometric[ax + 1, bx + 1, 2];
                                        //точка, соответствующая по номеру, только на соседнем медиане
                                        x4 = ResaultGeometric[ax, bx + 1, 0];
                                        y4 = ResaultGeometric[ax, bx + 1, 1];
                                        z4 = ResaultGeometric[ax, bx + 1, 2];
                                    }
                                    else
                                    {
                                        //если это последний медиан, то в качестве след. мы берем начальный (замыкаем геометрию фигуры)
                                        x3 = ResaultGeometric[ax + 1, 0, 0];
                                        y3 = ResaultGeometric[ax + 1, 0, 1];
                                        z3 = ResaultGeometric[ax + 1, 0, 2];

                                        x4 = ResaultGeometric[ax, 0, 0];
                                        y4 = ResaultGeometric[ax, 0, 1];
                                        z4 = ResaultGeometric[ax, 0, 2];
                                    }
                                }
                                else
                                // данный элемент ах последний, следовательно, мы будем
                                //использовать начальный(нулевой) вместо данного ах
                                {
                                    // следующей точкой будет нулевая ах
                                    x2 = ResaultGeometric[0, bx, 0];
                                    y2 = ResaultGeometric[0, bx, 1];
                                    z2 = ResaultGeometric[0, bx, 2];
                                    if (bx + 1 < Inter)
                                    {
                                        x3 = ResaultGeometric[0, bx + 1, 0];
                                        y3 = ResaultGeometric[0, bx + 1, 1];
                                        z3 = ResaultGeometric[0, bx + 1, 2];

                                        x4 = ResaultGeometric[ax, bx + 1, 0];
                                        y4 = ResaultGeometric[ax, bx + 1, 1];
                                        z4 = ResaultGeometric[ax, bx + 1, 2];
                                    }
                                    else
                                    {
                                        x3 = ResaultGeometric[0, 0, 0];
                                        y3 = ResaultGeometric[0, 0, 1];
                                        z3 = ResaultGeometric[0, 0, 2];

                                        x4 = ResaultGeometric[ax, 0, 0];
                                        y4 = ResaultGeometric[ax, 0, 1];
                                        z4 = ResaultGeometric[ax, 0, 2];
                                    }
                                }

                                // переменные для расчета нормали
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
                                // если не включен режим NORMILIZE, то мы ДОЛЖНЫ B обязательном 
                                //порядке произвести нормализацию вектора нормали перед тем как
                                //передать информацию о нормали

                                double n5 = (double)Math.Sqrt(n1 * n1 + n2 * n2 + n3 * n3);
                                n1 /= (n5 + 0.01);
                                n2 /= (n5 + 0.01);
                                n3 /= (n5 + 0.01);
                                // передаем информацию о нормали
                                GL.Normal3(-n1, -n2, -n3);
                                // передаем 4 вершины для отрисовки полигона
                                GL.Vertex3(x1, y1, z1);
                                GL.Vertex3(x2, y2, z2);
                                GL.Vertex3(x3, y3, z3);
                                GL.Vertex3(x4, y4, z4);
                            }
                        }
                        // завершаем выбранный режим рисования полигонов
                        GL.End();
                        break;
                    }
            }
            // возвращаем сохраненную матрицу
            GL.PopMatrix();
            // завершаем рисование
            GL.Flush();
            // обновляем элемент AnT
            AnT.SwapBuffers();
        }
    }
}