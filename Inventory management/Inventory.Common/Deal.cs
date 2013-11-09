using System;

public abstract class Deal
{
    // Fields
    private Good good;
    private DateTime date;
    private double quantity;

    // Properties
	public Good Good
	{
		get { return good; }
		set { good = value; }
	}

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public double Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    //TODO: Constructors
    // Constructors
    public Deal(Good good, double quantity)
    {
        this.Good = good;
        this.Date = DateTime.Now;
        this.Quantity = quantity;        
    }
}

