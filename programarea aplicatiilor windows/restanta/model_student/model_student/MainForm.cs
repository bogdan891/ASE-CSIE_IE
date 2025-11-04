using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace model_student
{
    public partial class MainForm : Form
    {
        public static List<Student> lstStudenti = new List<Student>();
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            printDoc.PrintPage += printDoc_PrintPage;
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            lstStudenti.Clear();
            Upload();
            studenti.ClearSelection();
            studenti.DataSource = lstStudenti;
            studenti.Columns[1].HeaderText = "Nr. Matricol";
            studenti.Columns[0].HeaderText = "Nume";
            studenti.Columns[2].HeaderText = "Media";
            studenti.ReadOnly = true;
            studenti.CellDoubleClick += studenti_CellDoubleClick;
            studenti.Refresh();
        }

        private void studenti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < lstStudenti.Count)
            {
                Student s = lstStudenti[e.RowIndex];
                Edit form = new Edit(s);
                if(form.ShowDialog() == DialogResult.OK)
                {
                    studenti.Refresh();
                }
            }
        }

        public void Upload()
        {
            string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studenti;Integrated Security=True;Connect Timeout=30;";
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "SELECT NrMatricol, Nume, Media FROM tblStudenti";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int nrMatricol = reader.GetInt32(0);
                            string nume = reader.GetString(1);
                            float media = (float)Convert.ToDouble(reader[2]);
                            lstStudenti.Add(new Student(nume, nrMatricol, media));
                        }
                    }
                }
            }
        }
        public void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 12);
            float x = 100, y = 100;
            e.Graphics.DrawString("Raport Medii Studenti", new Font("Verdana", 14, FontStyle.Bold), Brushes.Black, x, y);
            y += 40;
            foreach (Student student in lstStudenti)
            {
                string line = $"Nume: {student.Nume} => Medie: {student.Medie:F2}";
                e.Graphics.DrawString(line, font, Brushes.Black, x, y);
                y += 25;
            }
        }
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preview.Document = printDoc;
            preview.ShowDialog();
        }

        private void actualizareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studenti;Integrated Security=True;Connect Timeout=30;";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                foreach (Student student in lstStudenti)
                {
                    string query = "UPDATE tblStudenti SET Media = @medie WHERE NrMatricol = @nrMatricol";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@medie", student.Medie);
                    cmd.Parameters.AddWithValue("@nrMatricol", student.NrMatricol);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Datele au fost actualizate cu succes!");
            }
        }
    }
}
