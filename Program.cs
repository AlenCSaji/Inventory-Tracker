using System;

class Program
{
    static InventoryManager manager = new InventoryManager();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=== Inventory Menu ===");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            if (input == "1")
                manager.AddItem();
            else if (input == "2")
                manager.ViewInventory();
            else if (input == "3")
                break;
            else
                Console.WriteLine("Invalid option. Try again.");
        }
    }
}