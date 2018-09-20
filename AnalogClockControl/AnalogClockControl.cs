using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AnalogClockControl
{
    public partial class AnalogClockControl : UserControl
    {
        public AnalogClockControl()
        {
            InitializeComponent();
        }

        private void AnalogClockControl_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void AnalogClockControl_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void AnalogClockControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int faceRadius = Math.Min(
                ClientSize.Height,
                ClientSize.Width) / 2 - 10;

            DrawClockFace(g, faceRadius);

            DrawHands(g, faceRadius);
        }

        private double DegreeToRadian(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        private Point Center()
        {
            int x = ClientSize.Width / 2;
            int y = ClientSize.Height / 2;
            return new Point(x, y);
        }

        private Point PolarToCartesian(
            double r, double theta)
        {
            Point center = Center();
            int x = (int)(center.X + r * Math.Cos(theta));
            int y = (int)(center.Y - r * Math.Sin(theta));
            return new Point(x, y);
        }

        private void DrawClockFace(Graphics g, int faceRadius)
        {
            Point center = Center();
            int w = 2 * faceRadius;
            int h = w;
            int x = center.X - faceRadius;
            int y = center.Y - faceRadius;
            g.DrawEllipse(new Pen(Color.Blue, 3),
                x, y, w, h);

            // draw minute/second indicators
            int r1 = faceRadius;
            int r2 = (int)(0.92 * faceRadius);
            double thetaInterval = DegreeToRadian(6);
            DrawIndicators(g, new Pen(Color.Blue, 1.5f),
                r1, r2, thetaInterval);

            // draw hour indicators
            r1 = faceRadius;
            r2 = (int)(0.85 * faceRadius);
            thetaInterval = DegreeToRadian(30);
            DrawIndicators(g, new Pen(Color.Blue, 3),
                r1, r2, thetaInterval);
        }

        private void DrawIndicator(
            Graphics g, Pen pen,
            int r1, int r2, double theta)
        {
            Point p1 = PolarToCartesian(r1, theta);
            Point p2 = PolarToCartesian(r2, theta);
            g.DrawLine(pen, p1, p2);
        }

        private void DrawIndicators(
            Graphics g, Pen pen,
            int r1, int r2, double thetaInterval)
        {
            for (double theta = 0;
                theta < 2 * Math.PI;
                theta += thetaInterval)
            {
                DrawIndicator(g, pen, r1, r2, theta);
            }
        }

        private void DrawHand(
            Graphics g, Pen pen,
            int r, double theta)
        {
            Point p1 = Center();
            Point p2 = PolarToCartesian(r, theta);
            g.DrawLine(pen, p1, p2);
        }

        private void DrawHands(Graphics g, int faceRadius)
        {
            int h = DateTime.Now.Hour % 12;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            // hour hand
            int r = (int)(0.6 * faceRadius);
            double theta = 90 - 30 * h - 0.5 * m
                - (1 / 120) * s;
            theta = DegreeToRadian(theta);
            DrawHand(g, new Pen(Color.Black, 3),
                r, theta);

            // minute hand
            r = (int)(0.7 * faceRadius);
            theta = 90 - 6 * m - 0.1 * s;
            theta = DegreeToRadian(theta);
            DrawHand(g, new Pen(Color.Black, 2),
                r, theta);

            // second hand
            r = (int)(0.8 * faceRadius);
            theta = 90 - 6 * s;
            theta = DegreeToRadian(theta);
            DrawHand(g, new Pen(Color.Red, 1),
                r, theta);
        }

        public string TimeZone { get; set; }

    }
}
