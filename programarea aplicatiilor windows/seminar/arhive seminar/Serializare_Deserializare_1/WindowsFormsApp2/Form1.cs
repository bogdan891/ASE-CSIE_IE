using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using(var stream = new FileStream("export.bin", FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                FakeDatabase.Files = (List<FileModel>)formatter.Deserialize(stream);
            }

            filesListView.View = View.Details;
            filesListView.Columns.Add("File name", 300);
            filesListView.Columns.Add("Extension");
            filesListView.Columns.Add("Modified on");

            foreach (var file in FakeDatabase.Files)
            {
                var item = new ListViewItem();
                item.Text = file.Name;
                item.SubItems.Add(file.Extension);
                item.SubItems.Add(file.ModifiedOn.ToString("dddd, dd MMMM yyyy"));

                filesListView.Items.Add(item);
            }

        }

        private void serializeButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, FakeDatabase.Files);
                }
            }
            
        }
    }
}
