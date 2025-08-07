using InventoryTracker.Models;
using System;
using System.Collections.Generic;

namespace InventoryTracker.Services
{
    public class InventoryService
    {
        private readonly List<Item> _inventory = new();

        public void AddItem(string name, int quantity)
        {
            _inventory.Add(new Item { Name = name, Quantity = quantity });
            Console.WriteLine(" >> Item added successfully. <<\n");
        }

        public void ViewInventory()
        {
            if (_inventory.Count == 0)
            {
                Console.WriteLine(" >> !! Inventory is empty. !! <<\n");
                return;
            }

            Console.WriteLine("\n >> Current Inventory <<");
            foreach (var item in _inventory)
            {
                Console.WriteLine($"- {item.Name}: {item.Quantity}");
            }
            Console.WriteLine();
        }

        public void UpdateItem(string name, int newQuantity)
        {
            var item = _inventory.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.Quantity = newQuantity;
                Console.WriteLine("✅ Item updated successfully.\n");
            }
            else
            {
                Console.WriteLine("❌ Item not found.\n");
            }
        }

        public void DeleteItem(string name)
        {
            var item = _inventory.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                _inventory.Remove(item);
                Console.WriteLine("✅ Item deleted successfully.\n");
            }
            else
            {
                Console.WriteLine("❌ Item not found.\n");
            }
        }

    }
}