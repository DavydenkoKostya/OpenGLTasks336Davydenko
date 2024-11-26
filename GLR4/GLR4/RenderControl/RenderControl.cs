using System;
using System.Drawing;

namespace GLR4
{
    public partial class RenderControl : OpenGL
    {
        public RenderControl()
        {
            InitializeComponent();
        }

        private void DrawCircle(float radius)
        {
            glBegin(GL_LINE_LOOP);
            for (int i = 0; i <= 360; i++)
            {
                float angle = (float)(i * Math.PI / 180);
                float x = radius * (float)Math.Cos(angle);
                float y = radius * (float)Math.Sin(angle);
                glVertex2f(x, y);
            }
            glEnd();
        }

        private void DrawEllipse(float a, float b)
        {
            glBegin(GL_LINE_LOOP);
            for (int i = 0; i <= 360; i++)
            {
                float angle = (float)(i * Math.PI / 180);
                float x = a * (float)Math.Cos(angle);
                float y = b * (float)Math.Sin(angle);
                glVertex2f(x, y);
            }
            glEnd();
        }

        private void DrawParabola(float a)
        {
            glBegin(GL_LINE_STRIP);
            for (float x = -1.0f; x <= 1.0f; x += 0.01f)
            {
                float y = a * x * x;
                glVertex2f(x, y);
            }
            glEnd();
        }

        private void DrawHyperbola(float a, float b)
        {
            glBegin(GL_LINE_STRIP);
            for (float x = -1.0f; x <= -0.1f; x += 0.01f)
            {
                float y = (float)Math.Sqrt((x * x / (a * a)) - 1) * b;
                glVertex2f(x, y);
            }
            glEnd();

            glBegin(GL_LINE_STRIP);
            for (float x = 0.1f; x <= 1.0f; x += 0.01f)
            {
                float y = (float)Math.Sqrt((x * x / (a * a)) - 1) * b;
                glVertex2f(x, y);
            }
            glEnd();
        }
        private void DrawGrid()
        {
            glColor3f(0.7f, 0.7f, 0.7f); // Сірий колір сітки
            glBegin(GL_LINES);

            // Вертикальні лінії
            for (float x = -1.0f; x <= 1.0f; x += 0.1f)
            {
                glVertex2f(x, -1.0f);
                glVertex2f(x, 1.0f);
            }

            // Горизонтальні лінії
            for (float y = -1.0f; y <= 1.0f; y += 0.1f)
            {
                glVertex2f(-1.0f, y);
                glVertex2f(1.0f, y);
            }

            glEnd();

            // Малювання осей координат
            glColor3f(0.0f, 0.0f, 0.0f); // Чорний колір
            glBegin(GL_LINES);

            // Вісь X
            glVertex2f(-1.0f, 0.0f);
            glVertex2f(1.0f, 0.0f);

            // Вісь Y
            glVertex2f(0.0f, -1.0f);
            glVertex2f(0.0f, 1.0f);

            glEnd();
        }

        private void OnRender(object sender, EventArgs e)
        {
            // Отримання розмірів області малювання
            int width = this.Width;
            int height = this.Height;

            // Налаштування Viewport
            glViewport(0, 0, width, height);

            // Очищення екрану
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
            glLoadIdentity();

            // Ізотропне масштабування
            if (width <= height)
            {
                float aspect = (float)height / width;
                glOrtho(-1.0, 1.0, -aspect, aspect, -1.0, 1.0);
            }
            else
            {
                float aspect = (float)width / height;
                glOrtho(-aspect, aspect, -1.0, 1.0, -1.0, 1.0);
            }

            // Відображення координатної сітки
            DrawGrid();

            // Відображення кривих
            glColor3f(1, 0, 0); // Червона окружність
            DrawCircle(0.5f);

            glColor3f(0, 1, 0); // Зелений еліпс
            DrawEllipse(0.7f, 0.4f);

            glColor3f(0, 0, 1); // Синя парабола
            DrawParabola(1.0f);

            glColor3f(1, 1, 0); // Жовта гіпербола
            DrawHyperbola(0.5f, 0.3f);
        }
    }
}