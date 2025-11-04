using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect1
{
   public  class AngajatRepository
    {
        private string _connectionString = "----";
        public List<Angajat> GetAngajati()
        {
            var list = new List<Angajat>();

            using(var connection=new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Cod, Nume, Salariu, CodManager from Angajati ", connection))//nu *, e mai bine sa scriem coloanele pt a avea control
                {
                    //command.ExecuteNonQuery();// folosim asta cand comanda nu ne intoarce nimic (insert, update, delete)
                    //scalar->returneaza date-> cand e apel de functii de exemplu, returneaza o valoare, un sg rand+ o sg coloana ->ex suma sau cv
                    //reader->returneaza date, returneaza tabele/linii
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var angajat = new Angajat();
                        angajat.Cod = reader.GetInt32(reader.GetOrdinal("Cod"));//get ordinal= indexul coloanei cu acel nume
                        angajat.Nume = reader.GetString(reader.GetOrdinal("Nume"));
                        angajat.Salariu = reader.GetDouble(reader.GetOrdinal("Salariu"));

                        int index = reader.GetOrdinal("CodManager");

                        if (!reader.IsDBNull(index))
                        {
                            //e null in codManager
                            angajat.CodManager = reader.GetInt32(index);
                        }
                        list.Add(angajat);
                    }
                }
            }


            return list;
        }

        public void Salveaza(Angajat angajat)
        {
            using(var connection=new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Angajati (Nume,Salariu,CodManager) Values (@Nume, @Salariu,@CodManager)", connection))
                {
                    //@ ->parametrii
                    command.Parameters.AddWithValue("Nume", angajat.Nume);
                    command.Parameters.AddWithValue("Salariu", angajat.Salariu);
                    command.Parameters.AddWithValue("CodManager", angajat.CodManager);

                    command.ExecuteNonQuery();
                }
                    
            }
        }
        public void Sterge(Angajat angajat)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Angajati where Cod=@Cod", connection))
                {
                 
                    command.Parameters.AddWithValue("Cod", angajat.Cod);

                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
