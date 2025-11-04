using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BicicletePublice
{
    public partial class GraficForm : Form
    {
        List<Bicicleta> biciclete;
        List<Utilizator> utilizatori;
        const int margine = 10;
        public GraficForm(List<Bicicleta> biciclete, List<Utilizator> utilizatori)
        {
            InitializeComponent();
            this.biciclete = biciclete;
            this.utilizatori = utilizatori;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int[] vector_km = new int[biciclete.Count];

            for (int i = 0; i < vector_km.Length; i++)
                vector_km[i] = biciclete[i].Km_parcursi;

            Graphics gr = e.Graphics;

            Rectangle container = new Rectangle(panel1.ClientRectangle.X + margine, panel1.ClientRectangle.Y + 2 * margine,
                        panel1.ClientRectangle.Width - 2 * margine, panel1.ClientRectangle.Height - 3 * margine);

            gr.DrawRectangle(new Pen(new SolidBrush(Color.Red)), container);


            double valMax = vector_km.Max();
            double latime = container.Width / vector_km.Length / 3;
            double spatiu = (container.Width - latime * vector_km.Length) / (vector_km.Length + 1);

            Rectangle[] recs = new Rectangle[vector_km.Length];

            for(int i = 0; i< recs.Length; i++)
            {
                recs[i] = new Rectangle((int)(container.Location.X + (i + 1) * spatiu + i * latime),
                                        (int)(container.Location.Y + container.Height - vector_km[i] / valMax * container.Height),
                                        (int)latime,
                                        (int)(vector_km[i] / valMax * container.Height));

                gr.FillRectangle(new SolidBrush(Color.Green), recs[i]);
            }
            


        }
    }
}
