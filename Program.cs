using InventoryTracker.Services;
using System;

namespace InventoryTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryService service = new();

            while (true)
            {

                Console.WriteLine(">>>| Inventory Tracker |<<<");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Update Item");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter item name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int qty))
                            service.AddItem(name, qty);
                        else
                            Console.WriteLine(" !! Invalid quantity. !!");
                        break;

                    case "2":
                        service.ViewInventory();
                        break;

                    case "3":
                        Console.Write("Enter item name to update: ");
                        string updateName = Console.ReadLine();

                        Console.Write("Enter new quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int newQty))
                            service.UpdateItem(updateName, newQty);
                        else
                            Console.WriteLine(" !! Invalid quantity. !!");
                        break;

                    case "4":
                        Console.Write("Enter item name to delete: ");
                        string deleteName = Console.ReadLine();
                        service.DeleteItem(deleteName);
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine(" !! Invalid choice. !! \n");
                        break;
                }
            }
        }
    }
}
