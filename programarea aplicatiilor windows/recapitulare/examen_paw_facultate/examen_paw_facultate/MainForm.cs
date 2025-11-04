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

namespace examen_paw_facultate
{
    public partial class MainForm : Form
    {
        public BindingList<Student> lstStudenti = new BindingList<Student>();
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            printDocument1.PrintPage += printDocument1_PrintPage;
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            lstStudenti.Clear();
            Upload();
            dataGridView.ClearSelection();
            dataGridView.DataSource = lstStudenti;
            dataGridView.Columns[0].HeaderText = "Nr. Matricol";
            dataGridView.Columns[1].HeaderText = "Nume Student";
            dataGridView.Columns[2].HeaderText = "Medie";
            dataGridView.ReadOnly = true;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            dataGridView.Refresh();
        }

        public void Upload()
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=studenti;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "SELECT nrMatricol, nume, medie FROM tblStudenti";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int nr = reader.GetInt32(0);
                            string nume = reader.GetString(1);
                            float medie = (float)Convert.ToDouble(reader[2]);
                            lstStudenti.Add(new Student(nr, nume, medie));
                        }
                    }
                }
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            float y = 100; // poziția verticală inițială
            float x = 100;

            e.Graphics.DrawString("Raport Medii Studenți", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, x, y);
            y += 40;

            foreach (var student in lstStudenti)
            {
                string linie = $"Nume: {student.Nume,-20} | Medie: {student.Medie:F2}";
                e.Graphics.DrawString(linie, font, Brushes.Black, x, y);
                y += 25;
            }

            e.HasMorePages = false; // doar o pagină
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < lstStudenti.Count)
            {
                Student s = lstStudenti[e.RowIndex];

                EditareMedie frm = new EditareMedie(s);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dataGridView.Refresh();
                }
            }
        }

        private void actualizareBazaDeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;
                       Initial Catalog=studenti;
                       Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                foreach (var student in lstStudenti)
                {
                    // Verificăm dacă există deja în baza de date (după nrMatricol)
                    string checkQuery = "SELECT COUNT(*) FROM tblStudenti WHERE nrMatricol = @nr";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@nr", student.NrMatricol);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        // INSERT
                        string insertQuery = @"INSERT INTO tblStudenti (nrMatricol, nume, medie)
                                       VALUES (@nr, @nume, @medie)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                        insertCmd.Parameters.AddWithValue("@nr", student.NrMatricol);
                        insertCmd.Parameters.AddWithValue("@nume", student.Nume);
                        insertCmd.Parameters.AddWithValue("@medie", student.Medie);
                        insertCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // UPDATE
                        string updateQuery = @"UPDATE tblStudenti SET medie = @medie WHERE nrMatricol = @nr";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@medie", student.Medie);
                        updateCmd.Parameters.AddWithValue("@nr", student.NrMatricol);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Datele au fost salvate/actualizate cu succes în baza de date!");
            }
        }
    }
}
