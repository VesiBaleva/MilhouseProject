using System;
public class Good
{
    //fields
    private int id;
    private string name;
    private Unit unit;
    private GoodsCategory category;
    private static int idCounter = 1; // must change with +1 when new Item is created

    //Properties    
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new InvalidNameException("Can not input empty name of good!");
                }
                else if (value.Length > 100)
                {
                    throw new InvalidNameException(String.Format("Can not input name greather than 100 symbols! Input value: {0}", value));
                }
                this.name = value;            
             }
    }
    
    public Unit Unit
    {
        get { return this.unit ; }
        set {
            if (value.ToString().Length<=0)
            {
                throw new InvalidNameException("Can not input empty name of unit!");
            }         
            this.unit = value; }
    }

    public GoodsCategory Category
    {
        get { return this.category; }
        set {
            if (value.ToString().Length <= 0)
            {
                throw new InvalidNameException("Can not input empty name of category!");
            }         
            this.category = value; }
    }
    
    //TODO: Validation
    public Good()
    { 
        
    }

    public Good(string name, Unit unit, GoodsCategory category)
    {
        this.ID = idCounter++;
        this.Name = name;
        this.Unit = unit;
        this.Category = category;
    }

    public Good(int id, string name, Unit unit, GoodsCategory category)
    {
        this.ID = id;
        idCounter++;
        this.Name = name;
        this.Unit = unit;
        this.Category = category;
    }

    //Methods
    public override string ToString()
    {
        return String.Format("║ {0,-4} ║ {1, -30} ║ {2, -20} ║ {3, -30} ║", this.ID, this.Name, this.Unit, this.Category);
    }

    public static string Title()
    {
        return String.Format("║ {0,-4} ║ {1, -30} ║ {2, -20} ║ {3, -30} ║", "ID", "NAME", "UNIT", "CATEGORY");
    }
}

