using System.Collections.Generic;
using System.Linq;

public static class Navigation
{
    public static void Start()
    {
        int choice = 0;
        int depth = 0;
        while (depth == 0)
        {
            Menus.Draw(Menus.MainMenu);
            choice = User.GetMenuChoice(Menus.MainMenu.MenuItems.Count);
            depth++;
            while (depth == 1)
            {
                int managerAction = 0;
                int cashierAction = 0;
                switch (choice)
                {
                    case 1:
                        Menus.Draw(Menus.Manager);
                        managerAction = User.GetMenuChoice(Menus.Manager.MenuItems.Count);
                        switch (managerAction)
                        {
                            case 1:
                                ObjectInput.MakePurchase();
                                break;
                            case 2:
                                Draw.TableView(Employee.Title(), Inventory.MainStore.Employees);
                                break;
                            case 3:
                                Draw.TableView(StoreGood.Title(), Inventory.MainStore.StoreGoods);
                                break;
                            case 4:
                                Draw.TableView(Good.Title(), Inventory.MainStore.KnownGoods);
                                break;
                            case 5:
                                var obj = Factory.Get(0);
                                Inventory.MainStore.KnownGoods.Add((Good)obj.Obj);
                                break;
                            case 6:
                                Draw.TableView(Sale.Title(), Inventory.MainStore.Sales);
                                break;
                            case 7:
                                depth--;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        Menus.Draw(Menus.Cashier);
                        cashierAction = User.GetMenuChoice(Menus.Cashier.MenuItems.Count);
                        switch (cashierAction)
	                    {
                            case 1:
                                break;
                            case 2:
                                var obj = User.InteractiveSearch(Inventory.MainStore.StoreGoods);
                                decimal quantity = 0;
                                if (obj is Good)
                                {
                                    quantity = User.GetDecimal("Quantity: ");
                                    Draw.BlankPage();
                                    Inventory.MainStore.Sales.Add(new Sale((Good)obj, (double)quantity, Inventory.MainStore.Employees[1]));
                                }
                                Draw.BlankPage();
                                break;
                            case 3:
                                Draw.TableView(Good.Title(), Inventory.MainStore.KnownGoods);
                                break;
                            case 4:
                                int category = User.GetGoodCategory();
                                Draw.BlankPage();
                                Draw.TableView(Good.Title(), Inventory.MainStore.KnownGoods.FindAll(x=>x.Category == (GoodsCategory)category));
                                break;
                            case 5:
                                depth--;
                                break;
		                    default:
                                break;
	                    }
                        break;
                    case 3:
                        depth = -1;
                        break;
                    default:
                        break;
                } 
            }
        }
    }
}
