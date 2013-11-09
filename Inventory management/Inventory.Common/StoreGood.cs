using System;
public class StoreGood : IExpirable, IReportable
{
    //fields
    private int barcode;
    private decimal price;
    private DateTime expirationDate;
    private double quantity;

    //properties

    public double Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public Good Good { get; set; }

    public int Barcode
    {
        get { return barcode; }
        set { barcode = value; }
    }

    //any validations in properties for Price and ExpiredDate
    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The price can not be negative!");
            }
            this.price = value;
        }
    }

    public DateTime ExpirationDate
    {
        get { return this.expirationDate; }
        set
        {
            if (value < DateTime.Now)
            {
                throw new ArgumentException("The date of expired have to be greater then now!");
            }
            this.expirationDate = value;
        }
    }

    // Constructors
    public StoreGood()
    {
    }

    public StoreGood(Good good, int barcode, decimal price, DateTime expirationDate)
    {
        this.Good = good;
        this.Barcode = barcode;
        this.Price = price;
        this.ExpirationDate = expirationDate;
    }

    public StoreGood(Good good, int barcode, decimal price, DateTime expirationDate, double Quantity)
        : this(good, barcode, price, expirationDate)
    {
        this.Quantity = quantity;
    }

    public bool IsExpired()
    {
        if (this.ExpirationDate < DateTime.Now)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return String.Format("║ {0,-3} ║ {1, -20} ║ {2, -15} ║ {3, -20} ║ {4, -10} ║ {5, -20:dd.MM.yyyy} ║", this.Good.ID, this.Good.Name, this.Good.Unit, this.Good.Category, this.Quantity, this.ExpirationDate);
    }

    public static string Title()
    {
        return String.Format("║ {0,-3} ║ {1, -20} ║ {2, -15} ║ {3, -20} ║ {4, -10} ║ {5, -20} ║", "ID", "NAME", "UNIT", "CATEGORY", "QUANTITY", "EXPIRATION DATE");
    }

    public void Report(string s)
    {
        throw new NotImplementedException();
    }
}
