using System;

public class InvalidSalaryException : InventoryManagementException
{
    public InvalidSalaryException(string message)
        : base(message)
    {
    }

    public InvalidSalaryException(string msg, Exception innerEx)
        : base(msg, innerEx)
    {
    }
}
