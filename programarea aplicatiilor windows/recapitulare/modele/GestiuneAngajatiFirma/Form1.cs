using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestiuneAngajatiFirma
{
    public partial class Form1 : Form
    {
        List<Angajat> angajati = new List<Angajat>();
        public Form1()
        {
            
            InitializeComponent();

            Companie c1 = new Companie(1, "IBM SRL");
            Companie c2 = new Companie(2, "ORACLE SRL");
            Companie c3 = new Companie(3, "ENDAVA");
           
        }

        private void afisareAngajati()
        {
            listView1.Items.Clear();

            foreach(Angajat a in angajati)
            {
                ListViewItem item = new ListViewItem(a.Nume);
                item.SubItems.Add(a.DataNasterii.ToString());
                item.SubItems.Add(a.IdCompanie.ToString());

                listView1.Items.Add(item);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(angajati);
            frm.ShowDialog();

            afisareAngajati();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView1.Items)
                if (itm.Selected)
                {
                   string nume = itm.SubItems[0].Text;

                   Angajat deSters = angajati.Where(x => x.Nume == nume).First();

                    if (deSters != null)
                    {
                        angajati.Remove(deSters);
                    }
                }

            afisareAngajati();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem itm in listView1.Items)
                if (itm.Selected)
                {
                    string nume = itm.SubItems[0].Text;

                    Angajat deModificat = angajati.Where(x => x.Nume == nume).First();

                    Form3 frm = new Form3(deModificat);
                    frm.ShowDialog();
                }

            afisareAngajati();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool auCompanieToti = true;

            foreach(Angajat a in angajati)
                if(!(bool)a)
                {
                    auCompanieToti = false;
                    break;
                }

            if (auCompanieToti)
                MessageBox.Show("Au toti companie!");
            else MessageBox.Show("NU AU TOTI COMPANIE");
        }
    }
}
