using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GestiuneStudentiFacultate
{
    public partial class Form1 : Form
    {
        List<Student> lstStudenti = new List<Student>();
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ExamenDB.accdb";
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void addStudentDB(Student stud)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand comanda = new OleDbCommand();
            comanda.CommandText = "INSERT INTO studenti(nr_matricol, nume, medie) VALUES(?, ?, ?)";
            comanda.Connection = conn;
            comanda.Parameters.Add("nr_matricol", OleDbType.Integer).Value = stud.NrMatricol;
            comanda.Parameters.Add("nume", OleDbType.Char, 30).Value = stud.Nume;
            comanda.Parameters.Add("medie", OleDbType.Integer).Value = stud.Medie;

            try
            {
                conn.Open();
                comanda.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (tbNrMatricol.Text == "")
                errorProvider1.SetError(tbNrMatricol, "Introdu numarul matricol!");
            else if (tbNume.Text == "")
                errorProvider1.SetError(tbNume, "Introdu numele!");
            else if (tbMedie.Text == "")
                errorProvider1.SetError(tbMedie, "Introdu media1");
            else
            {
                try
                {
                    int nrMatricol = Convert.ToInt32(tbNrMatricol.Text);
                    string nume = tbNume.Text;
                    float medie = (float)Convert.ToDouble(tbMedie.Text);

                    lstStudenti.Add(new Student(nrMatricol, nume, medie));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    errorProvider1.Clear();
                    tbNrMatricol.Clear();
                    tbNume.Clear();
                    tbMedie.Clear();

                    afisareStudenti();

                }
            }
        }

        void afisareStudenti()
        {
            DataTable students = new DataTable("Students");
            DataColumn c0 = new DataColumn("nrMatricol");
            DataColumn c1 = new DataColumn("Nume");
            DataColumn c2 = new DataColumn("Medie");
            students.Columns.Add(c0);
            students.Columns.Add(c1);
            students.Columns.Add(c2);

            foreach(Student student in lstStudenti)
            {
                DataRow row = students.NewRow();

                row["nrMatricol"] = student.NrMatricol.ToString();
                row["Nume"] = student.Nume;
                row["Medie"] = student.Medie.ToString();

                students.Rows.Add(row);
            }

            dataGridView1.DataSource = students;

        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;

            string antet = "NrMatricol         Nume           Medie";
            gr.DrawString(antet, new Font(Font.FontFamily, 15), new SolidBrush(Color.DarkBlue), e.PageBounds.X + 150, e.PageBounds.Y + 50 );
            gr.DrawLine(new Pen(new SolidBrush(Color.Green)), e.PageBounds.X + 130, e.PageBounds.Y + 85, e.PageBounds.X + 500, e.PageBounds.Y + 85);

            Font font = new Font(Font.FontFamily, 15);
            Brush brush = new SolidBrush(Color.DarkBlue);

            for(int i = 0; i < lstStudenti.Count; i++)
            {
                gr.DrawString(lstStudenti[i].NrMatricol.ToString(), font, brush, e.PageBounds.X + 185, e.PageBounds.Y + 110 + i * 25);
                gr.DrawString(lstStudenti[i].Nume.ToString(), font, brush, e.PageBounds.X + 295, e.PageBounds.Y + 110 + i * 25);
                gr.DrawString(lstStudenti[i].Medie.ToString(), font, brush, e.PageBounds.X + 410, e.PageBounds.Y + 110 + i * 25);


            }


        }
        private void graficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int nrMatricol = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            Student stud = lstStudenti.Where(x => x.NrMatricol == nrMatricol).First();

            Form2 frm = new Form2(stud);
            frm.ShowDialog();

            afisareStudenti();
        }

        private void salvareDateDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Student stud in lstStudenti)
                addStudentDB(stud);

            TextBox tb = (TextBox)userControl11.Controls[0];
            tb.Text = "DATE SALVATE";
        }
    }
}
