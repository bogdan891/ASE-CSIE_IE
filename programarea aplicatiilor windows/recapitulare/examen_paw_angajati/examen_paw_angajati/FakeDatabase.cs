using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_paw_angajati
{
    public class FakeDatabase
    {
        public static BindingList<Companie> companii = new BindingList<Companie>();
        public static BindingList<Angajat> angajati = new BindingList<Angajat>();

        private static string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=angajati;Integrated Security=True;";


        static FakeDatabase()
        {
            DownloadFromDBCompanii();
            DownloadFromDB();
        }
        public static void DownloadFromDBCompanii()
        {
            companii.Clear();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT Id, Nume FROM Companii", connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nume = reader.GetString(1);
                        companii.Add(new Companie(id, nume));
                    }
                }
            }
        }

        public static void DownloadFromDB()
        {
            using(SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                var cmd = new SqlCommand("Select Nume, DataNasterii, IDCompanie from Angajati", connection);
                using(var reader =  cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nume = reader.GetString(0);
                        DateTime data = reader.GetDateTime(1);
                        int id = reader.GetInt32(2);
                        angajati.Add(new Angajat(nume, data, id));
                    }
                }
            }
        }
    }
}
