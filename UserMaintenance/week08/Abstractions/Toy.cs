using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week08.Abstractions
{
    public abstract class Toy : Label
    {
        public Toy()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Toy_Paint;
            Click += Toy_Click;
        }

        private void Toy_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"A játék típusa: {GetType().Name}");
        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected abstract void DrawImage(Graphics g);

        public virtual void MoveToy()
        {
            Left += 1;
        }
    }
}
