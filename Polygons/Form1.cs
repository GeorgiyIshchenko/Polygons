using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Polygons

{

    public partial class Form1 : Form
    {
        RaduisChangeForm raduisChangeForm;

        List<Shape> shapes = new List<Shape>();
        Graphics g;
        bool isInsideShell = false;


        public enum ShapeType
        {
            Треугольник,
            Круг,
            Квадрат,
        }
        ShapeType selectedShapeType = ShapeType.Круг;
        public enum Mode
        {
            Common,
            Jarvis,
            Schedule
        }
        Mode mode = Mode.Jarvis;

        public Form1()
        {
            InitializeComponent();
            chart1.Visible = false;
            mode = Mode.Jarvis;
            jarvisToolStripMenuItem.Checked = true;
            progressBar1.Visible = false;
        }

        public void onRadiusChanged(object sender, RadiusEventArgs e)
        {
            Shape.R = e.Radius;
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool flag = true;
                foreach (Shape s in shapes)
                {
                    if (s.IsInside(e.X, e.Y))
                    {
                        isInsideShell = false;
                        s.isInside = true;
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    if (shapes.Count >= 3)
                    {
                        isInsideShell = true;
                        Point p1 = new Point(e.X, e.Y);
                        for (int j = 0; j < shapes.Count; j++)
                        {
                            Point p2 = shapes[j].point;
                            if (CheckSide(p1, p2) && shapes.Count > 2)
                            {
                                isInsideShell = false;
                            }
                        }
                    }
                    if (!isInsideShell)
                    {
                        switch (selectedShapeType)
                        {
                            case ShapeType.Круг:
                                shapes.Add(new Circle(new Point(e.X, e.Y)));
                                break;
                            case ShapeType.Квадрат:
                                shapes.Add(new Square(new Point(e.X, e.Y)));
                                break;
                            case ShapeType.Треугольник:
                                shapes.Add(new Triangle(new Point(e.X, e.Y)));
                                break;
                        }
                    }               
                    Refresh();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                int i = 0, res = 0;
                bool flag = false;
                foreach (Shape s in shapes)
                {
                    if (s.IsInside(e.X, e.Y))
                    {
                        res = i;
                        flag = true;
                    }
                    i++;
                }
                if (flag) shapes.RemoveAt(res);
                Refresh();
            }


            foreach (Shape s in shapes)
            {
                if (s.IsInside(e.X, e.Y) || isInsideShell)
                {
                    s.isInside = true;
                    s.isActive = true;
                    s.deltaX = e.X - s.point.X;
                    s.deltaY = e.Y - s.point.Y;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isInsideShell = false;
            foreach (Shape s in shapes)
            {
                s.isInside = false;
                s.isActive = false;
            }
            if (shapes.Count > 3)
            {
                for (int i = 0; i < shapes.Count;)
                {
                    if (!shapes[i].isShell)
                    {
                        shapes.RemoveAt(i);
                        Refresh();
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Shape s in shapes)
            {
                if ((s.isActive && s.isInside) || isInsideShell)
                {
                    s.point.X = e.X - s.deltaX;
                    s.point.Y = e.Y - s.deltaY;
                    Refresh();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            selectedShapeType = ShapeType.Круг;
        }

        List<Shape> common(Graphics g, List<Shape> shapes)
        {
            foreach (Shape s in shapes) s.isShell = false;
            for (int i = 0; i < shapes.Count; i++)
            {
                Point p1 = shapes[i].point;
                for (int j = i + 1; j < shapes.Count; j++)
                {
                    Point p2 = shapes[j].point;
                    if (CheckSide(p1, p2) && shapes.Count > 2)
                    {
                        shapes[i].isShell = true;
                        shapes[j].isShell = true;
                        if (g != null) g.DrawLine(new Pen(Color.Blue, 2), p1, p2);
                    }
                }
            }
            return shapes;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (mode == Mode.Common)
            {
                g = e.Graphics;
                shapes = common(g, shapes);
                foreach (Shape s in shapes) s.Draw(g);
            }
            else if (mode == Mode.Jarvis)
            {
                g = e.Graphics;
                foreach (Shape s in shapes) s.isShell = false;
                if (shapes.Count > 2) shapes = garvis(g, shapes);
                foreach (Shape s in shapes) s.Draw(g);
            }
            else if (mode == Mode.Schedule)
            {

            }
        }

        bool CheckSide(Point p1, Point p2)
        {
            bool flag = true;
            int mainStatus = 404;
            if (p1.X == p2.X)
            {
                for (int _ = 0; _ < shapes.Count; _++)
                {
                    Point p3 = shapes[_].point;
                    if (p1 != p3 && p2 != p3)
                    {
                        int status = (int)Math.Sign(p3.X - p1.X);
                        if (mainStatus == 404)
                        {
                            // если статус = 1, то точка над прямой
                            mainStatus = status;
                        }
                        else if (mainStatus != status)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int _ = 0; _ < shapes.Count; _++)
                {
                    Point p3 = shapes[_].point;
                    Point fakePoint = new Point(p1.X, p1.Y + 1);
                    if (p1 != p3 && p2 != p3)
                    {
                        int status = Line.IsOnSameSide(p1, p2, p3, fakePoint);
                        if (mainStatus == 404)
                        {
                            // если статус = 1, то точка над прямой
                            mainStatus = status;
                        }
                        else if (mainStatus != status)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            return flag;
        }


        double getCosAnge(Point[] points)
        {
            // points[1] - вершина угла BAC
            if (points.Length != 3) return 0;
            double[] sides = new double[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                Point p1 = points[i], p2 = points[(i + 1) % 3];
                sides[i] = Math.Sqrt((p1.Y - p2.Y) * (p1.Y - p2.Y) + (p1.X - p2.X) * (p1.X - p2.X));
            }
            // 0 - AB, 1 - AC, 2 - BC
            return (sides[2] * sides[2] - sides[0] * sides[0] - sides[1] * sides[1]) / (2 * sides[0] * sides[1]);
        }

        Pen shellPen = new Pen(Color.Black, 2);

        Shape c = null;

        List<Shape> garvis(Graphics g, List<Shape> gshapes)
        {

            Shape first = gshapes[0];
            foreach (Shape s in gshapes)
            {
                if (first.point.Y < s.point.Y) first = s;
            }
            Point a = first.point, b = a;

            b.X -= 100;
            double maxCosAngle, cosAngle;
            do
            {
                maxCosAngle = -1;
                foreach (Shape s in gshapes)
                {
                    if (s.point != a && s.point != b)
                    {

                        Point[] points = { b, a, s.point };
                        cosAngle = getCosAnge(points);
                        if (cosAngle > maxCosAngle)
                        {
                            maxCosAngle = cosAngle;
                            c = s;
                        }
                    }
                }
                c.isShell = true;
                if (g != null) g.DrawLine(
                    shellPen, a, c.point);
                b = a;
                a = c.point;
            }
            while (c.point != first.point);
            return gshapes;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectedShapeType = (ShapeType)Enum.Parse(typeof(ShapeType), e.ToString());
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.Checked = false;
            }
        }   

        void clearMenu()
        {
            кругToolStripMenuItem.Checked = false;
            квадратToolStripMenuItem.Checked = false;
            треугольникToolStripMenuItem.Checked = false;
            сравнениеToolStripMenuItem.Checked = false;
            commonToolStripMenuItem.Checked = false;
            jarvisToolStripMenuItem.Checked = false;
        }

        private void кругToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShapeType = ShapeType.Круг;
            clearMenu();
            кругToolStripMenuItem.Checked = true;
        }
        

        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShapeType = ShapeType.Квадрат;
            clearMenu();
            квадратToolStripMenuItem.Checked = true;
        }

        private void треугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedShapeType = ShapeType.Треугольник;
            clearMenu();
            треугольникToolStripMenuItem.Checked = true;
        }

        private void фигураToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void commonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            chart1.Series.Clear();
            mode = Mode.Common;
            clearMenu();
            commonToolStripMenuItem.Checked = true;
            Refresh();
        }

        private void jarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            chart1.Series.Clear();
            mode = Mode.Jarvis;
            clearMenu();
            jarvisToolStripMenuItem.Checked = true;
            Refresh();
        }

        private void сравнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = Mode.Schedule;
            clearMenu();
            сравнениеToolStripMenuItem.Checked = true;
            chart1.Visible = true;
            progressBar1.Visible = true;

            Stopwatch stopwatch = new Stopwatch();
            Random random = new Random(1);
            int pointSize = 1500;
            progressBar1.Maximum = pointSize*2;
            int step = 100;

            List<Shape> fakeShapes = new List<Shape>();
            List<double> timeCommon = new List<double>();
            List<double> timeJarvis = new List<double>();

            Series commonSeries = new Series("По умолчанию");
            commonSeries.ChartType = SeriesChartType.Line;

            Series jarvisSeries = new Series("Джарвис");
            jarvisSeries.ChartType = SeriesChartType.Line;

            Point point;
            Square square;

            for (int i = 0; i < pointSize; i++)
            {
                point = new Point(random.Next(2, this.Width), random.Next(1, this.Height));
                square = new Square(point);
                fakeShapes.Add(square);
            }

            List<Shape> fakeShapesCopy;

            for (int cnt = step; cnt <= pointSize; cnt += step)
            {
                fakeShapesCopy = fakeShapes;
                progressBar1.Value += step;
                stopwatch.Start();
                garvis(null, fakeShapesCopy.GetRange(0, cnt));
                stopwatch.Stop();
                timeJarvis.Add(stopwatch.Elapsed.Milliseconds);
                stopwatch.Reset();
            }

            for (int cnt = step; cnt <= pointSize; cnt+=step)
            {
                fakeShapesCopy = fakeShapes;
                progressBar1.Value+=step;
                stopwatch.Start();
                common(null, fakeShapesCopy.GetRange(0, cnt));
                stopwatch.Stop();
                timeCommon.Add(stopwatch.Elapsed.Milliseconds);
                stopwatch.Reset();
            }

            

            progressBar1.Visible = false;

            for (int i = 0; i < timeCommon.Count; i++)
            {
                commonSeries.Points.AddXY(i * step, timeCommon[i]);
                jarvisSeries.Points.AddXY(i * step, timeJarvis[i]);
            }

            chart1.Series.Add(commonSeries);
            chart1.Series.Add(jarvisSeries);
        }

        

        private void радиусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (raduisChangeForm == null || raduisChangeForm.IsDisposed)
                raduisChangeForm = new RaduisChangeForm();
            raduisChangeForm.RadiusChage += onRadiusChanged;
            raduisChangeForm.Show();
            raduisChangeForm.WindowState = FormWindowState.Normal;
            raduisChangeForm.BringToFront();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowHelp = true;
            MyDialog.Color = Shape._Pen.Color;


            if (MyDialog.ShowDialog() == DialogResult.OK)
                Shape._Pen.Color = MyDialog.Color;
                Refresh();
        }
    }
}
