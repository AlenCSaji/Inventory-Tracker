public class Item
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public void Print()
    {
        Console.WriteLine($"\"{Name}\" - {Quantity} units");
    }
}