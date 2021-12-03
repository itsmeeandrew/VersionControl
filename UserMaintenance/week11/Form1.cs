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
using week11.Entities;

namespace week11
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        List<int> malePopulation = new List<int>();
        List<int> femalePopulation = new List<int>();

        Random rnd = new Random(42);
        public Form1()
        {
            InitializeComponent();
            
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
        }

        private void Simulation()
        {
            malePopulation.Clear();
            femalePopulation.Clear();
            richTextBoxLog.Clear();
            try
            {
                Population = GetPopulation(textBoxPopulationFilePath.Text);
            }
            catch
            {
                return;
            }

            decimal lastYear = nudLastYear.Value;
            for (int year = 2005; year <= 2024; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int numberOfMales = (from x in Population
                                     where x.Gender == Gender.Male && x.IsAlive
                                     select x).Count();
                malePopulation.Add(numberOfMales);

                int numberOfFemales = (from x in Population
                                       where x.Gender == Gender.Female && x.IsAlive
                                       select x).Count();
                femalePopulation.Add(numberOfFemales);
            }

            DisplayResults();
        }

        private void SimStep(int year, Person person)
        {
            if (!person.IsAlive) return;

            int age = year - person.BirthYear;
            double deathProbability = (from x in DeathProbabilities
                                    where age == x.Age && person.Gender == x.Gender
                                    select x.Probability).FirstOrDefault();

            if (rnd.NextDouble() <= deathProbability) person.IsAlive = false;

            if (person.Gender == Gender.Female && person.IsAlive)
            {
                double birthProbability = (from x in BirthProbabilities
                                        where x.Age == age && x.NumberOfChildren == person.NumberOfChildren
                                        select x.Probability).FirstOrDefault();

                if (rnd.NextDouble() <= birthProbability)
                {
                    Person newborn = new Person()
                    {
                        BirthYear = year,
                        NumberOfChildren = 0,
                        Gender = (Gender)rnd.Next(1, 3)
                    };
                    Population.Add(newborn);
                }
            }
        }

        public List<Person> GetPopulation(string path)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');

                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NumberOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<BirthProbability> GetBirthProbabilities(string path)
        {
            List<BirthProbability> birthProbabilities = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');

                    birthProbabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NumberOfChildren = int.Parse(line[1]),
                        Probability = double.Parse(line[2])
                    });
                }
            }

            return birthProbabilities;
        }

        public List<DeathProbability> GetDeathProbabilities(string path)
        {
            List<DeathProbability> deathProbabilities = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');

                    deathProbabilities.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        Probability = double.Parse(line[2])
                    });
                }
            }

            return deathProbabilities;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Simulation();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxPopulationFilePath.Text = ofd.FileName;
            }
        }

        private void DisplayResults()
        {
            for (int i = 0; i < malePopulation.Count; i++)
            {
                string log = string.Format("Szimulációs év: {0} \n" +
                    "\tFiúk: {1} \n" +
                    "\tLányok: {2} \n\n", 2005 + i, malePopulation[i], femalePopulation[i]);
                richTextBoxLog.Text += log;
            }
        }
    }
}
