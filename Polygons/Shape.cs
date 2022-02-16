using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Polygons
{
    public abstract class Shape
    {
        private static int r;
        public static Pen _Pen {  get; set; }
        public Point point;
        public int deltaX { get; set; }
        public int deltaY { get; set; }
        public bool isActive;
        public bool isFake;
        public bool isShell { get; set; }

        static Shape()
        {
            R = 30;
            _Pen = new Pen(Color.FromName("Red"), 2);
        }

        public abstract void Draw(Graphics G);

        public abstract bool IsInside(int x, int y);

        public bool isInside { get; set; }

        public static int R
        {
            get
            {
                return r;
            }
            set
            {
                if (value > 0) r = value;
                else r = 10;
            }
        }

    }
}
