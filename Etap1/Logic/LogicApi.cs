using Data;

namespace Logic;

public abstract class LogicApi
{
    public static LogicApi Create(DataApi dataApi = default(DataApi)!)
    {
        return new LogicApiImplementation(dataApi);
    }
    public abstract List<Circle> GetCircles();
    public abstract double GetCanvasWidth();
    public abstract double GetCanvasHeight();
    public abstract void AddCircles(int count);
    public abstract void AddCircle(Circle circle);
    public abstract void Update();
}