using Data;

namespace Logic;

public abstract class LogicApi
{
    public static LogicApi Create(DataApi dataApi = default(DataApi))
    {
        return new LogicApiImplementation(dataApi);
    }
    public abstract List<Circle> GetCircles();
    public abstract double[] GetCanvasDimensions();
    public abstract void StartCircles();
    public abstract void StopCircles();
    public abstract void AddCircles(int count);
}