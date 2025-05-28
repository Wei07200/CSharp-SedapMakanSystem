using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 50;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = CornerRadius;

            // Ensure radius is not more than half the panel's width or height
            int maxRadius = Math.Min(this.Width, this.Height) / 2;
            radius = Math.Min(radius, maxRadius);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);
            }
        }
    }
}