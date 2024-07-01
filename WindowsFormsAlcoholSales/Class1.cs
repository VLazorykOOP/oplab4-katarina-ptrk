using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsAlcoholSales
{
    public class DatabaseManager
    {
        private string connectionString = "Server=USER-PC\\SQLEXPRESS;Database=AlcoholSales;Integrated Security=True;";

        public DataTable GetAllRecords()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Alcohols", conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void InsertRecord(string type, string brand, string manufacturer, DateTime expiryDate, string supplier, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Alcohols (Type, Brand, Manufacturer, ExpiryDate, Supplier, Price) VALUES (@Type, @Brand, @Manufacturer, @ExpiryDate, @Supplier, @Price)", conn);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Manufacturer", manufacturer);
                cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                cmd.Parameters.AddWithValue("@Supplier", supplier);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateRecord(int id, string type, string brand, string manufacturer, DateTime expiryDate, string supplier, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Alcohols SET Type = @Type, Brand = @Brand, Manufacturer = @Manufacturer, ExpiryDate = @ExpiryDate, Supplier = @Supplier, Price = @Price WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Manufacturer", manufacturer);
                cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                cmd.Parameters.AddWithValue("@Supplier", supplier);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Alcohols WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
