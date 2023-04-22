using Data;

namespace Logic;

public class LogicApiImplementation : LogicApi
{
    private DataApi _dataApi;

    public LogicApiImplementation(DataApi dataApi)
    {
        _dataApi = dataApi;
    }
    
    public override List<Circle> GetCircles()
    {
        return _dataApi.GetCircles();
    }

    public override double GetCanvasWidth()
    {
        return _dataApi.GetCanvasWidth();
    }

    public override double GetCanvasHeight()
    {
        return _dataApi.GetCanvasHeight();
    }

    public override void AddCircles(int count)
    {
        try
        {
            _dataApi.AddCircles(count);
        }
        catch (ArgumentException)
        {
            _dataApi.AddCircles(3);
        }
    }
    
    public override void Update()
    {
        foreach (Circle circle in GetCircles())
        {
            Thread thread = new Thread(() =>
            {
                while (ShouldRun)
                {
                    try
                    {
                        ManualResetEvent.WaitOne();
                        lock (circle)
                        {
                            DataApi.Canvas.Move(circle);
                        }
                        Thread.Sleep(5);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        return;
                    }
                }
            });
            Threads.Add(thread);
            thread.IsBackground = true;
            thread.Start();
        }
    }

    public override void Reset()
    {
        foreach (Thread thread in Threads)
        {
            thread.Interrupt();
        }
        Threads.Clear();
    }
    
    public override void AddCircle(Circle circle)
    {
        _dataApi.AddCircle(circle);
    }
    
    public override void Stop()
    {
        if (!ShouldRun)
            ManualResetEvent.WaitOne();
    }
    
    public override void Start()
    {
        if (ShouldRun)
            ManualResetEvent.Set();
    }
}