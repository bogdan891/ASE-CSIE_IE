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

namespace ComenziPizza
{
    public partial class Form1 : Form
    {
        List<ComandaPizza> comenzi = new List<ComandaPizza>();
        public Form1()
        {
            InitializeComponent();

            treeView1.Nodes.Add("Crocant");
            treeView1.Nodes.Add("Pufos");
            treeView1.Nodes.Add("Cheesy");


            incarcaDateFisier();
        }


        private void incarcaDateFisier()
        {
            StreamReader sr = new StreamReader("pizza.txt");
            string linie = null;
            while((linie = sr.ReadLine()) != "")
            {

                string nume = linie.Split(',')[0];
                string blat = linie.Split(',')[1];
                int durata = Convert.ToInt32(linie.Split(',')[2]);

                comenzi.Add(new ComandaPizza(nume, blat, durata, new List<Topping>()));

            }

            sr.Close();

            populareTreeView();

        }

        private void populareTreeView()
        {
            treeView1.Nodes[0].Nodes.Clear();
            treeView1.Nodes[1].Nodes.Clear();
            treeView1.Nodes[2].Nodes.Clear();


            foreach (ComandaPizza com in comenzi)
            {
                switch(com.Blat)
                {
                    case "Crocant":
                        treeView1.Nodes[0].Nodes.Add(com.ToString());
                        break;

                    case "Pufos":
                        treeView1.Nodes[1].Nodes.Add(com.ToString());

                        break;

                    case "Cheesy":
                        treeView1.Nodes[2].Nodes.Add(com.ToString());
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(comenzi);
            frm.ShowDialog();
            populareTreeView();


        }
        
        private void toppinguriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                string numePizza = treeView1.SelectedNode.Text.Split(' ')[0];

                ComandaPizza comandaCautata = comenzi.Where(x => x.Nume.Equals(numePizza)).ToArray()[0];

                FormToppinguri frm = new FormToppinguri(comandaCautata);
                frm.ShowDialog();
            }


            populareTreeView();


        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                string numePizza = treeView1.SelectedNode.Text.Split(' ')[0];
                ComandaPizza comandaCautata = comenzi.Where(x => x.Nume.Equals(numePizza)).ToArray()[0];

                string deAfisat = "";

                foreach (Topping t in comandaCautata.Toppinguri)
                    deAfisat += t.ToString() + Environment.NewLine;

                MessageBox.Show(deAfisat);

            }


        }
    }
}
