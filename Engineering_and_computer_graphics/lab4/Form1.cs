using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;

namespace Lab_4
{
    struct Vertex
    {
        public float x, y, z;
        public float nx, ny, nz;
    }


    public partial class Form1 : Form
    {
        float rotationAngle = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void AnT_Load(object sender, EventArgs e)
        {
            // настройка параметров OpenGL для визyализации
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Ccw);

            // запyск таймера
            RenderTimer.Start();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            DrawSurface();
            AnT.Invalidate();
        }


        private void SetupMaterial()
        {
            float[] m_diffuse = new float[] { 0.0f, 0.5f, 0.0f, 1 };
            float[] m_ambient = new float[] { 0.0f, 0.2f, 0.0f, 1 };
            float[] m_specular = new float[] { 0.3f, 0.0f, 0.0f, 1 };
            float m_shininess = 1;

            GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, m_diffuse);
            GL.Material(MaterialFace.Front, MaterialParameter.Ambient, m_ambient);

            GL.Material(MaterialFace.Front, MaterialParameter.Specular, m_specular);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, m_shininess);
        }


        private void SetuplLight()
        {
            // задаем характеристики источника света
            float[] lightDirection = new float[] { 2, 2, 2, 0 };

            float[] l_diffuse = new float[] { 0.5f, 0.5f, 0.5f, 1 };
            float[] l_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1 };
            float[] l_specular = new float[] { 0.5f, 0.05f, 0.5f, 1 };

            // устанавливаем характеристики источника света
            GL.Light(LightName.Light0, LightParameter.Position, lightDirection);
            GL.Light(LightName.Light0, LightParameter.Diffuse, l_diffuse);
            GL.Light(LightName.Light0, LightParameter.Ambient, l_ambient);
            GL.Light(LightName.Light0, LightParameter.Specular, l_specular);

            // включаем освещение
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
        }


        private void SetupCamera()
        {
            // скорость вращения
            float rotationSpeed = 1f;
            GL.LoadIdentity();

            // задаем позицию камеры

            float cameraPositionX = 12;
            float cameraPositionY = 12;
            float cameraPositionZ = 8;

            // вычисляем угол вращения
            rotationAngle = (rotationAngle + rotationSpeed) % 366;

            //устанавливаем камеру
            Matrix4 lookat = Matrix4.LookAt(cameraPositionX, cameraPositionY,
                cameraPositionZ, 0, 0, 0, 0, 0, 1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            GL.Rotate(rotationAngle, 0, 0, 1);
        }


        private void DrawSurface()
        {
            rotationAngle += 0.01f;


            int s_displaylist = 0;
            int s_columns = 50;
            int s_rows = 50;

            float s_xMin = -10;
            float s_xMax = 10;
            float s_yMin = -10;
            float s_yMax = 10;
            float ScaleKof = 0.8f;

            const float ZNEAR = 1f;
            const float ZFAR = 40;
            const float FIELD_OF_VIEW = 60;
            float aspect = (float)AnT.Width / (float)AnT.Height;
            CSinSurface pv = new CSinSurface();

            // очистка окна
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(0, 0, 0, 1);

            SetuplLight(); // настройка параметров освещения
            SetupMaterial(); // настройка свойств материала
            SetupCamera(); // настройка камеры

            // задание типа примитивов, используемых для отображения поверхности
            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
                    GL.PolygonMode(MaterialFace.Back, PolygonMode.Line);
                    break;
                case 2:
                    GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
                    GL.PolygonMode(MaterialFace.Back, PolygonMode.Fill);
                    break;
                case 0:
                    GL.PolygonMode(MaterialFace.Front, PolygonMode.Point);
                    GL.PolygonMode(MaterialFace.Back, PolygonMode.Point);
                    GL.PointSize(3);
                    break;
            }
            // настройка проекции
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 perspectiveMatrix =Matrix4.CreatePerspectiveFieldOfView
                (MathHelper.DegreesToRadians(FIELD_OF_VIEW), aspect,ZNEAR, ZFAR);

            GL.LoadMatrix(ref perspectiveMatrix);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.Scale(ScaleKof, ScaleKof, ScaleKof);


            if(s_displaylist == 0)
            {
                s_displaylist = GL.GenLists(1);
                GL.NewList(s_displaylist, ListMode.Compile);
                GL.Color3(255, 0, 0);

                // вычисляем шаг узлов сетки
                float dy = (s_yMax - s_yMin) / (s_rows - 1);
                float dx = (s_xMax - s_xMin) / (s_columns - 1);
                float y = s_yMin;

                for(int row = 0; row < s_rows - 1; ++row, y += dy)
                {
                    GL.Begin(PrimitiveType.TriangleStrip);
                    float x = s_xMin;
                    for(int column = 0; column < s_columns - 1;++column, x += dx)
                    {
                        // вычисляем параметры вершины в узлах пары соседних вершин
                        // ленты из треугольников
                        Vertex v0 = pv.CalculateVertex(x, y + dy);
                        Vertex v1 = pv.CalculateVertex(x, y);

                        // задаем нормаль и координаты вершины на четной позиции
                        GL.Normal3(v0.nx, v0.ny, v0.nz);
                        GL.Vertex3(v0.x, v0.y, v0.z);

                        // задаем нормаль и координаты вершины на нечетной позиции
                        GL.Normal3(v1.nx, v1.ny, v1.nz);
                        GL.Vertex3(v1.x, v1.y, v1.z);
                    }
                    GL.End();
                }
                GL.EndList();
                GL.CallList(s_displaylist);
                GL.Flush();
                AnT.SwapBuffers();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aaa");
        }
    }


    class CSinSurface
    {
        // фyнкция sinc=sin(x)/x
        public double Sinc(double x)
        {
            return 0.1 * x * x;
        }
        // представление поверхности в виде фyнкции F(x,y,z)=Ff(x,y) -z
        public double F(double x, double y, double z)
        {
            double f = Sinc(x);
            return f - z;
        }

        public Vertex CalculateVertex(double x, double y)
        {
            Vertex resault = new Vertex();
            // вычисляем значение координаты Z
            double z = Sinc(x);

            // "бесконечно малое" приращение аргyмента
            // для численного дифференцирования
            double delta = 1e-6;

            // вычисляем значение фyнкции в точке X,Y,Z
            float f = (float)F(x, y, z);
            // нормали к поверхности в точке (х, y, Zz)
            double dfdx = -(F(x + delta, y, z) - f) / delta;

            double dfdy = -(F(x, y + delta, z) - f) / delta;

            double dfdz = 1;

            // величина обратная длине ветора антиградиента

            double invLen = 1 / Math.Sqrt(dfdx * dfdx + dfdy * dfdy + dfdz * dfdz);
            // координаты вершины

            resault.x = (float)x; resault.y = (float)y; resault.z = (float)z;

            // приводим вектор нормали к единичной длине

            resault.nx = (float)(dfdx * invLen); resault.ny = (float)(dfdy * invLen);
            resault.nz = (float)(dfdz * invLen);
            return resault;
        }
    }
}
