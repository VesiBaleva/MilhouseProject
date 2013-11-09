using System;

public class InvalidQuantityException : InventoryManagementException
{
    public InvalidQuantityException(string message)
        : base(message)
    {
    }

    public InvalidQuantityException(string msg, Exception innerEx)
        : base(msg, innerEx)
    {
    }
}