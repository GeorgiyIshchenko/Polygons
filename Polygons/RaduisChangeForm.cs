using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygons
{
    public partial class RaduisChangeForm : Form
    {

        public RadiusEventHandler RadiusChage;

        public RaduisChangeForm()
        {
            InitializeComponent();
            trackBar1.Value = Shape.R;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int value = trackBar1.Value;
            if (RadiusChage != null)
                RadiusChage(trackBar1, new RadiusEventArgs(value));
        }
    }
}
