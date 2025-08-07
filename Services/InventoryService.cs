using System;
using System.Collections.Generic;
using System.Linq;
using InventoryTracker.Models;

namespace InventoryTracker.Services
{
    public class InventoryService
    {
        private readonly DatabaseService _db = new();

        public void AddItem(Item item)
        {
            string query = "INSERT INTO Inventory (Name, Quantity) VALUES (@name, @qty)";
            if (item.Name != null)
            { 
                var parameters = new Dictionary<string, object>
                {
                    { "@name", item.Name },
                    { "@qty", item.Quantity }
                };
                 _db.ExecuteNonQuery(query, parameters);
            }
           
        }

        public List<Item> GetAllItems()
        {
            return _db.ExecuteReader("SELECT * FROM Inventory");
        }

        public void UpdateItem(int id, int newQuantity)
        {
            string query = "UPDATE Inventory SET Quantity = @qty WHERE Id = @id";
            var parameters = new Dictionary<string, object>
            {
                { "@qty", newQuantity },
                { "@id", id }
            };
            _db.ExecuteNonQuery(query, parameters);
        }

        public void DeleteItem(int id)
        {
            string query = "DELETE FROM Inventory WHERE Id = @id";
            var parameters = new Dictionary<string, object>
            {
                { "@id", id }
            };
            _db.ExecuteNonQuery(query, parameters);
        }
    }
}
