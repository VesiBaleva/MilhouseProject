using System;

public static class StringExtension
{
    public static void Write(this string text, ConsoleColor color = ConsoleColor.Gray)
    {
        ConsoleColor oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = oldColor;
    }
    public static void WriteLine(this string text, ConsoleColor color = ConsoleColor.Gray)
    {
        ConsoleColor oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = oldColor;
    }
}
