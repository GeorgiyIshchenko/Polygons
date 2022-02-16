using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Polygons
{
    static class Line
    {
        public static int IsOnSameSide(Point p01, Point p02, Point p1, Point p2)
        {
            if(p01.X - p02.X == 0)
            {
                return 0;
            }
            double k = (double)(p01.Y - p02.Y) / (p01.X - p02.X);
            double b = (double)p01.Y - k * p01.X;
            return (int)Math.Sign((p1.Y - p1.X * k - b) * (p2.Y - p2.X * k - b));
        }

        
    }
}
