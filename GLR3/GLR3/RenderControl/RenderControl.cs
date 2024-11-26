using System;
using System.Drawing;
using System.Windows.Forms;

namespace GLR3
{
    public partial class RenderControl : OpenGL
    {
        private double Xmin = -10, Xmax = 10;
        private double Ymin, Ymax;
        private bool autoScale = true;
        private double step = 0.01; // Крок для побудови графіка

        public RenderControl()
        {
            InitializeComponent();
            Resize += (s, e) => Refresh();
        }

        public void SetInterval(double xmin, double xmax)
        {
            if (xmin >= xmax)
                throw new ArgumentException("Xmin має бути менше за Xmax!");
            Xmin = xmin;
            Xmax = xmax;

            if (autoScale)
                CalculateYBounds();
        }

        public void SetYBounds(double ymin, double ymax)
        {
            if (ymin >= ymax)
                throw new ArgumentException("Ymin має бути менше за Ymax!");
            Ymin = ymin;
            Ymax = ymax;
            autoScale = false;
        }

        public void EnableAutoScale(bool enable)
        {
            autoScale = enable;
            if (enable)
                CalculateYBounds();
        }

        private void CalculateYBounds()
        {
            double ymin = double.MaxValue, ymax = double.MinValue;

            for (double x = Xmin; x <= Xmax; x += step)
            {
                double y = Function(x);
                if (y < ymin) ymin = y;
                if (y > ymax) ymax = y;
            }

            Ymin = ymin - 1; // Трохи відступів для масштабу
            Ymax = ymax + 1;
        }

        private double Function(double x)
        {
            return Math.Tan(Math.Cos(2 * x)) + 0.5 * Math.Tan(Math.Cos(5 * x));
        }

        private void DrawAxes()
        {
            glColor3d(0.7, 0.7, 0.7);
            glBegin(GL_LINES);

            // X-Axis
            glVertex2d(Xmin, 0);
            glVertex2d(Xmax, 0);

            // Y-Axis
            glVertex2d(0, Ymin);
            glVertex2d(0, Ymax);

            glEnd();
        }

        private void DrawGrid()
        {
            glColor3d(0.9, 0.9, 0.9);
            glBegin(GL_LINES);

            for (double x = Math.Ceiling(Xmin); x <= Xmax; x++)
            {
                glVertex2d(x, Ymin);
                glVertex2d(x, Ymax);
            }

            for (double y = Math.Ceiling(Ymin); y <= Ymax; y++)
            {
                glVertex2d(Xmin, y);
                glVertex2d(Xmax, y);
            }

            glEnd();
        }

        private void DrawFunction()
        {
            glColor3d(0, 0, 1);
            glBegin(GL_LINE_STRIP);

            for (double x = Xmin; x <= Xmax; x += step)
            {
                double y = Function(x);
                glVertex2d(x, y);
            }

            glEnd();
        }

        private void DrawZeros()
        {
            glColor3d(1, 0, 0);
            glPointSize(5);

            glBegin(GL_POINTS);

            for (double x = Xmin; x <= Xmax; x += step)
            {
                double y = Function(x);
                if (Math.Abs(y) < 1e-2) // Умовно вважаємо нульовим
                {
                    glVertex2d(x, 0);
                }
            }

            glEnd();
        }

        private void OnRender(object sender, EventArgs e)
        {
            glClear(GL_COLOR_BUFFER_BIT);

            // Розрахунок ізотропного масштабу
            int viewportWidth = Width;
            int viewportHeight = Height;
            double aspect = (double)viewportWidth / viewportHeight;

            double xRange = Xmax - Xmin;
            double yRange = Ymax - Ymin;
            double xCenter = (Xmax + Xmin) / 2;
            double yCenter = (Ymax + Ymin) / 2;

            // Визначення масштабу для ізотропності
            if (xRange / yRange > aspect)
            {
                double newYRange = xRange / aspect;
                Ymin = yCenter - newYRange / 2;
                Ymax = yCenter + newYRange / 2;
            }
            else
            {
                double newXRange = yRange * aspect;
                Xmin = xCenter - newXRange / 2;
                Xmax = xCenter + newXRange / 2;
            }

            glViewport(0, 0, viewportWidth, viewportHeight);

            glMatrixMode(GL_PROJECTION);
            glLoadIdentity();
            gluOrtho2D(Xmin, Xmax, Ymin, Ymax);

            DrawGrid();
            DrawAxes();
            DrawFunction();
            DrawZeros();
        }
    }
}