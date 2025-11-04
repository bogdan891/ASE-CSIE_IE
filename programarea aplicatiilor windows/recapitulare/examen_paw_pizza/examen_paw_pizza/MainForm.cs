using examen_paw_pizza.Models;
using examen_paw_pizza.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace examen_paw_pizza
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.lstPizza.MouseDoubleClick += MainForm_MouseDoubleClick;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lstPizza.Items.Clear();
            lstPizza.View = View.Details;
            lstPizza.FullRowSelect = true;
            lstPizza.MultiSelect = false;
            lstPizza.HideSelection = false;

            if(lstPizza.SelectedItems.Count == 0)
            {
                lstPizza.Columns.Add("Nume", 100, HorizontalAlignment.Left);
                lstPizza.Columns.Add("Blat", 100, HorizontalAlignment.Left);
                lstPizza.Columns.Add("Durata Realizare", 100, HorizontalAlignment.Left);
            }

            foreach(var x in Utils.FakeDatabase.pizza)
            {
                ListViewItem item = new ListViewItem(x.Nume);
                item.SubItems.Add(x.Blat);
                item.SubItems.Add(x.DurataRealizare.ToString());
                lstPizza.Items.Add(item);
            }
        }

        public void RefreshListView()
        {
            lstPizza.Items.Clear();
            foreach (var x in Utils.FakeDatabase.pizza)
            {
                ListViewItem item = new ListViewItem(x.Nume);
                item.SubItems.Add(x.Blat);
                item.SubItems.Add(x.DurataRealizare.ToString());
                lstPizza.Items.Add(item);
            }
        }

        private void binarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Fisier binar|*.bin";
                saveFileDialog.Title = "Salveaza fisierul binar";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using(var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        BinaryFormatter serializer = new BinaryFormatter();
                        serializer.Serialize(stream, Utils.FakeDatabase.pizza);
                    }

                    MessageBox.Show("Fisierul a fost salvat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare la salvarea fisierului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "CSV files|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            foreach (var pizza in Utils.FakeDatabase.pizza)
                            {
                                writer.WriteLine(pizza.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare la salvarea fisierului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "Fisier XML|*.xml";
                dialog.Title = "Salveaza fisierul XML";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Models.Topping>));
                        serializer.Serialize(stream, FakeDatabase.topping);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare la salvarea fisierului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddEdit form = new FormAddEdit();
            if(form.ShowDialog() == DialogResult.OK)
            {
                Utils.FakeDatabase.pizza.Add(form.comanda);
                RefreshListView();
            }
        }

        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstPizza.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectati o comanda pentru a o edita!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormAddEdit f = new FormAddEdit(Utils.FakeDatabase.pizza[lstPizza.SelectedIndices[0]]);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Utils.FakeDatabase.pizza[lstPizza.SelectedIndices[0]] = f.comanda;
                    RefreshListView();
                }
            }
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lstPizza.SelectedItems.Count==0)
            {
                MessageBox.Show("Selectati o comanda pentru stergere!", "Atentionare!", MessageBoxButtons.OK);
            }
            else
            {
                int index = lstPizza.SelectedIndices[0];
                DialogResult confirm = MessageBox.Show("Doriti sa stergeti aceasta comanda?", "Atentionare!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(confirm == DialogResult.Yes)
                {
                    Utils.FakeDatabase.pizza.RemoveAt(index);
                    RefreshListView();
                }
            }
        }
    }
}
