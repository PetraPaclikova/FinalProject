using System.Numerics;

namespace Databaze;

class Program
{
    static List<Item> items = new List<Item>();
    static List<Antibody> antibodies = new List<Antibody>();
    static List<Vector> vectors = new List<Vector>();
    static List<Material> materials = new List<Material>();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("What you want to do?");
            Console.WriteLine("1. Add and item");
            Console.WriteLine("2. Search for item");
            Console.WriteLine("3. Search by room");
            Console.WriteLine("4. List of items");
            Console.WriteLine("5. Mark item for order");
            Console.WriteLine("6. List of items to order");
            Console.WriteLine("7.Mark items as arrived");
            Console.WriteLine("8. End");

            string input = InputQC.SafeReadLine();

            try
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter in which group new item belong (antibody, vector, material");
                        string itemInput = InputQC.SafeReadLine().Trim().ToLower();
                        if (itemInput == "antibody")
                        {
                            Console.WriteLine("Enter: name; catalogue number; room; storage conditions; reactivity");
                            string data = InputQC.SafeReadLine();
                            string[] parts = data.Split(';');
                            AddAntibody(parts);
                        }
                        else if (itemInput == "vector")
                        {
                            Console.WriteLine("Enter: name; room; storage conditions; resistance; size");
                            string data = InputQC.SafeReadLine();
                            string[] parts = data.Split(';');
                            AddVector(parts);
                        }
                        else if (itemInput == "material")
                        {
                            Console.WriteLine("Enter: name; catalogue number; room; storage conditions");
                            string data = InputQC.SafeReadLine();
                            string[] parts = data.Split(';');
                            AddMaterial(parts);
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry. Choose from groups: antibody, vector, material");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter what you want to search?:");
                        string keyword = InputQC.SafeReadLine();
                        FindItem(keyword);
                        break;
                    case "3":
                        Console.WriteLine("Enter room number:");
                        string roomInput = InputQC.SafeReadLine();
                        if (int.TryParse(roomInput, out int roomNumber))
                        {
                            SearchByRoom(roomNumber);
                        }
                        else
                        {
                            Console.WriteLine("Invalid room number.");
                        }
                        break;
                    case "4":
                        ListAllItems();
                        break;
                    case "5":
                        Console.WriteLine("Enter item name to mark for order:");
                        string nameToOrder = InputQC.SafeReadLine().Trim().ToLower();
                        MarkItemForOrder(nameToOrder);
                        break;
                    case "6":
                        ListItemsToOrder();
                        break;
                    case "7":
                        Console.WriteLine("Enter item name to mark as arrived:");
                        string arrivedName = InputQC.SafeReadLine().Trim();
                        MarkItemAsArrived(arrivedName);
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("unknown command");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba: {ex.Message}");
            }
        }
    }

    static void AddAntibody(string[] parts)
    {
        if (parts.Length < 5)
        {
            Console.WriteLine("Invalid entry.");
            return;
        }
        string name = parts[0].Trim();
        string catNumber = parts[1].Trim();
        if (!int.TryParse(parts[2], out int roomNumber))
        {
            Console.WriteLine("Invalid room number.");
            return;
        }
        string storage = parts[3].Trim();
        string reactivity = parts[4].Trim();

        var antibody = new Antibody(name, roomNumber, storage, catNumber, reactivity);
        items.Add(antibody);
        antibodies.Add(antibody);
        Console.WriteLine("Antibody added");
    }
    static void AddVector(string[] parts)
    {
        if (parts.Length < 5)
        {
            Console.WriteLine("Invalid entry.");
            return;
        }
        string name = parts[0].Trim();
        if (!int.TryParse(parts[1], out int roomNumber))
        {
            Console.WriteLine("Invalid room number.");
            return;
        }
        string storage = parts[2].Trim();
        string resistance = parts[3].Trim();
        if (!int.TryParse(parts[4], out int size))
        {
            Console.WriteLine("Invalid entry, size must by numeber.");
            return;
        }

        var vector = new Vector(name, roomNumber, storage, resistance, size);
        items.Add(vector);
        vectors.Add(vector);
        Console.WriteLine("Vector added");

    }
    static void AddMaterial(string[] parts)
    {
        if (parts.Length < 4)
        {
            Console.WriteLine("Invalid entry.");
            return;
        }
        string name = parts[0].Trim();
        string catNumber = parts[1].Trim();
        if (!int.TryParse(parts[2], out int roomNumber))
        {
            Console.WriteLine("Invalid room number.");
            return;
        }
        string storage = parts[3];

        var material = new Material(name, roomNumber, storage, catNumber);
        items.Add(material);
        materials.Add(material);
        Console.WriteLine("Material added");
    }
    static void FindItem(string keyword)
    {
        Console.WriteLine($"\nSearch results for \"{keyword}\":");

        foreach (var antibody in antibodies.Where(b => b.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"[Antibody] {antibody.Name}, Cat#: {antibody.CatNumber}, Reactivity: {antibody.Reactivity}, Room: {antibody.RoomNumber}, Storage: {antibody.StorageCondition}");
        }

        foreach (var vector in vectors.Where(b => b.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"[Vector] {vector.Name}, Resistance: {vector.Resistance}, Size: {vector.Size}, Room: {vector.RoomNumber}, Storage: {vector.StorageCondition}");
        }

        foreach (var material in materials.Where(b => b.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"[Material] {material.Name}, Cat#: {material.CatNumber}, Room: {material.RoomNumber}, Storage: {material.StorageCondition}");
        }
    }
    static void SearchByRoom(int roomNumber)
    {
        Console.WriteLine($"\nItems in room {roomNumber}:");

        var foundItems = items.Where(i => i.RoomNumber == roomNumber);
        foreach (var item in foundItems)
        {
            Console.WriteLine(item);
        }

        if (!foundItems.Any())
        {
            Console.WriteLine("No items found in this room.");
        }
    }
    static void ListAllItems()
    {
        Console.WriteLine("\nAll Items:");
        foreach (var item in items)
        {
            Console.WriteLine(item.ToString());
        }
    }
    static void MarkItemForOrder(string name)
    {
        var item = items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (item != null)
        {
            item.MarkedForOrder = true;
            Console.WriteLine($"{item.Name} marked for order.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
    static void ListItemsToOrder()
    {
        var itemsToOrder = items.Where(i => i.MarkedForOrder).ToList();

        if (itemsToOrder.Count == 0)
        {
            Console.WriteLine("No items are currently marked for order.");
        }
        else
        {
            Console.WriteLine("Items marked for order:");
            foreach (var item in itemsToOrder)
            {
                Console.WriteLine(item);
            }
        }
    }

    static void MarkItemAsArrived(string name)
    {
        var foundItem = items.FirstOrDefault(i =>
            i.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
            i.MarkedForOrder);

        if (foundItem != null)
        {
            foundItem.MarkedForOrder = false;
            Console.WriteLine($"Item '{foundItem.Name}' marked as arrived.");
        }
        else
        {
            Console.WriteLine("Item not found or not marked for order.");
        }
    }
}
