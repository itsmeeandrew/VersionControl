using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using week06.Entities;
using week06.MnbServiceReference;

namespace week06
{
    public partial class Form1 : Form
    {
        BindingList<RateData> rates = new BindingList<RateData>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = rates;
            chartRateData.DataSource = rates;
            string xmlData = getXmlData();
            processXml(xmlData);
            makeChart();
        }

        private void makeChart()
        {
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var ca = chartRateData.ChartAreas[0];
            var legend = chartRateData.Legends[0];

            legend.Enabled = false;

            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.Enabled = false;
            ca.AxisY.IsStartedFromZero = false;
        }

        private void processXml(string xmlData)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xmlData);

            foreach (XmlElement elem in xml.DocumentElement)
            {
                XmlElement firstChild = (XmlElement)elem.ChildNodes[0];
                rates.Add(new RateData()
                {
                    Date = DateTime.Parse(elem.GetAttribute("date")),
                    Currency = firstChild.GetAttribute("curr"),
                    Value = firstChild.GetAttribute("unit") == "0" ? 0 : decimal.Parse(firstChild.InnerText) / decimal.Parse(firstChild.GetAttribute("unit"))
                });
            }
        }

        private string getXmlData()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

            return result;
        }
    }
}
