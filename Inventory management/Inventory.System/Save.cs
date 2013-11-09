using System.IO;

public static class Save
{
    public static void This(string file)
    {
        using (StreamWriter output = new StreamWriter(file))
        {
            switch (file)
            {
                case File.Employees:
                    foreach (var obj in Inventory.MainStore.Employees)
                    {
                        output.WriteLine("{0}|{1}|{2}|{3}", obj.FirstName, obj.LastName, obj.Position, obj.GrossSalary);
                    }
                    break;
                case File.Goods:
                    foreach (var obj in Inventory.MainStore.KnownGoods)
                    {
                        output.WriteLine("{0}|{1}|{2}|{3}", obj.ID, obj.Name, obj.Unit, obj.Category);
                    }
                    break;
                case File.Suppliers:
                    foreach (var obj in Inventory.MainStore.Suppliers)
                    {
                        output.Write("{0}|{1}|{2}|", obj.Name, obj.ContactInfo, obj.Goods.Count);
                        foreach (var good in obj.Goods)
                        {
                            output.Write("{0}|{1}|", good.Key.ID, good.Value);
                        }
                        output.WriteLine();
                    }
                    break;
                case File.StoreGoods:
                    foreach (var obj in Inventory.MainStore.StoreGoods)
                    {
                        output.WriteLine("{0}|{1}|{2}|{3}|{4}", obj.Good.ID, obj.Barcode, obj.Price, obj.ExpirationDate, obj.Quantity);
                    }
                    break;
                case File.Purchases:
                    foreach (var obj in Inventory.MainStore.Purchases)
                    {
                        output.WriteLine("{0}|{1}|{2}|{3}|{4}", obj.Good.ID, Inventory.MainStore.Suppliers.IndexOf(obj.Supplier), obj.Price, obj.Quantity, obj.Date);
                    }
                    break;
                case File.Sales:
                    foreach (var obj in Inventory.MainStore.Sales)
                    {
                        output.WriteLine("{0}|{1}|{2}|{3}|{4}", obj.Good.ID - 1, obj.Quantity, obj.Employee.FirstName, obj.Employee.LastName, obj.Date);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public static void All()
    {
        This(File.Goods);
        This(File.Employees);
        This(File.Suppliers);
        This(File.StoreGoods);
        This(File.Purchases);
        This(File.Sales);
    }
}