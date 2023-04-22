using System.Collections.ObjectModel;
using Logic;

namespace Model;

public abstract class ModelApi
{
    public static ModelApi Create(LogicApi logicApi = default(LogicApi)!)
    {
        return new ModelApiImplementation(logicApi);
    }
    public abstract void Generate(int count);
    public abstract void Reset();
    public abstract double GetCanvasWidth();
    public abstract double GetCanvasHeight();
    public abstract ObservableCollection<Ball> GetBalls();
    public abstract void Update();
    public abstract void Stop();
    public abstract void Start();
}