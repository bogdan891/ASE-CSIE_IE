using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace examen_paw_pizza.Utils
{
    public class FakeDatabase
    {
        public static BindingList<Models.ComandaPizza> pizza = new BindingList<Models.ComandaPizza>();
        public static BindingList<Models.Topping> topping = new BindingList<Models.Topping>();
        private static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Gestiune_Pizza;Integrated Security=True;";
        static FakeDatabase()
        {
            try
            {
                DownloadTopping();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare SQL: " + ex.Message);
            }
        }

        public static void DownloadTopping()
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT COD, DENUMIRE, PRET FROM Topping", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cod = reader.GetInt32(0);
                        string denumire = reader.GetString(1);
                        float pret = (float)reader.GetDouble(2);

                        var top = new Models.Topping(denumire, pret, cod);
                        if (!topping.Contains(top))
                            topping.Add(top);
                    }
                }
            }
        }

    }
}
