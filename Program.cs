public static class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Backpack Class Assignment \n");

        Item lunch = new("Lunch");
        Item jacket = new("Jacket");

        Backpack smallBlue = new("blue", "small");
        Backpack mediumRed = new("red", "medium");
        Backpack largeGreen = new("green", "large");

        smallBlue.OpenBag();
        smallBlue.PutIn(lunch);
        smallBlue.PutIn(jacket);
        smallBlue.CloseBag();

        smallBlue.OpenBag();
        smallBlue.TakeOut(jacket);
        smallBlue.CloseBag();
    }
}

// backpack class to store items
public class Backpack
{
    public string Color { get; set; }
    public string Size { get; set; }
    public List<Item> Items { get; set; }
    public bool IsOpen { get; set; }

    // creates closed backpack from given color and size with no items
    public Backpack(string color, string size)
    {
        Color = color.ToLower();
        Size = size.ToLower();
        Items = new();
        IsOpen = false;
    }

    // opens bag and gives confirmation
    public void OpenBag()
    {
        IsOpen = true;
        Console.WriteLine($"{this} opened.");
    }

    // closes bag and gives confirmation
    public void CloseBag()
    {
        IsOpen = false;
        Console.WriteLine($"{this} closed.");
    }

    // puts item in bag if its open, gives confirmation
    public void PutIn(Item item)
    {
        if (IsOpen)
        {
            Items.Add(item);
            Console.WriteLine($"{item} was added to {this}.");
        }
        else
        {
            Console.WriteLine("Can't put item in closed backpack.");
        }
    }

    // take item from bag if its open and item exists in bag, gives confirmation
    public void TakeOut(Item item)
    {
        if (IsOpen)
        {
            // item is in backpack
            if (Items.Find(x => x == item) != null)
            {
                Items.Remove(item);
                Console.WriteLine($"{item} was removed from {this}.");
            }
            // item isnt in backpack
            else
            {
                Console.WriteLine($"{item} was not found in {this}.");
            }
        }
        else
        {
            Console.WriteLine("Can't take item from closed backpack.");
        }
    }

    public override string ToString()
    {
        return $"{Size} {Color} backpack";
    }
}

// item class with name
public class Item
{
    public string Name { get; set; }

    public Item(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

