using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;

namespace GLR2
{
    public partial class RenderControl : OpenGL
    {
        public RenderControl()
        {
            InitializeComponent();
        }
        float a = 0.12f;
        private void OnRender(object sender, EventArgs e)
        {
            glClear(GL_COLOR_BUFFER_BIT);
            glClearColor(0.5f, 0.5f, 0.5f, 0f);
            glLoadIdentity();
            glViewport(-300, -300, Width, Width);

            DrawQuads();

            glPushMatrix();
            glTranslatef(a * 2, a * 2, 0);
            glRotatef(150, 0, 0, 1);
            glTranslatef(-a * 2, -a * 2, 0);
            DrawQuads();
            glPopMatrix();

            glPushMatrix();
            glColor3f(1, 1, 0);
            DrawTriangles();
            glPopMatrix();

            glPushMatrix();
            glColor3d(0, 0, 1);
            glTranslatef(a * 1.5f, a * 1.5f, 0);
            glRotatef(90, 0, 0, 1);
            glTranslatef(-a * 1.5f, -a * 1.5f, 0);
            DrawTriangles();
            glPopMatrix();

            glPushMatrix();
            glColor3f(1, 1, 0);
            glTranslatef(a * 2, a * 2, 0);
            glRotatef(150, 0, 0, 1);
            glTranslatef(-a * 2, -a * 2, 0);
            DrawTriangles();
            glPopMatrix();

            glPushMatrix();
            glColor3f(0, 0.7f, 0);
            glTranslatef(a * 2, a, 0);
            glRotatef(-60, 0, 0, 1);
            glTranslatef(-a * 2, -a, 0);
            DrawTriangles();
            glPopMatrix();
        }

        private void DrawQuads()
        {
            glBegin(GL_QUADS);
            glColor3f(1, 0, 0);
            glVertex2f(a, a);
            glVertex2f(2 * a, a);
            glVertex2f(2 * a, 2 * a);
            glVertex2f(a, 2 * a);
            glEnd();
        }

        private void DrawTriangles()
        {
            glBegin(GL_TRIANGLES);
            glVertex2f(a * 2, a * 2);
            glVertex2f(a * 2, a);
            glVertex2f(a * 2 + a * (float)Math.Sqrt(3) / 2, a * 1.5f);
            glEnd();
        }
    }
}

