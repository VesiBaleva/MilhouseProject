using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static class Events
{
    public static Thread timerThread; 
    public static void Initialize()
    {
        Timer timer = new Timer(100, 25000);
        timer.Changed += new ChangedEventHandler(SampleMethod);
        timerThread = new Thread(new ThreadStart(timer.Run));
        timerThread.Start();
        GC.KeepAlive(timer);
        IUserInterface keyboard = new KeyboardInterface();
        keyboard.OnCtrlAltMPressed += (sender, infoEvent) =>
            {
                 //to izvika meniuto na manager
            };
    }

    public static void SampleMethod(object sender, MyEventArgs e)
    {
        //TODO: Check for expired goods
        User.SavePosition();
        Console.SetCursorPosition(0, User.startRow + 2);
        Draw.Center("   THERE ARE SOME EXPIRED GOODS   ", '-').Write(ConsoleColor.DarkYellow);
        Console.SetCursorPosition(User.startCol, User.startRow);
    }

    internal static void Close()
    {
        timerThread.Abort();
    }
}

public interface IUserInterface
{
    event EventHandler OnCtrlAltMPressed;

    //event EventHandler OnCtrlAltEPresses;

    void ProcessInput();
}

public class KeyboardInterface : IUserInterface
{
    public void ProcessInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            if ((cki.Equals(ConsoleKey.M)&&(cki.Modifiers & ConsoleModifiers.Control) != 0))
            {
                if (this.OnCtrlAltMPressed != null)
                {
                    this.OnCtrlAltMPressed(this, new EventArgs());
                }
            }
        }
    }
    public event EventHandler OnCtrlAltMPressed;
}