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

namespace Subiect1
{
    public partial class ChartForm: Form
    {
        private AngajatRepository _angajatiRepository = new AngajatRepository();
        public ChartForm()
        {
            InitializeComponent();
            var angajati = _angajatiRepository.GetAngajati();

            var coduriManager = angajati.Where(angajat=> angajat.CodManager != null).Select(x => x.CodManager).Distinct();//am extras codurile de manager distincte
         
            var manageri = angajati.Where(x => coduriManager.Contains(x.Cod));//vedem la fiecare daca codul sau se afla in coduri manager, daca da ins ca e manager

            var nonManageri = angajati.Where(x => !manageri.Contains(x));
            /*
             * Select  DISTINCT CodManager from angajati WHERE CodManager!=null <-> echivalent cu angajati.Where(x => x.CodManager != null).Distinct()
             */

            var sumManageri = manageri.Sum(x => x.Salariu);
            var sumNonManageri = nonManageri.Sum(x => x.Salariu);
            angajatiChart.ChartAreas.Clear();
            angajatiChart.Series.Clear();
            var area = new ChartArea();
            area.Name = "PieChartArea";
            angajatiChart.ChartAreas.Add(area);

            var series = new Series();
            series.ChartArea = "PieChartArea";
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;

            series.Points.AddXY("Manageri", sumManageri);
            series.Points.AddXY("Non-manageri", sumNonManageri);
            angajatiChart.Series.Add(series);

            var area2 = new ChartArea();
            area2.Name = "DonutChartArea";
            angajatiChart.ChartAreas.Add(area2);

            var series2 = new Series();
            series.ChartArea = "DonutChartArea";
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = true;


            series2.Points.AddXY("Manageri", sumManageri);
            series2.Points.AddXY("Non-manageri", sumNonManageri);
            angajatiChart.Series.Add(series2);
        }
    }
}
