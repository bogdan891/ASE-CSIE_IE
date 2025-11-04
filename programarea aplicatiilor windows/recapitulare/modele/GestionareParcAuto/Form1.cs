using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GestionareParcAuto
{
    public partial class Form1 : Form
    {
        List<Autocamion> autocamioane = new List<Autocamion>();
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ExamenDB.accdb";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            autocamioane.Clear();


            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM autocamioane ORDER BY id_autocamion";
            cmd.Connection = conn;
            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int cod = Convert.ToInt32(reader["id_autocamion"].ToString());
                    string nume = reader["proprietar"].ToString();
                    float pret = (float)Convert.ToDouble(reader["pret"].ToString());
                    int nrLocuri = Convert.ToInt32(reader["numar_locuri"].ToString());
                    string[] valori = reader["greutati_curse"].ToString().Split(',');

                    float[] greutatiCurse = new float[valori.Length];

                    for (int i = 0; i < valori.Length; i++)
                        greutatiCurse[i] = (float)Convert.ToDouble(valori[i]);

                    int nrCurse = Convert.ToInt32(reader["numar_curse"].ToString());

                    autocamioane.Add(new Autocamion(cod, nume, pret, nrLocuri, greutatiCurse, nrCurse));

                }


                foreach(Autocamion a in autocamioane)
                {
                    ListViewItem itm = new ListViewItem(a.Id.ToString());
                    itm.SubItems.Add(a.Proprietar);
                    itm.SubItems.Add(a.Pret.ToString());
                    itm.SubItems.Add(a.NrLocuri.ToString());

                    string str = "";

                    for (int i = 0; i < a.GreutateMarfaCurse.Length; i++)
                        str += a.GreutateMarfaCurse[i] + ", ";

                    itm.SubItems.Add(str);
                    itm.SubItems.Add(a.NrCurse.ToString());

                    listView1.Items.Add(itm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView1.Items)
                if(itm.Checked)
                {
                    int id = Convert.ToInt32(itm.SubItems[0].Text);

                    OleDbConnection conn = new OleDbConnection(connString);
                    OleDbCommand cmd = new OleDbCommand();

                    cmd.CommandText = "DELETE FROM autocamioane WHERE id_autocamion = " + id;
                    cmd.Connection = conn;

                    try
                    {
                        conn.Open();
                        int rezultat = cmd.ExecuteNonQuery();

                        if (rezultat == 1)
                            MessageBox.Show("Record-ul a fost sters cu succes!");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();

                        listView1.Items.Clear();
                        button1_Click(sender, e);
                    }
                }


            

        }

        private void graficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] valori = new int[autocamioane.Count];

            for (int i = 0; i < valori.Length; i++)
                valori[i] = autocamioane[i].NrCurse;


            Form2 frm = new Form2(valori);
            frm.ShowDialog();
        }
    }
}
