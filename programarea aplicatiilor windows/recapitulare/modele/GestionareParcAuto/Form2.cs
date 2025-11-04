using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionareParcAuto
{
    public partial class Form2 : Form
    {
        int[] valori;
        const int margine = 10;
        public Form2(int[] valori)
        {
            InitializeComponent();
            this.valori = valori;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;

            Rectangle container = new Rectangle(panel1.ClientRectangle.X + margine, panel1.ClientRectangle.Y + 2 * margine,
                panel1.ClientRectangle.Width - 2 * margine, panel1.ClientRectangle.Height - 3 * margine);

            gr.DrawRectangle(new Pen(new SolidBrush(Color.Orange)), container);

            double valMax = valori.Max();
            double latime = container.Width / valori.Length / 3;
            double spatiu = (container.Width - valori.Length * latime) / (valori.Length + 1);

            Rectangle[] recs = new Rectangle[valori.Length];

            for(int i = 0; i < recs.Length; i++)
            {
                recs[i] = new Rectangle((int)(container.Location.X + (i + 1) * spatiu + i * latime),
                                        (int)(container.Location.Y + container.Height - valori[i] / valMax * container.Height),
                                        (int)latime,
                                        (int)(valori[i] / valMax * container.Height));

                gr.FillRectangle(new SolidBrush(Color.Green), recs[i]);
            }
           
        }
    }
}
