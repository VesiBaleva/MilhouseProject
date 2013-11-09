using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

public static class User
{
    public static int startRow;
    public static int startCol;

    internal static int GetMenuChoice(int maxValue)
    {
        SavePosition();
        int choice = 0;
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey(true);
                while (choice == 0)
                {
                    if (char.IsDigit(input.KeyChar))
                    {
                        choice = int.Parse(input.KeyChar.ToString());
                        if (choice != 0 && choice <= maxValue)
                        {
                            Draw.BlankPage();
                            return choice;
                        }
                        else
                        {
                            choice = 0;
                        }
                    }
                    input = Console.ReadKey(true);
                }
            }
        }
    }

    public static void SavePosition()
    {
        startRow = Console.CursorTop;
        startCol = Console.CursorLeft;
    }

    internal static int GetSupplierGoodID(System.Collections.Generic.Dictionary<Good, decimal> dictionary)
    {
        string input;
        int id = 0;
        while (true)
        {
            SavePosition();

            Console.Write("Select good ID: ");
            input = Console.ReadLine();
            if (int.TryParse(input, out id))
            {
                if (dictionary.ContainsKey(Inventory.MainStore.KnownGoods[id - 1]))
                {
                    return id;
                }
                else
                {
                    Console.Write("No such ID! Press any key to try again");
                    Console.ReadKey();
                    Draw.ClearLastTwoRows(User.startCol, User.startRow);
                }
            }
            else
            {
                Console.Write("Not a number! Press any key to try again");
                Console.ReadKey();
                Draw.ClearLastTwoRows(User.startCol, User.startRow);
            }
        }
    }

    internal static int GetInt(string question)
    {
        string input;
        int id = 0;
        while (true)
        {
            SavePosition();

            Console.Write(question);
            input = Console.ReadLine();
            if (int.TryParse(input, out id))
            {
                return id;
            }
            else
            {
                Console.Write("No such ID! Press any key to try again");
                Console.ReadKey();
                Draw.ClearLastTwoRows(User.startCol, User.startRow);
            }
        }
    }

    internal static int GetGoodCategory()
    {
        int counter = 1;
        Console.WriteLine("\n== Good categories ==\n");

        foreach (var item in Enum.GetNames(typeof(GoodsCategory)))
        {
            Console.WriteLine("{0,-2} {1}", counter + ")", item);
            counter++;
        }
        return User.GetInt("\nChoose Category: ") - 1;
    }

    internal static object InteractiveSearch<T>(List<T> list)
    {
        StringBuilder str = new StringBuilder();
        StoreGood result = new StoreGood();
        
        Console.Write("Search for good: ");
        var tempList = new List<Good>();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey(false);
                Draw.BlankPage();
                Console.Write("Search for good: ");

                if (input.Key == ConsoleKey.Enter)
                {
                    if (tempList.Count() == 1)
                    {
                        Draw.BlankPage();
                        return tempList[0];
                    }
                    break;
                }
                else if (input.Key == ConsoleKey.Backspace && str.Length > 0)
                {
                    str.Remove(str.Length - 1, 1);
                }
                else
                {
                    str.Append(input.KeyChar.ToString());
                }
                Console.WriteLine(str);
                tempList = Inventory.MainStore.KnownGoods.Where(x => x.Name.IndexOf(str.ToString(), StringComparison.OrdinalIgnoreCase) >= 0).ToList<Good>();
                List<Good> shortList = new List<Good>();
                if (tempList.Count > 25)
                {
                    shortList = tempList.GetRange(0, 25);
                }
                else
                {
                    shortList = tempList;
                }
                Draw.TableView(Good.Title(), shortList);
                if (tempList.Count() == 1)
                {
                    ">> Press enter to select current good".Write(ConsoleColor.Yellow);
                }
            }
        }
        Draw.BlankPage();
        return result;
    }

    internal static decimal GetDecimal(string question)
    {
        string input;
        decimal id = 0;
        while (true)
        {
            SavePosition();

            Console.Write(question);
            input = Console.ReadLine();
            if (decimal.TryParse(input, out id))
            {
                return id;
            }
            else
            {
                Console.Write("Wrong input");
                Console.ReadKey();
                Draw.ClearLastTwoRows(User.startCol, User.startRow);
            }
        }
    }
}