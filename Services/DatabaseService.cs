using Microsoft.Data.SqlClient;
using InventoryTracker.Models;

namespace InventoryTracker.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString =
            "Server=localhost\\SQLEXPRESS;Database=InventoryDB;Trusted_Connection=True;Encrypt=False;";

        public void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using SqlConnection conn = new(_connectionString);
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            foreach (var param in parameters)
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            cmd.ExecuteNonQuery();
        }

        public List<Item> ExecuteReader(string query)
        {
            List<Item> items = new();
            using SqlConnection conn = new(_connectionString);
            conn.Open();
            using SqlCommand cmd = new(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                items.Add(new Item
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Quantity = Convert.ToInt32(reader["Quantity"])
                });
            }
            return items;
        }
    }
}
