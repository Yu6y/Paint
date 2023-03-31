using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<Point> points;
        public Form1()
        {
            InitializeComponent();
            PB.Image = new Bitmap(PB.Width, PB.Height);
            g = Graphics.FromImage(PB.Image);
        }

        private void PB_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                points = new List<Point>();
                points.Add(e.Location);
            }
            
        }

        private void PB_MouseUp(object sender, MouseEventArgs e)
        {
            Pen myPen = new Pen(Color.Red, 3);
            if (e.Button == MouseButtons.Left) {
                points.Add(e.Location);
                if (radioButtonLine.Checked)
                {
                    //Pen myPen = new Pen(Color.Red, 3);
                    g.DrawLine(myPen, points.First(), e.Location);
                   
                }
                else if (radioButtonRectangle.Checked)
                {
                    g.DrawRectangle(myPen,
                                    Math.Min(points.First().X, points.Last().X),
                                    Math.Min(points.First().Y, points.Last().Y),
                                    Math.Abs(points.First().X - points.Last().X),
                                    Math.Abs(points.First().Y - points.Last().Y));
                   
                }
                else if (radioButtonElipse.Checked)
                {
                    g.DrawEllipse(myPen,
                                    Math.Min(points.First().X, points.Last().X),
                                    Math.Min(points.First().Y, points.Last().Y),
                                    Math.Abs(points.First().X - points.Last().X),
                                    Math.Abs(points.First().Y - points.Last().Y));
                   
                }
                else if (radioButtonCurve.Checked)
                {
                    g.DrawCurve(myPen, points.ToArray());
                    
                }
                PB.Refresh();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PB_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);
            }

        }
    }
}
