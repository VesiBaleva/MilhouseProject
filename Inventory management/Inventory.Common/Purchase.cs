using System;

public class Purchase : Deal
{
    private decimal price;
    
    // Properties
    public decimal Price
    {
        get { return price; }
        set
        {
            if (value > 0)
            {
                price = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Price can`t be negative!");
            }
        }
    }

    public Supplier Supplier { get; set; }

    // Constructors
    public Purchase(Good good, double quantity, Supplier supplier, decimal price)
        : base(good, quantity)
    {
        this.Supplier = supplier;
        this.Price = price;
    }
}