using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void listaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var listForm = new ListForm();
            listForm.MdiParent = this;
            listForm.Show();
        }

        private void adaugaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var addForm = new AddForm();
            addForm.MdiParent = this;
            addForm.Show();

        }

        private void serializareToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files|*.bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, FakeDatabase.Sectii);
                    MessageBox.Show("Serializarea s-a realizat cu succes");
                }
            }
        }

        private void deserializareToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary files|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    var data = (BindingList<Sectie>)formatter.Deserialize(stream);
                    FakeDatabase.Sectii.Clear();
                    foreach (var item in data)
                    {
                        FakeDatabase.Sectii.Add(item);
                    }

                    MessageBox.Show("Deserializarea s-a realizat cu succes");
                }
            }
        }

        private void determinaCastigatorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var sum1 = FakeDatabase.Sectii.Sum(x => x.Candidat1);
            var sum2 = FakeDatabase.Sectii.Sum(x => x.Candidat2);

            if (sum1 > sum2)
            {
                MessageBox.Show("Candidatul 1 a castigat");
            }
            else
            {
                if (sum1 < sum2)
                {
                    MessageBox.Show("Candidatul 2 a castigat");
                }
                else
                {
                    MessageBox.Show("Egalitate");
                }
            }
        }
    }
}
