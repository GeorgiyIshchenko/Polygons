using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
    public class RadiusEventArgs : EventArgs
    {

        public int Radius { get; }

        public RadiusEventArgs(int value):base()
        {
            Radius = value;
        }

    }

    public delegate void RadiusEventHandler(object sender, RadiusEventArgs e);

}
