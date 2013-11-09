using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Menus
{
    public static Menu MainMenu = new Menu("Login as Manager or as Cashier",
        new List<MenuItem>{
            new MenuItem("Manager"),
            new MenuItem("Cashier"),
            new MenuItem("Save and exit")}
        );

    public static Menu Manager = new Menu("Choose action",
        new List<MenuItem>{
            new MenuItem("Make purchase"),
            new MenuItem("See Employees"),
            new MenuItem("See store goods"),
            new MenuItem("See all goods"),
            new MenuItem("Add new good to list"),
            new MenuItem("See sales"),
            new MenuItem("Back")}
        );

    public static Menu Cashier = new Menu("Choose action",
        new List<MenuItem>{
            new MenuItem("Sell good by ID"),
            new MenuItem("Sell good by Name"),
            new MenuItem("Show all goods"),
            new MenuItem("Show goods by Category"),
            new MenuItem("Back")}
        );

    public static void Draw(Menu menu)
    {
        Console.WriteLine("== " + menu.Title + " ==");
        int number = 1;
        Console.WriteLine();
        foreach (var menuItem in menu.MenuItems)
        {
            Console.WriteLine(number + ") " + menuItem.Text);
            number++;
        }
        Console.WriteLine();
        Console.Write("Your choice: ");
    }
}

