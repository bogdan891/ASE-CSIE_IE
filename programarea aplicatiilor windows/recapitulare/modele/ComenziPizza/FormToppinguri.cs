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

namespace ComenziPizza
{
    public partial class FormToppinguri : Form
    {
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DBExamen.accdb";

        ComandaPizza com;
        public FormToppinguri(ComandaPizza com)
        {
            InitializeComponent();
            this.com = com;

            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM toppinguri ORDER BY id";
            cmd.Connection = conn;

            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["cod"].ToString());
                    item.SubItems.Add(reader["denumire"].ToString());
                    item.SubItems.Add(reader["pret"].ToString());
                    item.SubItems.Add(reader["cantitate"].ToString());

                    listView1.Items.Add(item);
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView1.Items)
                if(itm.Checked)
                {
                    int cod = Convert.ToInt32(itm.SubItems[0].Text);
                    string denumire = itm.SubItems[1].Text;
                    float pret = (float)Convert.ToDouble(itm.SubItems[2].Text);
                    float cantitate = (float)Convert.ToDouble(itm.SubItems[3].Text);

                    com += new Topping(cod, denumire, pret, cantitate);


                }
        }
    }
}
