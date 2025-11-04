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

namespace seminar_8_PAW
{
    public partial class Form1 : Form
    {
        private string _connectionString = "";
        public Form1()
        {
            InitializeComponent();
            usersDataGrid.DataSource = GetUsersFromDatabase();
            usersDataGrid.AutoGenerateColumns = true;   
        }

        private List<User> GetUsersFromDatabase()
        {
            var users = new List<User>();

            var connections = new SqlConnection(_connectionString);
            connections.Open();

            var command = new SqlCommand("SELECT Id, FirstName, LastName, Password, Email FROM Users", connections);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var user = new User();
                user.Id = Guid.Parse(reader["Id"].ToString());
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["LastName"].ToString();
            }

            connections.Close();

            return users;
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.FirstName = "Liviu";
            user.LastName = "Rebreanu";
            user.Password = "43211234";
            user.Email = "r.liviu@hotmail.com";

            var connection  = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand(
                $"INSERT INTO Users(Id, FirstName, LastName, Password, Email) " +
                $"VALUES(@id, @firstname, @lastname, @password, @email)", connection);

            command.Parameters.AddWithValue("id", user.Id);
            command.Parameters.AddWithValue("firstname", user.FirstName);
            command.Parameters.AddWithValue("lastname", user.LastName);
            command.Parameters.AddWithValue("password", user.Password);
            command.Parameters.AddWithValue("email", user.Email);

            command.ExecuteNonQuery();
            connection.Close();

            usersDataGrid.DataSource = null;
            usersDataGrid.DataSource = GetUsersFromDatabase();
        }
    }
}
