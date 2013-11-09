using System.Collections.Generic;
using System;

public class Sale : Deal
{
    public Employee Employee { get; set; }

    //TODO:

    // Constructor

    public Sale(Good good, double quantity, Employee employee)
        : base(good, quantity)
    {
        this.Employee = employee;
    }

    public Sale(Good good, double quantity, Employee employee, DateTime date)
        : this(good, quantity, employee)
    {
        this.Date = date;
    }

    public override string ToString()
    {
        return String.Format("║ {0,-18} ║ {1, -10} ║ {2, -30} ║ {3, -14:dd.MM.yyyy} ║", this.Good.Name, this.Quantity, this.Employee.FirstName + " " +this.Employee.LastName, this.Date);
    }

    public static string Title()
    {
        //TODO: CHANGE TO SALE FORMAT
        return String.Format("║ {0,-18} ║ {1, -10} ║ {2, -30} ║ {3, -14} ║", "GOOD", "QUANTITY", "EMPLOYEE", "DATE");
    }
}
