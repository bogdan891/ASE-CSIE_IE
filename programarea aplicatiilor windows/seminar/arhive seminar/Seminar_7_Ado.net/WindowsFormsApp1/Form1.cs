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
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            usersDataGridView.DataSource = GetUsersFromDb();
            usersDataGridView.AutoGenerateColumns = true;
        }

        private List<User> GetUsersFromDb() {
            using (var connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\stud\\Documents\\paw1.mdf;Integrated Security=True;Connect Timeout=30")) {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, FirstName, LastName, Email, Password FROM Users", connection)) {
                    var reader = command.ExecuteReader();
                    var users = new List<User>();

                    while (reader.Read()) {
                        var user = new User();
                        user.Id = Guid.Parse(reader["Id"].ToString());
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader.GetString(2);
                        user.Email = reader["Email"].ToString();
                        user.Password = reader["Password"].ToString();

                        users.Add(user);
                    }

                    connection.Close();
                    return users;
                }
            }
        }

        private void InsertDummyUserButton_Click(object sender, EventArgs e) 
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.FirstName = "Gigel";
            user.LastName = "Ionescu";
            user.Email = "gigel@ionescu.ro";
            user.Password = "Pass";
            using (var connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\stud\\Documents\\paw1.mdf;Integrated Security=True;Connect Timeout=30")) 
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "INSERT INTO Users (Id, FirstName, LastName, Email, Password) VALUES (@id, @firstName, @lastName, @email, @password)", connection)) 
                {
                    command.Parameters.AddWithValue("id", user.Id);
                    command.Parameters.AddWithValue("firstName", user.FirstName);
                    command.Parameters.AddWithValue("lastName", user.LastName);
                    command.Parameters.AddWithValue("email", user.Email);
                    command.Parameters.AddWithValue("password", user.Password);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            usersDataGridView.DataSource = null;
            usersDataGridView.DataSource = GetUsersFromDb();
        }
    }
}
