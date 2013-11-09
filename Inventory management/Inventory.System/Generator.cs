using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Generator
{
    public abstract object Obj { get; set; }
    public Generator() { }
}

public class GoodGenerator : Generator
{
    Good good = new Good("New", Unit.kilogram, GoodsCategory.Alcohol);

    public GoodGenerator()
    {
        Console.Write("New good name: ");
        good.Name = Console.ReadLine();
        Console.WriteLine("Choose unit?");
        int counter = 1;
        foreach (var item in Enum.GetNames(typeof(Unit)))
        {
            Console.WriteLine(" {0}) {1}", counter, item);
            counter++;
        }
        int choice = User.GetInt("\nChoose Unit: ");
        good.Unit = (Unit)(choice - 1);

        choice = User.GetGoodCategory();
        good.Category = (GoodsCategory)choice;
        Draw.BlankPage();
    }

    public override object Obj
    {
        get
        {
            return good;
        }
        set
        {
            good = (Good)value;
        }
    }
}

public class EmployeeGenerator : Generator
{

    Employee employee = new Employee("XXXX", "XXXXX", Position.Cashier, 500);
       public EmployeeGenerator()
            {
           
                employee.FirstName = Console.ReadLine();
                employee.LastName = Console.ReadLine();
                Console.WriteLine("Please choose employee position\n1Cashier\n2Guard\n3UnloadInspector");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        employee.Position = Position.Cashier;
                        break;
                    case 2:
                        employee.Position = Position.Guard;
                        break;
                    case 3:
                        employee.Position = Position.UnloadInspector;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                employee.GrossSalary = decimal.Parse(Console.ReadLine());
            }
    public override object Obj
    {
        get
        {   
            return employee;
        }
        set
        {
            employee = (Employee)value;
        }
    }
}

public static class Factory
{
    public static Generator Get(int id)
    {
        switch (id)
        {
            case 1:
                return new EmployeeGenerator();
            default:
                return new GoodGenerator(); //tuka moje da vikame kakvoto s iskame, primerno moje da e generatora na good i pri
           
                                     //Factory(8), Factory(7) pak da si wika generatora na good
        }
    }
}
