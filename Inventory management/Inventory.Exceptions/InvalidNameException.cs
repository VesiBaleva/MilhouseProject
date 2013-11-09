using System;

public class InvalidNameException : InventoryManagementException
{
    public InvalidNameException(string message)
        : base(message)
    {            
    }

    public InvalidNameException(string msg, Exception innerEx)
		: base(msg, innerEx)
	{
	}
}

