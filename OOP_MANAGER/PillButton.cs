using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace OOP
{
    public class PillButton : Button
    {
        public PillButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.ForeColor = Color.White;
            this.FlatAppearance.BorderSize = 0;

 
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, rect.Height, rect.Height, 90, 180);
            path.AddArc(rect.Width - rect.Height, rect.Y, rect.Height, rect.Height, 270, 180);
            path.CloseFigure();

            this.Region = new Region(path);

            // Draw the background
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                g.FillPath(brush, path);
            }
            using (var borderPen = new Pen(Color.FromArgb(44,63,115), 4))
            {
                pevent.Graphics.DrawPath(borderPen, path);
            }

            // Draw the text
            TextRenderer.DrawText(g, this.Text, this.Font, rect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}

