﻿
namespace GLR2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.renderControl1 = new GLR2.RenderControl();
            this.SuspendLayout();
            // 
            // renderControl1
            // 
            this.renderControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderControl1.BackColor = System.Drawing.Color.SlateGray;
            this.renderControl1.ForeColor = System.Drawing.Color.White;
            this.renderControl1.Location = new System.Drawing.Point(12, 12);
            this.renderControl1.Name = "renderControl1";
            this.renderControl1.Size = new System.Drawing.Size(700, 314);
            this.renderControl1.TabIndex = 0;
            this.renderControl1.TextCodePage = 1251;
            this.renderControl1.Render += new System.EventHandler(this.OnRender);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 338);
            this.Controls.Add(this.renderControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private RenderControl renderControl1;
    }
}
