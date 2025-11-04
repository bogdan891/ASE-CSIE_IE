using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_studenti
{
    public partial class MainForm : Form
    {
        public static BindingList<Student> lstStudenti = new BindingList<Student>();
        public MainForm()
        {
            InitializeComponent(GetEventHandler());
            this.Load += MainForm_Load;
            printDocument1.PrintPage += printDocument1_PrintPage;
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            dgw.ClearSelection();
            lstStudenti.Clear();
            Upload();
            dgw.DataSource = lstStudenti;
            dgw.Columns[0].HeaderText = "Nr. Matricol";
            dgw.Columns[1].HeaderText = "Nume Student";
            dgw.Columns[2].HeaderText = "Medie";
            dgw.ReadOnly = true;
            dgw.CellDoubleClick += dgw_CellDoubleClick;
            dgw.Refresh();
        }
        public void Upload()
        {
            string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gestiune_studenti;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using(SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT Matricol, Nume, Media FROM tblStudenti;", conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int nr = reader.GetInt32(0);
                            string nume = reader.GetString(1);
                            float media =(float)Convert.ToDouble(reader[2]);
                            lstStudenti.Add(new Student(nr, nume, media));
                        }
                    }
                }
            }
        }
        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex < lstStudenti.Count)
            {
                Student s = lstStudenti[e.RowIndex];
                AddEditForm f = new AddEditForm(s);
                if(f.ShowDialog() == DialogResult.OK)
                {
                    dgw.Refresh();
                }
            }
        }
        private void printPreviewToolStripMenuItem_Click(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
                string linie = $"Nume: {student.Nume,-20} | Medie: {student.Media:F2}";
                e.Graphics.DrawString(linie, font, Brushes.Black, x, y);
                y += 25;
            }

            e.HasMorePages = false; // doar o pagină
        }
    }
}
