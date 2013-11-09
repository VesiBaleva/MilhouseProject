using System.Threading;
using System.Globalization;

public static class Initialize
{
    public static void All()
    {
        Events.Initialize();
        Window.Initialize();
        Draw.BlankPage();
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        Load.All();
        Navigation.Start();
    }
}