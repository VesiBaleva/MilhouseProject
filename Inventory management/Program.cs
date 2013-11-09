using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

public class Inventory
{
    public static Store MainStore = new Store();

    static void Main()
    {
        Initialize.All();
        Save.All();
        Events.Close();
        Console.WriteLine("= = Thank you for using Milhouse software = =\n");
    }
}