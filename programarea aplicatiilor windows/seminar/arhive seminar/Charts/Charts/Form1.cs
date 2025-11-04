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

namespace Charts {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            foreach (var company in FakeDatabase.Companies) {
                companiesListBox.Items.Add(company.Name);
            }
        }

        private void companiesListBox_SelectedIndexChanged(object sender, EventArgs e) {
            var listBox = (ListBox)sender;
            var companyName = listBox.SelectedItem.ToString();
            var companyId = FakeDatabase.Companies.First(x => x.Name == companyName).Id;
            var stocks = FakeDatabase.Stocks.Where(x => x.CompanyId == companyId).ToList();

            stocksChart.ChartAreas.Clear();
            stocksChart.Series.Clear();

            var area = new ChartArea();
            area.Name = "StocksArea";
            area.AxisX.LineColor = Color.LightGray;
            area.AxisY.LineColor = Color.LightGray;
            stocksChart.ChartAreas.Add(area);

            var series = new Series();
            stocksChart.Series.Add(series);
            stocksChart.Series[0].ChartType = SeriesChartType.Candlestick;
            stocksChart.Series[0].ChartArea = "StocksArea";
            stocksChart.Series[0]["PriceUpColor"] = "green";
            stocksChart.Series[0]["PriceDownColor"] = "red";
            stocksChart.Series[0].Color = Color.Blue;
            stocksChart.Series[0].BorderWidth = 3;
            foreach (var stock in stocks.OrderBy(x => x.Date)) {
                stocksChart.Series[0].Points.AddXY(stock.Date.ToString("dd.MM"),
                    stock.High, stock.Low, stock.Open, stock.Close);
            }

            var area2 = new ChartArea();
            area2.Name = "LineArea";
            area2.AxisX.LineColor = Color.LightGray;
            area2.AxisY.LineColor = Color.LightGray;
            stocksChart.ChartAreas.Add(area2);

            var series2 = new Series();
            stocksChart.Series.Add(series2);
            stocksChart.Series[1].ChartArea = "LineArea";
            stocksChart.Series[1].ChartType = SeriesChartType.Line;
            stocksChart.Series[1].Color = Color.Red;
            stocksChart.Series[1].BorderDashStyle = ChartDashStyle.Dash;
            stocksChart.Series[1].BorderWidth = 5;
            foreach (var stock in stocks.OrderBy(x=>x.Date)) {
                stocksChart.Series[1].Points.AddXY(stock.Date.ToString("dd.MM"), stock.High);
            }
        }
    }
}
