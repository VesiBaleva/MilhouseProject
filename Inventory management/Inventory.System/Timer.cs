using System;
using System.Threading;

public delegate void ChangedEventHandler(object sender, MyEventArgs e);

public class Timer:EventArgs
{
    private ulong ticks;
    private int interval;
    public event ChangedEventHandler Changed;

    public ulong Ticks
    {
        get 
        {
            return this.ticks;
        }
    }
    public int Interval
    {
        get 
        {
            return this.interval;
        }
    }

    public Timer(ulong ticks, int interval)
    {
        this.ticks = ticks;
        this.interval = interval;
    }

    protected void OnChanged(ulong ticks)
    {
        if (Changed != null)
        {
            MyEventArgs e = new MyEventArgs(ticks);
            Changed(this, e);
        }
    }
    public void Run()
    {
        ulong ticksCount = this.ticks;
        while (true)
        {
            Thread.Sleep(this.interval);
            ticksCount--;
            OnChanged(ticksCount);
                if(ticksCount==0) break;
        }
    }
}
public class MyEventArgs : EventArgs
{

    private ulong ticks;
    public ulong Ticks
    {
        get
        {
            return this.ticks;
        }
    }

    public MyEventArgs(ulong ticksLeft)
    {
        this.ticks = ticksLeft;
    }
}
