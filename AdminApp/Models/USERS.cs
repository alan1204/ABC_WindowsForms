using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdminApp.Models
{
    public class USERS
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Role { get; set; }


        public USERS(string Username, string Password, string Name, string Lastname, int Role)
        {
            this.Username = Username;
            this.Password = Password;
            this.Name = Name;
            this.Lastname = Lastname;
            this.Role = Role;
        }

        private static string connectionString = "Data Source=ALANALVAREZPC\\SQLEXPRESS;Initial Catalog=ABC;User=sa;Password=Lateralus.12";

        public static string Authentication(string user, string password)
        {
            string query = "select Role from USERS where Username = '"+ user +"' and Password = '"+ password +"'";

            try {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    string Role = command.ExecuteScalar().ToString();
                    connection.Close();
                    return Role;
                }
            }
            catch (Exception)
            {
                return "";
            }   
        }

        public static void AddUser(USERS User)
        {
            string query = "INSERT INTO USERS(Name, LastName, Role, Username, Password) " +
                "VALUES(@Name,@LastName,@Role,@Username,@Password)";

            try
            {
                using(var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", User.Name);
                    command.Parameters.AddWithValue("@LastName", User.Lastname);
                    command.Parameters.AddWithValue("@Role", User.Role);
                    command.Parameters.AddWithValue("@Username", User.Username);
                    command.Parameters.AddWithValue("@Password", User.Password);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        public static DataTable FillRoles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("select ID, Type from ROLES", connection))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "Please select";
                    dt.Rows.InsertAt(row, 0);

                    return dt;
                }
            }
        }

    }
}
