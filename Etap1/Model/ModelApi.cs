using Logic;

namespace Model;

public abstract class ModelApi
{
    private LogicApi _logicApi;
    
    public static ModelApi Create(LogicApi logicApi = default(LogicApi))
    {
        return new ModelApiImplementation(logicApi == null ? LogicApi.Create() : logicApi);
    }

    public abstract void Start();
    public abstract void Stop();
    public abstract void Generate(int count);
    public abstract void Reset();

    public abstract void GetCanvasWidthHeight();

    public abstract List<Ball> GetBalls();
}