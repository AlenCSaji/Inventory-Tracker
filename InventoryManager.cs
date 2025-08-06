using System;
using System.Collections.Generic;

public class InventoryManager
{
    private List<Item> inventory = new List<Item>();

    public void AddItem()
    {
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();

        Console.Write("Enter quantity: ");
        int qty;
        while (!int.TryParse(Console.ReadLine(), out qty))
        {
            Console.Write("Invalid input. Enter a number: ");
        }

        inventory.Add(new Item { Name = name, Quantity = qty });
        Console.WriteLine("Item added.");
    }

    public void ViewInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Console.WriteLine("\nCurrent Inventory:");
        foreach (var item in inventory)
        {
            item.Print();
        }
    }
}