using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public static class Draw
{
    public static void BlankPage()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Blue;
        FullLine('═').Write(ConsoleColor.Green);
        Center("   M I L H O U S E   P R O J E C T   ", '║').Write(ConsoleColor.White);
        FullLine('═').Write(ConsoleColor.Green);
        Center("  Inventory Management Software  ", '-').Write(ConsoleColor.Gray);
        FullLine('═').Write(ConsoleColor.Green);
        Console.BackgroundColor = ConsoleColor.Black;
        //FullLine(' ').Write();
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine();
    }

    public static string Center(string text, int width)
    {
        StringBuilder centered = new StringBuilder();
        centered.Append("".PadLeft(width / 2 - text.Length / 2, ' '));
        centered.Append(text);
        centered.Append("".PadLeft(width / 2 - text.Length / 2 , ' '));
        return centered.ToString();
    }

    public static string Center(string text, char filler)
    {
        StringBuilder centered = new StringBuilder();
        centered.Append("".PadLeft(Window.Width / 2 - text.Length / 2, filler));
        centered.Append(text);
        centered.Append("".PadLeft(Window.Width / 2 - text.Length / 2 - 1, filler));
        if ( (Window.Width / 2 - text.Length / 2) * 2 - 1 + text.Length != Window.Width)
        {
            centered.Append(filler);
        }
        return centered.ToString();
    }

    public static string FullLine(char pattern)
    {
        return "".PadLeft(Window.Width, pattern);
    }

    public static void ColorCell(string str, ConsoleColor color)
    {
        Console.BackgroundColor = color;
        Console.WriteLine(str);
        Console.BackgroundColor = Style.DefaultBG;
    }

    public static void TableView<T>(string p, List<T> list)
    {
        "".PadLeft(p.Length, '═').WriteLine();
        Draw.ColorCell(p, Style.TitleBG);
        "".PadLeft(p.Length, '═').WriteLine();
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        "".PadLeft(p.Length, '═').WriteLine();
        Console.WriteLine();
    }

    public static void ClearLastTwoRows(int col, int row)
    {
        Console.SetCursorPosition(col, row);
        FullLine(' ').Write();
        FullLine(' ').Write();
        Console.SetCursorPosition(col, row);
    }
}