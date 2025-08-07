using InventoryTracker.Models;
using InventoryTracker.Services;

InventoryService service = new();

Console.WriteLine("\n >> Welcome to MY INVENTORY <<");
while (true)
{
    Console.WriteLine("\n\n |> MENU <| \n");
    Console.WriteLine("1. Add Item");
    Console.WriteLine("2. View Inventory");
    Console.WriteLine("3. Update Item");
    Console.WriteLine("4. Delete Item");
    Console.WriteLine("5. Exit");
    Console.Write("\n> Please choose an option to continue: ");
    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("\n > Add Item <\n");
            Console.Write("Item name: ");
            string? name = Console.ReadLine();
            Console.Write("Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int qty))
                service.AddItem(new Item { Name = name, Quantity = qty });
            else
                Console.WriteLine("Invalid quantity.");
            break;

        case "2":
            var items = service.GetAllItems();
            Console.WriteLine("\n--- Inventory List ---");
            foreach (var item in items)
                Console.WriteLine($"{item.Id}. {item.Name} - Qty: {item.Quantity}");
            break;

        case "3":
            Console.Write("Enter Item ID to update: ");
            int.TryParse(Console.ReadLine(), out int updateId);
            Console.Write("New quantity: ");
            int.TryParse(Console.ReadLine(), out int newQty);
            service.UpdateItem(updateId, newQty);
            break;

        case "4":
            Console.Write("Enter Item ID to delete: ");
            int.TryParse(Console.ReadLine(), out int deleteId);
            service.DeleteItem(deleteId);
            break;

        case "5":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
