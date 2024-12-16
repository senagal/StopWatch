using System;
using System.Threading;

public class Stopwatch
{
    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler? OnStarted;
    public event StopwatchEventHandler? OnStopped;
    public event StopwatchEventHandler? OnReset;

    private TimeSpan TimeElapsed;
    private bool IsRunning;
    private Timer? Timer;

    public Stopwatch()
    {
        TimeElapsed = TimeSpan.Zero;
        IsRunning = false;
    }

    public void Start()
    {
        if (IsRunning) return;
        IsRunning = true;
        Timer = new Timer(Tick, null, 0, 1000);//used a timer instead of Thread.sleep
        OnStarted?.Invoke("Stopwatch Started!");
    }

    public void Stop()
    {
        if (!IsRunning) return;
        IsRunning = false;
        Timer?.Dispose();
        OnStopped?.Invoke($"Stopwatch Stopped! Time Elapsed: {TimeElapsed}");
    }

    public void Reset()
    {
        Stop();
        TimeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reseted!");
    }

    private void Tick(object? state)
    {
        if (IsRunning)
        {
            TimeElapsed = TimeElapsed.Add(TimeSpan.FromSeconds(1));
            Console.WriteLine($"Time Elapsed: {TimeElapsed}");
        }
    }
}
