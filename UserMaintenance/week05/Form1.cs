using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week05.Entities;

namespace week05
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> ticks;
        List<PortfolioItem> portfolio = new List<PortfolioItem>();
        List<decimal> Nyereségek;
        public Form1()
        {
            InitializeComponent();
            ticks = context.Ticks.ToList();
            dataGridView1.DataSource = ticks;

            CreatePortfolio();

            Nyereségek = new List<decimal>();
            int intervalum = 30;
            DateTime kezdőDátum = (from x in ticks select x.TradingDay).Min();
            DateTime záróDátum = new DateTime(2016, 12, 30);
            TimeSpan z = záróDátum - kezdőDátum;
            for (int i = 0; i < z.Days - intervalum; i++)
            {
                decimal ny = GetPortfolioValue(kezdőDátum.AddDays(i + intervalum))
                           - GetPortfolioValue(kezdőDátum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            var nyereségekRendezve = (from x in Nyereségek
                                      orderby x
                                      select x)
                                        .ToList();
            MessageBox.Show(nyereségekRendezve[nyereségekRendezve.Count() / 5].ToString());
        }

        private void CreatePortfolio()
        {
            portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = portfolio;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (PortfolioItem item in portfolio)
            {
                var last = (from x in context.Ticks
                            where item.Index == x.Index.Trim()
                            && date <= x.TradingDay
                            select x).First();
                value += (decimal)last.Price * item.Volume;
            }

            return value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filename = sfd.FileName;
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.WriteLine("Időszak, Nyereség");
                    for (int i = 0; i < Nyereségek.Count; i++)
                    {
                        sw.WriteLine($"{i}, {Nyereségek[i]}");
                    }
                }
            }
        }
    }
}
