using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint___CSharp
{
    public partial class Form1 : Form
    {
        //first we set the reference of graphics
        Graphics g;
        //initialize the co-ordinate of the cursor, -1 means not started
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, Convert.ToInt32(txtLineWidth.Text));
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //here come only pictureBox1, but the code will apply on all the picture boxes
            PictureBox PB = (PictureBox)sender;
            pen.Color = PB.BackColor;

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            //specific value targeted when mouse button is pressed
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x!=-1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                //we have to delete the old cordinates to draw line
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = y = -1;
            panel1.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float lineWidth = Convert.ToInt32(txtLineWidth.Text);
            pen = new Pen(Color.Black, lineWidth);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }
    }
}
