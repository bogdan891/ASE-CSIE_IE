using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditareImagini
{
    public partial class GraficForm : Form
    {
        List<Poligon> poligoane;
        const int margine = 10;
        public GraficForm(List<Poligon> poligoane) 
        { 
            InitializeComponent();
            this.poligoane = poligoane;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;


            Poligon pol = poligoane[0];

            int multiplicator = 50;

            Rectangle container = new Rectangle(panel1.ClientRectangle.X + margine, panel1.ClientRectangle.Y + 3 * margine,
                panel1.ClientRectangle.Width - 2 * margine, panel1.ClientRectangle.Height - 5 * margine);

            gr.DrawRectangle(new Pen(new SolidBrush(Color.Orange)), container);

            Point origine = new Point(container.Location.X, container.Location.Y + container.Height);


            //gr.DrawLine(new Pen(new SolidBrush(Color.Red)), origine, new Point(container.Width / 2, container.Height / 2));



            for (int i = 0; i < pol.Puncte.Count - 1; i++)
            {
                gr.DrawLine(new Pen(new SolidBrush(Color.Green)), multiplicator * (origine.X + pol.Puncte[i].X),
                                                                  multiplicator * (origine.Y - pol.Puncte[i].Y),
                                                                  multiplicator * (origine.X + pol.Puncte[i + 1].X),
                                                                  multiplicator * (origine.Y - pol.Puncte[i + 1].Y));

            }

            gr.DrawLine(new Pen(new SolidBrush(Color.Green)), multiplicator * (origine.X + pol.Puncte[0].X),
                                                                              multiplicator * (origine.Y - pol.Puncte[0].Y),
                                                                              multiplicator * (origine.X + pol.Puncte[pol.Puncte.Count - 1].X),
                                                                              multiplicator * (origine.Y - pol.Puncte[pol.Puncte.Count - 1].Y));
        }
    }
}
