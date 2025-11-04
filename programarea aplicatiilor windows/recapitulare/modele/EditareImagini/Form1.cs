using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EditareImagini
{
    public partial class Form1 : Form
    {
        List<Poligon> poligoane = new List<Poligon>();
        public Form1()
        {
            InitializeComponent();
        }


        private void afisarePoligoane()
        {
            listView1.Items.Clear();

            foreach(Poligon poligon in poligoane)
            {
                ListViewItem itm = new ListViewItem(poligon.Cod_figura.ToString());
                itm.SubItems.Add(poligon.Eticheta);

                listView1.Items.Add(itm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdaugaPoligon frm = new AdaugaPoligon(poligoane);
            frm.ShowDialog();

            afisarePoligoane();
        }

        private void listView1_MouseHover(object sender, EventArgs e)
        {
            float perimetruTotalFiguri = 0;
            foreach (Poligon p in this.poligoane)
                perimetruTotalFiguri += p.perimetru();

            toolStripStatusLabel1.Text = "Perimetru total figuri din ListView: " + perimetruTotalFiguri;
        }

        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.dat)|*.dat";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);

                bf.Serialize(fs, this.poligoane);

                fs.Close();


                this.poligoane.Clear();
                listView1.Items.Clear();
                MessageBox.Show("Fisier .DAT creat!");
                

            }
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.dat)|*.dat";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

                this.poligoane = (List<Poligon>)bf.Deserialize(fs);

                fs.Close();
                afisarePoligoane();

                MessageBox.Show("Date incarcate din fisier .DAT!");


            }

        }

        private void graficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficForm frm = new GraficForm(poligoane);
            frm.ShowDialog();
        }
    }
}
