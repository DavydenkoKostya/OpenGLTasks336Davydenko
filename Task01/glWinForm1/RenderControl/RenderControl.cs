using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;

namespace glWinForm1
{
    public partial class RenderControl : OpenGL
    {
        public RenderControl()
        {
            InitializeComponent();
        }
        private void CoordinateSystem(object sender, EventArgs e)
        {
            glClearColor(0.95f, 0.95f, 0.95f, 0f);
            glClear(GL_COLOR_BUFFER_BIT);
            glLoadIdentity();
            glViewport(0, 0, Width, Height);
            gluOrtho2D(-0.1, +1, -0.1, +0.6);

            DrawGrid();
            DrawAxes();
            DrawPointsFigure();
            DrawLineStripFigure();
        }

        private void DrawGrid()
        {
            glEnable(GL_LINE_STIPPLE);
            glLineStipple(1, 0x00FF);
            glColor3f(0.7f, 0.7f, 0.7f);
            glLineWidth(2);

            for (int i = 1; i < 11; ++i)
            {
                DrawLine(0, 0.1f * i, 1, 0.1f * i);
            }

            for (int i = 1; i < 11; ++i)
            {
                DrawLine(0.1f * i, 1, 0.1f * i, 0);
            }
            glDisable(GL_LINE_STIPPLE);
        }

        private void DrawAxes()
        {
            glLineWidth(1);
            glColor3i(0, 0, 0);
            DrawLine(-0.1f, 0, 1, 0);
            DrawLine(0, -0.1f, 0, 1);

            for (int i = 1; i < 11; ++i)
            {
                DrawLine(0.1f * i, -0.03f, 0.1f * i, 0);
            }

            for (int i = 1; i < 11; ++i)
            {
                DrawLine(-0.03f, 0.1f * i, 0f, 0.1f * i);
            }
        }

        private void DrawLine(float x1, float y1, float x2, float y2)
        {
            glBegin(GL_LINES);
            glVertex2f(x1, y1);
            glVertex2f(x2, y2);
            glEnd();
        }

        private void DrawLineStripFigure()
        {
            glEnable(GL_LINE_STRIP);
            glLineWidth(2);
            glColor3f(0, 0, 0);

            glBegin(GL_LINE_STRIP);
            glVertex2d(0.2, 0.2);
            glVertex2d(0.3, 0.1);
            glVertex2d(0.4, 0.2);
            glVertex2d(0.3, 0.4);
            glVertex2d(0.2, 0.5);
            glVertex2d(0.1, 0.4);
            glVertex2d(0.2, 0.2);
            glEnd();
        }

        private void DrawPointsFigure()
        {
            glEnable(GL_POINTS);
            glPointSize(7);
            glColor3f(0, 0, 0);

            glBegin(GL_POINTS);
            glVertex2d(0.7, 0.2);
            glVertex2d(0.8, 0.1);
            glVertex2d(0.9, 0.2);
            glVertex2d(0.6, 0.4);
            glVertex2d(0.7, 0.5);
            glVertex2d(0.8, 0.4);
            glEnd();
        }
    }
}