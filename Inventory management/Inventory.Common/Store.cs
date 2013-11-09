using System.Collections.Generic;
using System.Linq;
using System;

public class Store : IReportable, IExpirable
{
    private List<Good> knownGoods;
    private List<Employee> employees;
    private List<Supplier> suppliers;
    private List<Sale> sales;
    private List<StoreGood> storeGoods;
    private List<Purchase> purchases;

    public List<Purchase> Purchases
    {
        get { return purchases; }
        set { purchases = value; }
    }

    public List<StoreGood> StoreGoods
    {
        get { return storeGoods; }
        set { storeGoods = value; }
    }
    
    public List<Sale> Sales
    {
        get { return sales; }
        set { sales = value; }
    }
    
    public List<Supplier> Suppliers
    {
        get { return suppliers; }
        set { suppliers = value; }
    }
    
    public List<Employee> Employees
    {
        get { return employees; }
        set { employees = value; }
    }
    
    public List<Good> KnownGoods
    {
        get { return knownGoods; }
        set { knownGoods = value; }
    }
    
    public Store()
    {
        this.StoreGoods = new List<StoreGood>();
        this.Employees = new List<Employee>();
        this.KnownGoods = new List<Good>();
        this.Sales = new List<Sale>();
        this.Suppliers = new List<Supplier>();
        this.Purchases = new List<Purchase>();
    }

    public void Report(string objName)
    {
        Console.WriteLine("== Store report ==");
        Console.WriteLine("Current employees: {0}", Inventory.MainStore.Employees.Count);
        Console.WriteLine("Number of goods in store: {0}", Inventory.MainStore.StoreGoods.Count);
        Console.WriteLine("Number of goods in list: {0}", Inventory.MainStore.KnownGoods.Count);
        Console.WriteLine("Current suppliers: {0}", Inventory.MainStore.Suppliers.Count);
    }

    public bool IsExpired()
    {
        throw new NotImplementedException();
    }
}
