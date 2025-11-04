using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model_apartament
{
    public partial class MainForm : Form
    {
        public BindingList<Camera> camere = new BindingList<Camera>();
        public MainForm()
        {
            InitializeComponent();
            dgvCamere.DataSource = camere;
            this.Load += MainForm_Load;
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            dgvCamere.ClearSelection();
            dgvCamere.AutoGenerateColumns = false;
            dgvCamere.Columns.Clear();
            dgvCamere.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Lungime",
                DataPropertyName = "Lungime",
                ReadOnly = true,
            });
            dgvCamere.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Latime",
                DataPropertyName = "Latime",
                ReadOnly = true,
            });
            dgvCamere.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Orientare",
                DataPropertyName = "OrientareAfisata",
                ReadOnly = true,
            });
            dgvCamere.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Suprafata",
                DataPropertyName = "Suprafata",
                ReadOnly = true,
            });

            Upload();
            dgvCamere.Refresh();
        }

        public void Upload()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Gest_Camere;Integrated Security=True;Connect Timeout=30;";
            string query = "SELECT Lungime, Latime, Orientare FROM Camere";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double L = Convert.ToDouble(reader.GetDecimal(0));
                            double l = Convert.ToDouble(reader.GetDecimal(1));
                            string o = reader.GetString(2);
                            Orientare or = Orientare.V;
                            if (o.CompareTo("N") == 0) or = Orientare.N;
                            if (o.CompareTo("S") == 0) or = Orientare.S;
                            if (o.CompareTo("E") == 0) or = Orientare.E;

                            camere.Add(new Camera(L,l,or));
                        }
                    }
                }
            }
        }
    }
}
