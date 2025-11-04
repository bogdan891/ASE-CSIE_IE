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
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;


namespace examen_paw_triunghi
{
    public partial class FormPrincipal : Form
    {
        public static List<Triunghi> ColectieTriunghiuri = new List<Triunghi>();
        public FormPrincipal()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }
        private void inserareTriunghiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FormTriunghi();
            f.MdiParent = this;
            f.Show();
        }

        private void afisareTriunghiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAfisare f = new FormAfisare();
            f.MdiParent = this;
            f.Show();
        }

        private void salvareTriunghiuriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Fișiere binare|*.bin";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, ColectieTriunghiuri);
                }
                MessageBox.Show("Triunghiurile au fost salvate cu succes.");
            }
        }

        private void incarcareTriunghiuriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fișiere binare|*.bin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    ColectieTriunghiuri = (List<Triunghi>)formatter.Deserialize(fs);
                }

                FormTextDisplay f = new FormTextDisplay();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void salvareBazaDeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=|DataDirectory|\Database\triunghiuri.mdf;
Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                foreach (var t in FormPrincipal.ColectieTriunghiuri)
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Triunghiuri (cod_figura, eticheta, perimetru) VALUES (@c, @e, @p)", conn);
                    cmd.Parameters.AddWithValue("@c", t.CodFigura);
                    cmd.Parameters.AddWithValue("@e", t.Eticheta);
                    cmd.Parameters.AddWithValue("@p", t.CalculPerimetru());

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare: " + ex.Message);
                    }
                }

                MessageBox.Show("Salvat cu succes!");
            }
        }
    }
}
