using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdminApp.Models
{
    public class PRODUCT
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public PRODUCT(string Name, string Description, int Stock)
        {
            this.Name = Name;
            this.Description = Description;
            this.Stock = Stock;
        }

        private static string connectionString = "Data Source=ALANALVAREZPC\\SQLEXPRESS;Initial Catalog=ABC;User=sa;Password=Lateralus.12";

        public static void AddProduct(PRODUCT product)
        {
            string query = "INSERT INTO PRODUCTS(Name, Description, Stock) " +
                "VALUES(@Name,@Description,@Stock)";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Stock", product.Stock);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
