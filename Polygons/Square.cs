using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Polygons
{
    class Square : Shape
    {
        public int _A { 
            get 
            {
                return (int)(Math.Sqrt(2) * R);
            }
        }
        public Square() { }

        public Square(Point centre)
        {
            point = centre;
            isActive = false;
            isFake = false;
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(_Pen, point.X - _A/2, point.Y - _A / 2, _A, _A);
        } 

        public override bool IsInside(int x, int y)
        {
            return point.X - _A  / 2 <= x &&
                point.Y - _A / 2 <= y &&
                point.X + _A / 2 >= x &&
                point.Y + _A / 2 >= y;
        }
    }
}
