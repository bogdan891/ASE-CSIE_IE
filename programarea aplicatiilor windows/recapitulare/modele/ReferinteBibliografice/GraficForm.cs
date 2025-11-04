using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReferinteBibliografice
{
    public partial class GraficForm : Form
    {
        int[] nrAutoricarti;
        const int margine = 15;
        public GraficForm(int[] nrAutoricarti)
        {
            InitializeComponent();
            this.nrAutoricarti = nrAutoricarti;
        }

        private void deseneazaGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics gr = e.Graphics;
            Rectangle container = new Rectangle(panel1.ClientRectangle.X + margine, panel1.ClientRectangle.Y + 2*margine, panel1.ClientRectangle.Width
                - 2*margine, panel1.ClientRectangle.Height - 3*margine);

            gr.DrawRectangle(new Pen(new SolidBrush(Color.Red)), container);

            double latime = container.Width / this.nrAutoricarti.Length / 3;
            double distanta = (container.Width - latime * this.nrAutoricarti.Length) / (this.nrAutoricarti.Length + 1);
            double valMax = this.nrAutoricarti.Max();

            Brush br = new SolidBrush(Color.Orange);
            Rectangle[] recs = new Rectangle[this.nrAutoricarti.Length];

            for (int i = 0; i < this.nrAutoricarti.Length; i++)
            {
                recs[i] = new Rectangle((int)(container.Location.X + (i + 1) * distanta + i * latime),
                    (int)(container.Location.Y + container.Height - nrAutoricarti[i] / valMax * container.Height),
                    (int)latime,
                    (int)(nrAutoricarti[i] / valMax * container.Height));

                gr.FillRectangle(new SolidBrush(Color.Orange), recs[i]);
            }

        }
    }
}
