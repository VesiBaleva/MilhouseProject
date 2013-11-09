using System;

public class InventoryManagementException : ApplicationException
{
    public InventoryManagementException(string message)
        : base(message)
    { }

    public InventoryManagementException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
