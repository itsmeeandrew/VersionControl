using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstractions;
using week08.Entities;

namespace week08
{
    public partial class Form1 : Form
    {
        private Toy _nextToy;
        private List<Toy> _toys = new List<Toy>();
        
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set {
                _factory = value;
                DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy toy = Factory.CreateNew();
            toy.Left = -Width;
            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            int maxPosition = 0;
            foreach (Toy toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                {
                    maxPosition = toy.Left;
                }
            }

            if (maxPosition > 1000)
            {
                var oldestToy = _toys[0];
                mainPanel.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void carBtn_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void ballBtn_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory()
            {
                BallColor = button1.BackColor
            };
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
            {
                Controls.Remove(_nextToy);
            }

            _nextToy = Factory.CreateNew();
            _nextToy.Left = label1.Left + 50;
            Controls.Add(_nextToy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var colorPicker = new ColorDialog();

            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                button.BackColor = colorPicker.Color;
            }
        }
    }
}
