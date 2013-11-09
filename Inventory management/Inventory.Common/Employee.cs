using System;

public class Employee
{
    //fields of class Employee
    private string firstName;
    private string lastName;
    private Position position;
    private decimal grossSalary; //брутна заплата

    //properties and controls input data
    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new InvalidNameException("Can not input empty first name");
            }
            else if (value.Length > 100)
            {
                throw new InvalidNameException(String.Format("Can not input name greather than 100 symbols! Input value: {0}", value));
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new InvalidNameException("Can not input empty last name");
            }
            else if (value.Length > 100)
            {
                throw new InvalidNameException(String.Format("Can not input name greather than 100 symbols! Input value: {0}", value));
            }
            this.lastName = value;
        }
    }

    public Position Position
    {
        get
        {
            return this.position;
        }
        set
        {
            this.position = value;
        }
    }

    public decimal GrossSalary
    {
        get
        {
            return this.grossSalary;
        }
        set
        {
            if (value < 0)
            {
                throw new InvalidSalaryException(String.Format("Salary can not be negative: {0}", value));
            }
            this.grossSalary = value;
        }
    }

    //constructor
    public Employee(string firstName, string lastName, Position position, decimal grossSalary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Position = position;
        this.GrossSalary = grossSalary;
    }
    public Employee(string firstName, string lastName, Position position)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Position = position;
        this.GrossSalary = 500.00M; //starting salary
    }
    public override string ToString()
    {
        return String.Format("║ {0, -40} ║ {1, -22} ║ $ {2, -20} ║", this.FirstName + " " + this.LastName, this.Position, this.GrossSalary);
    }
    public static string Title()
    {
        return String.Format("║ {0, -40} ║ {1, -22} ║ {2, -22} ║", "NAME", "POSITION", "SALARY");
    }
}