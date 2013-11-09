using System.Collections.Generic;
using System;
using System.Text;

public class Supplier
{
    // 03:04/17.03.13 kdikov: 
    // I`ve changed List to Dictionary and made some minor changes the constructor

    //fields
    private string name;
    private string contactInfo;
    private Dictionary<Good, decimal> goods = new Dictionary<Good,decimal>();

    //properties ->TODO:data validation
    public string Name { 
        get
        {
            return this.name;
        }
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Name exception, name cannot be empty");
            }
            this.name = value;
        }
    }

    public string ContactInfo {
        get 
        {
            return this.contactInfo;
        }
        private set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("You must enter some contact info about the supplier");
            }
            this.contactInfo = value;
        }
    }
    public Dictionary<Good,decimal> Goods { get; set;}

    //constructors
    public Supplier(string suplierName, string suplierContactInfo)
    {
        this.Name = suplierName;
        this.ContactInfo = suplierContactInfo;
        this.Goods = new Dictionary<Good, decimal>();
    }

    public override string ToString()
    {
        return String.Format("║ {0,-25} ║ {1, -15} ║ Goods: {2, -13} ║", this.Name, this.ContactInfo, this.Goods.Count);
        foreach (var item in this.Goods)
        {
            Console.WriteLine(item.Key + "Price" + item.Value);
        }
    }
}