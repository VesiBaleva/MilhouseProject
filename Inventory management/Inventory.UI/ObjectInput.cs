using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ObjectInput
{
    internal static void MakePurchase()
    {
        Console.WriteLine("== Suppliers ==\n");
        int counter = 1;
        foreach (var supplier in Inventory.MainStore.Suppliers)
        {
            Console.WriteLine("║ {0, -3} {1}",counter++, supplier);
        }
        Console.WriteLine("\n>> Select supplier by ID");
        Console.Write("Supplier ID: ");
        int supplierID = User.GetMenuChoice(Inventory.MainStore.Suppliers.Count) - 1;
        var list = Inventory.MainStore.Suppliers[supplierID].Goods.Keys.ToList();
        Draw.TableView(Good.Title(), list);
        
        Console.WriteLine("\n>> Select good to buy\n");
        int goodID = User.GetSupplierGoodID(Inventory.MainStore.Suppliers[supplierID].Goods);
        int quantity = User.GetInt("Quantity: ");
        decimal price = Inventory.MainStore.Suppliers[supplierID].Goods[Inventory.MainStore.KnownGoods.First(x=>x.ID == goodID)];

        Inventory.MainStore.Purchases.Add(new Purchase(
            Inventory.MainStore.KnownGoods[goodID - 1],
            quantity,
            Inventory.MainStore.Suppliers[supplierID],
            price
            ));

        Save.This(File.Purchases);
    }
}

