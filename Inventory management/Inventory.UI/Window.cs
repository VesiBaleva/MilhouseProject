using System;

public static class Window
{
    public const int Width = 128;
    public const int Height = 52;

    public static void Initialize()
    {
        Console.WindowWidth = Width;
        Console.WindowHeight = Height;
    }
}
