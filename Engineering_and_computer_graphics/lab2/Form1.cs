using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace Lab_2
{

    public partial class Form1 : Form
    {
        // размеры окна
        double ScreenW, ScreenH;
        // отношения сторон окна визуализации
        // для корректного перевода координат мыши в координаты,
        // принятые в программе
        private float devX;
        private float devY;
        // массив, который будет хранить значения x,y точек графика
        private float[,] GrapValuesArray;
        // количество элементов в массиве
        private int elements_count = 0;
        // флаг, означающий, что массив с значениями координат графика пока еще незаполнен
        private bool not_calculate = true;
        // номер ячейки массива, из которой будут взяты координаты для красной точки,
        // для визуализации текущего кадра
        private int pointPosition = 0;
        // вспомогательные переменные для построения линий от курсора мыши к координатнымосям
        float lineX, lineY;
        // текущие координаты курсора мыши
        float Mcoord_X = 0, Mcoord_Y = 0;

        private void AnT_Load(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, AnT.Width, AnT.Height);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadIdentity();
            GL.Ortho(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            //Сохраняем кординаты мыши
            Mcoord_X = e.X;
            Mcoord_Y = e.Y;

            //Вычисляем параметры для будущей дорисовки линий от указателя мыши к 
            //координатным осям
            lineX = (float)(ScreenW / ScreenH) * devX * e.X;
            lineY = (float)(ScreenH - devY * e.Y * (float)(ScreenH / ScreenW));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Определение параметров настройки проекции, в зависимости от размеров сторон
            //элемента AnT
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 30.0;
                ScreenH = 30.0 * (float)AnT.Height / (float)AnT.Width;
                GL.Ortho(0.0, ScreenW, 0.0, ScreenH, -1, 1);
            }
            else
            {
                ScreenH = 30.0;
                ScreenW = 30.0 * (float)AnT.Width / (float)AnT.Height;
                GL.Ortho(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0, -1, 1);
            }
            //Сохранение коэффициентов, которые необходимы для перевода координат указателя в
            //оконной системе, в координаты принятые в нашей OpenGL сцене
            devX = (float)ScreenH / (float)AnT.Width;
            devY = (float)ScreenW / (float)AnT.Height;
            //установка объектно-видовой матрицы
            GL.MatrixMode(MatrixMode.Modelview);
            //Старт счетчика, отвечающего за вызов функции визуализации сцены
            PointInGrap.Start();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void PointInGrap_Tick(object sender, EventArgs e)
        {
            //Если мы дошли до последнего элемента в массиве
            if (pointPosition == elements_count - 1)
                pointPosition = 0;//Переходим к начальному элементу

            //Функция визуализации 
            Draw();
            //Переход к следующему элементу массива
            pointPosition++;
        }


        private void functionCalculation()
        {
            //Определение локальных переменных х и у
            float x = 0;
            float y = 0;
            //инициализация массива, который будет хранить значение 300 точек
            //из которых будет состоять график
            GrapValuesArray = new float[300, 2];
            //Счетчик элементов массива
            elements_count = 0;
            //Вычисление всех значений у, для х принадлежащего промежутку от -1 до 3
            //с шагом в 0.01f
            for (x = -15; x < 15; x += 0.1f)
            {
                //строка описывающая график функции y=f(x)
                y = x * x * (x - 2) * (x - 2);
                //Запись в массив координат
                GrapValuesArray[elements_count, 0] = x;
                GrapValuesArray[elements_count, 1] = y;

                //Подсчет элементов
                elements_count++;
            }
            //изменение флага, сигнализирующего о вычислении значений функции
            not_calculate = false;
        }


        private void DrawDiagram()
        {
            if (not_calculate)
                functionCalculation();

            //Стартует отрисовку в режиме визуализации точек объединяемых в линии
            GL.Begin(PrimitiveType.LineStrip);
            //Рисуем начальную точку 
            GL.Vertex2(GrapValuesArray[0, 0], GrapValuesArray[0, 1]);
            //Проходим по массиву с координатами вычисленных точек
            for (int ax = 1; ax < elements_count; ax += 2)
                GL.Vertex2(GrapValuesArray[ax, 0], GrapValuesArray[ax, 1]);
            //Завершаем режим рисования
            GL.End();

            //Устанавливаем размер точки, равный 5 пикселей
            GL.PointSize(5);
            //устанавливаем текущим цветом красный
            GL.Color3(Color.Red);
            //активируем режим вывода точек
            GL.Begin(PrimitiveType.Points);
            //выводим красную точку, используя ту ячейку массива, до которой мы дошли
            GL.Vertex2(GrapValuesArray[pointPosition, 0], GrapValuesArray[pointPosition, 1]);
            //Завершаем режим рисования 
            GL.End();
            //Устаналиваем размер точки в 1
            GL.PointSize(1);
        }


        private void Draw()
        {
            // Заливка окна вывода и очистка буфера глубины
            GL.ClearColor(Color.Bisque);
            //очистка буфера цвета и буфера глубины
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();// очищение текущей матрицы
            GL.Color3(0, 0, 0);// установка черного цвета
            GL.PushMatrix();// помещаем состояние матрицы в стек матриц
            GL.Translate(20, 15, 0);// выполняем перемещение в пространстве по осям X и У
            GL.Begin(PrimitiveType.Points);// активируем режим рисования

            //C помощью прохода двумя циклами, создаем сетку из точек
            for (float ax = -15; ax < 15; ax++)
                for (float bx = -15; bx < 15; bx++)
                    GL.Vertex2(ax, bx);// вывод точки
            //завершение режима рисования примитивов
            GL.End();
            // активируем режим рисования, каждые 2 последовательно вызванные команды Vertex
            //объединяются в линии
            GL.Begin(PrimitiveType.Lines);

            //И далее мы рисуем координатные оси и стрелки на их концах
            GL.Vertex2(0, -15);
            GL.Vertex2(0, 15);
            GL.Vertex2(-15, 0);
            GL.Vertex2(15, 0);
            // вертикальная стрелка
            GL.Vertex2(0, 15);
            GL.Vertex2(0.2, 14.5);
            GL.Vertex2(0, 15);
            GL.Vertex2(-0.2, 14.5);
            // горизонтальная стрелка
            GL.Vertex2(15, 0);
            GL.Vertex2(14.5, 0.2);
            GL.Vertex2(15, 0);
            GL.Vertex2(14.5, -0.2);
            // завершаем режим рисования
            GL.End();
            // вызываем функцию рисования графика
            DrawDiagram();
            // возвращаем матрицу из стека
            GL.PopMatrix();
            // устанавливаем красный цвет
            GL.Color3(Color.Red);
            // включаем режим рисования линий, для того чтобы нарисовать
            // линии OT курсора мыши к координатным осям
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(lineX, 15);
            GL.Vertex2(lineX, lineY);
            GL.Vertex2(20, lineY);
            GL.Vertex2(lineX, lineY);
            GL.End();
            // переключаем буфер вывода
            AnT.SwapBuffers();
        }
    }
}
