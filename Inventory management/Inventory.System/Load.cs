using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

static class Load
{
    static Store MainStore = Inventory.MainStore;
    
    // Load All
    public static void All()
    {
        Employees();
        Goods();
        Suppliers();
        StoreGoods();
        Sales();
        Purchases();
    }

    // Load StoreGoods
    public static void StoreGoods()
    {
        LoadData(StoreGoodsAction, File.StoreGoods);
    }

    public static void StoreGoodsAction(string[] data)
    {
        StoreGood obj = new StoreGood();
        obj.Good = Inventory.MainStore.KnownGoods.Find(x => x.ID == int.Parse(data[0]));
        obj.Barcode = int.Parse(data[1]);
        obj.Price = decimal.Parse(data[2]);
        obj.ExpirationDate = DateTime.Parse(data[3]);
        obj.Quantity = double.Parse(data[4]);
        MainStore.StoreGoods.Add(obj);
    }

    // Load Sales
    public static void Sales()
    {
        LoadData(SalesAction, File.Sales);
    }

    public static void SalesAction(string[] data)
    {
        MainStore.Sales.Add(new Sale(MainStore.KnownGoods[int.Parse(data[0])], double.Parse(data[1]), MainStore.Employees.Where(x=>x.FirstName == data[2]).ToList()[0], DateTime.Parse(data[4])));
    }

    // Load Purchases
    public static void Purchases()
    {
        LoadData(PurchasesAction, File.Purchases);
    }

    public static void PurchasesAction(string[] data)
    {
        MainStore.Purchases.Add(new Purchase(
            MainStore.KnownGoods[int.Parse(data[0])],
            double.Parse(data[3]),
            MainStore.Suppliers[int.Parse(data[1])],
            decimal.Parse(data[2])
        ));
    }

    // Load all known Goods
    public static void Goods()
    {
        LoadData(GoodsAction, File.Goods);
    }

    public static void GoodsAction(string[] data)
    {
        Unit unit = (Unit)Enum.Parse(typeof(Unit), data[2]);
        GoodsCategory category = (GoodsCategory)Enum.Parse(typeof(GoodsCategory), data[3]);
        MainStore.KnownGoods.Add(new Good(int.Parse(data[0]), data[1], unit, category));
    }

    // Load all Employees
    public static void Employees()
    {
        LoadData(EmployeesAction, File.Employees);
    }

    public static void EmployeesAction(string[] data)
    {
        Position position = (Position)Enum.Parse(typeof(Position), data[2]);
        MainStore.Employees.Add(new Employee(data[0], data[1], position, decimal.Parse(data[3])));
    }

    // Load Suppliers
    public static void Suppliers()
    {
        LoadData(SuppliersAction, File.Suppliers);
    }

    public static void SuppliersAction(string[] data)
    {
        Supplier temp = new Supplier(data[0], data[1]);
        for (int i = 0; i < int.Parse(data[2]) * 2; i = i + 2)
        {
            temp.Goods.Add(Inventory.MainStore.KnownGoods[int.Parse(data[3 + i])], decimal.Parse(data[3 + i + 1]));
        }
        MainStore.Suppliers.Add(temp);
    }

    //
    public static void LoadData(Action<string[]> load, string fileName)
    {
        StreamReader input = new StreamReader(fileName);
        using (input)
        {
            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                if (data.Length <= 1)
                {
                    break;
                }
                load(data);
            }
        }
    }

}
