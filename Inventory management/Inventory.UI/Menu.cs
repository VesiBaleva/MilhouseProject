using System.Collections.Generic;
using System;

public class Menu
{
    public List<MenuItem> MenuItems { get; set; }
    public string Title { get; set; }

    public Menu(string title)
    {
        this.Title = title;
        this.MenuItems = new List<MenuItem>();
    }

    public Menu(string title, List<MenuItem> menuItems)
    {
        this.Title = title;
        this.MenuItems = menuItems;
    }
}

