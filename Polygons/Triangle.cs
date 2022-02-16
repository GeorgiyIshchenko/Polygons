using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Polygons
{
    class Triangle : Shape
    {
        public int _A {
            get
            {
                return (int)(3 / Math.Sqrt(3) * R);
            }   
        }

        public Triangle() { }

        public Triangle(Point centre)
        {
            point = centre;
            isActive = false;
            isFake = false;
        }

        public override void Draw(Graphics g)
        {
            int r = R / 2;
            PointF[] points = { new PointF(point.X, point.Y - R), new PointF(point.X - _A / 2, point.Y + r), new PointF(point.X + _A / 2, point.Y + r) };
            g.DrawPolygon(_Pen, points);
        }

        public override bool IsInside(int x, int y)
        {
            Point p = new Point(x, y);
            int r = R / 2;
            Point[] coords = { new Point(point.X, point.Y - R), new Point(point.X - _A/2, point.Y + r), new Point(point.X + _A / 2, point.Y + r) };
            return Line.IsOnSameSide(coords[0], coords[1], coords[2], p) >= 0 && Line.IsOnSameSide(coords[2], coords[1], coords[0], p) >= 0 &&
                Line.IsOnSameSide(coords[0], coords[2], coords[1], p) >= 0;
        }
    }
}
