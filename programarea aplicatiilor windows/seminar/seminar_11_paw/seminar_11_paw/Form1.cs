using Charts;
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

namespace seminar_11_paw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach(var company in FakeDatabase.Companies)
            {
                companiesListBox.Items.Add(company.Name);
            }
        }
        private void companiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            var comapanyName = listBox.SelectedItem as string;
            //MessageBox.Show(comapanyName);
            var companyId = FakeDatabase.Companies.Single(c => c.Name == comapanyName).Id;
            var stocks = FakeDatabase.Stocks.Where(s => s.CompanyId == companyId).ToList();

            stocksChart.ChartAreas.Clear();
            stocksChart.Series.Clear();

            var area = new ChartArea();
            area.Name = "StocksArea";
            stocksChart.ChartAreas.Add(area);

            var series = new Series();
            series.ChartArea = "StocksArea";
            series.ChartType = SeriesChartType.Candlestick;
            series["PriceUpColor"] = "green";
            series["PriceDownColor"] = "red";
            series.Color = Color.Blue;
            series.BorderWidth = 4;

            stocksChart.Series.Add(series);

            foreach (var stock in stocks.OrderBy(x => x.Date))
            {
                stocksChart.Series[0].Points.AddXY(stock.Date.ToString("dd.MM"), stock.High, stock.Low, stock.Open, stock.Close);
            }

            var area2 = new ChartArea();
            area2.Name = "LineChart";
            stocksChart.ChartAreas.Add(area2);

            var series2 = new Series();
            series2.ChartArea = "LineChart";
            series2.ChartType = SeriesChartType.Line;
            series2.Color = Color.Green;
            series2.BorderWidth = 4;
            stocksChart.Series.Add(series2);

            foreach (var stock in stocks)
            {
                stocksChart.Series[1].Points.AddXY(stock.Date.ToString("dd.MM"), stock.Open);
            }
        }
    }
}
