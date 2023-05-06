using Data;

namespace Logic;

public abstract class LogicApi
{
    public List<Task> Tasks = new();
    public CancellationTokenSource Cancellation = new();
    
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