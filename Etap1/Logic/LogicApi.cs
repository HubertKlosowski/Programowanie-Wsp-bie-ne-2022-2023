using Data;

namespace Logic;

public abstract class LogicApi
{
    public static volatile bool ShouldRun = true;
    public static List<Thread> Threads = new();
    public static ManualResetEvent ManualResetEvent = new(true);
    
    public static LogicApi Create(DataApi dataApi = default!)
    {
        return new LogicApiImplementation(dataApi);
    }
    public abstract List<Circle> GetCircles();
    public abstract double GetCanvasWidth();
    public abstract double GetCanvasHeight();
    public abstract void AddCircles(int count);
    public abstract void AddCircle(Circle circle);
    public abstract void Update();
    public abstract void Reset();
    public abstract void Stop();
    public abstract void Start();
}