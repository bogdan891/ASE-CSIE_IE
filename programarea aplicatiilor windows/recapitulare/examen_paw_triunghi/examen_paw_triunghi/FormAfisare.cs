using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_triunghi
{
    public partial class FormAfisare : Form
    {
        public FormAfisare()
        {
            InitializeComponent();
            this.Load += FormAfisare_Load;
        }

        private void FormAfisare_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Etichetă", 150);
                listView1.Columns.Add("CodFigura", 100);
            }

            listView1.Items.Clear();

            double perimetruTotal = 0;

            foreach (var t in FormPrincipal.ColectieTriunghiuri)
            {
                ListViewItem item = new ListViewItem(t.Eticheta);
                item.SubItems.Add(t.CodFigura.ToString());
                item.BackColor = t.Culoare;

                listView1.Items.Add(item);

                perimetruTotal += t.CalculPerimetru();
            }

            statusStrip1.Text = $"Perimetru total: {perimetruTotal:F2}";
        }
    }
}
