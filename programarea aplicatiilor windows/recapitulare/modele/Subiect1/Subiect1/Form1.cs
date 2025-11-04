using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Subiect1
{//partial->aceeasi clasa poate fi impartita in mai multe fisiere
    public partial class Form1: Form
    {
        private AngajatRepository _angajati_repository = new AngajatRepository();
        private List<Angajat> _angajati;

        private int _currentY = 40;
        public Form1()
        {
            InitializeComponent();
            LoadInitialData();//daca e asa nu o sa avem id autogenerat
            BuildTree();

            angajatiListView.View = View.Details;
            //list view cu details->obligatoriu setam coloane
            angajatiListView.Columns.Add("Nume",150);
            angajatiListView.Columns.Add("Salariu",80);
            angajatiListView.Columns.Add("Manager",150);

           
            RegisterKeyEvents();
        }

        private void LoadInitialData()
        {
            using (var stream = new FileStream("date.csv", FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var parts = line.Split(',');
                        var angajat = new Angajat();
                        angajat.Nume = parts[0];
                        angajat.Salariu = Convert.ToDouble(parts[1]);
                        if (!string.IsNullOrEmpty(parts[2]))
                        {
                            angajat.CodManager = Convert.ToInt32(parts[2]);
                        }
                        _angajati_repository.Salveaza(angajat);
                      

                    }
                 

                }
            }
        }

        private void RegisterKeyEvents()
        {
            angajatiListView.KeyUp += (s, e) =>
            {
                var listView = s as ListView;
                if (e.KeyCode == Keys.Delete)
                {
                    if (listView.SelectedItems.Count > 0)
                    {
                        foreach(var item in listView.SelectedItems)
                        {
                            var listViewItem = item as ListViewItem;
                            var angajat = listViewItem.Tag as Angajat;
                            if (_angajati.Any(x => x.CodManager == angajat.Cod))
                            {
                                //nu putem sterge pentru ca e managerul cuiv
                                MessageBox.Show($"Nu se poate sterge angajatul {angajat.Nume} deoarece este manager.", "Eroare",MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else
                            {
                                _angajati_repository.Sterge(angajat);
                                BuildTree();
                                angajatiListView.Items.Clear();
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.F6)
                {
                    angajatiListView.Items.Clear();
                    foreach(var angajat in _angajati.OrderByDescending(x => x.Salariu))
                    {
                        var item = new ListViewItem(angajat.Nume);
                        item.SubItems.Add(angajat.Salariu.ToString());
                        var manager = _angajati.FirstOrDefault(x => x.Cod == angajat.CodManager);//daca nu imi gaseste manager intoarce null
                        if (manager != null) {
                            item.SubItems.Add(manager.Nume);
                        }
                      
                        item.Tag = angajat;
                        angajatiListView.Items.Add(item);

                    }
                }
            };
        }

        private void BuildTree()
        {
            angajatiTreeView.Nodes.Clear();
            _angajati = _angajati_repository.GetAngajati();
            var manager = _angajati.First(x => x.CodManager == null);//cautam angajatul cu codul manager=0, ex CEO-ul, LINQ

            var node = new TreeNode(manager.Nume);
            node.Tag = manager;// informatii suplimentare, in caz ca avem nevoie mai tarziu

            angajatiTreeView.Nodes.Add(node);
            BuildTree(manager, node);

        }
        private void BuildTree(Angajat manager, TreeNode root)//overloading
        {
            var angajati = _angajati.Where(x => x.CodManager == manager.Cod);
            foreach(var angajat in angajati)
            {
                var node = new TreeNode(angajat.Nume);
                node.Tag = angajat;
                root.Nodes.Add(node);
                BuildTree(angajat, node);
            }
        }

        private void angajatiTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //dupa selectarea unui element din tree view
            angajatiListView.Items.Clear();
            var manager = e.Node.Tag as Angajat;//convertim la Angajat, echivalent cu (Angajat) inainte 

            var angajatiInSubordine = _angajati.Where(x => x.CodManager == manager.Cod);
            
            foreach(var angajat in angajatiInSubordine)
            {
                var item = new ListViewItem(angajat.Nume);
                item.SubItems.Add(angajat.Salariu.ToString());
                item.SubItems.Add(manager.Nume);
                item.Tag = angajat;
                angajatiListView.Items.Add(item);
            }
        }

    

        private void binarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Binary files|*.bin";
            if (dialog.ShowDialog()== DialogResult.OK)
            {
                using(var stream =new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, _angajati);
                }
            }
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "XML files|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    var serializer = new XmlSerializer(typeof(List<Angajat>));
                    serializer.Serialize(stream, _angajati);
                }
            }
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "CSV files|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                   using(var writer=new StreamWriter(stream))
                    {
                        foreach(var angajat in _angajati)
                        {
                            writer.WriteLine(angajat.ToString());
                        }
                    }
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var document = new PrintDocument();
            document.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawString("Nume angajat", new Font("Verdana", 10, FontStyle.Bold), Brushes.Black, new PointF(20, 20));//coltul de sus al paginii e 0 0?
                ev.Graphics.DrawString("Salariu", new Font("Verdana", 10, FontStyle.Bold), Brushes.Black, new PointF(400, 20));
                ev.Graphics.DrawString("Nume manager", new Font("Verdana", 10, FontStyle.Bold), Brushes.Black, new PointF(640, 20));
                var manager = _angajati.First(x => x.CodManager == null);

                PrintAngajatCurent(ev, manager,0);


                ev.HasMorePages = false;

            };
            var dialog = new PrintPreviewDialog()
            {
                Document = document, 
                Width=800,
                Height=1200
            };
            dialog.ShowDialog();

           //atasam o functie noua, fie asa cu functie anonima (s,ev)=>{} fie functie declarata dupa
        }

        private void PrintAngajatCurent(PrintPageEventArgs ev,Angajat manager,int x)
        {
            ev.Graphics.DrawString(manager.Nume, new Font("Verdana", 10), Brushes.Black,new PointF(x,_currentY));
            ev.Graphics.DrawString(manager.Salariu.ToString(), new Font("Verdana", 10), Brushes.Black, new PointF(400, _currentY));
            if (manager.CodManager != null){
                var managerulManagerului = _angajati.First(a => a.Cod == manager.Cod);
                ev.Graphics.DrawString(managerulManagerului.Nume, new Font("Verdana", 10), Brushes.Black, new PointF(640, _currentY));
            }

            _currentY += 20;
            var angajatiInSubOrdine = _angajati.Where(a => a.CodManager == manager.Cod);
            foreach(var angajat in angajatiInSubOrdine)
            {
                PrintAngajatCurent(ev, angajat, x + 20);
                
            }
            /*  a1
             *      a2
             *          a3
             *      a4 
             *      x variaza in functie de nivelul de recursivitate
             *      y doar creste 
             */
        }

        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AdaugaAngajatForm();
            form.ShowDialog();
            BuildTree();
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ChartForm();
            form.ShowDialog();
        }
    }
}
