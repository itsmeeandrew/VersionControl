using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstractions;

namespace week08.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }
        private int verticalDirection = 1;
        private int verticalDelta = 0;
        public Ball(Color c)
        {
            BallColor = new SolidBrush(c);
            Click += Ball_Click;
        }

        private void Ball_Click(object sender, EventArgs e)
        {
            BallColor = new SolidBrush(Color.Gray);
            Invalidate();
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BallColor, 0, 0, Width, Height);
        }

        public override void MoveToy()
        {
            Left += 1;
            Top += verticalDirection;
            verticalDelta += verticalDirection;
            
            if (verticalDelta > 30)
            {
                verticalDirection *= -1;
            }

            if (verticalDelta < 0)
            {
                verticalDirection *= -1;
            }
            
        }
    }
}
