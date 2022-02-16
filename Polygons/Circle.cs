using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
    class Circle : Shape
    {

        public Circle() { }

        public Circle(Point centre)
        {
            point = centre;
            isActive = false;
            isFake = false;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(_Pen, point.X - R, point.Y - R, R*2, R*2);
        }

        public override bool IsInside(int x, int y)
        {
            return (point.X-x)*(point.X - x) + (point.Y - y)*(point.Y - y) <= R*R;
        }
    }
}
