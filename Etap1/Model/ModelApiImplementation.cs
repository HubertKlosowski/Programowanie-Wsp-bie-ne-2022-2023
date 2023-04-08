using Logic;

namespace Model;

public class ModelApiImplementation : ModelApi
{
    private LogicApi _logicApi;
    private List<Ball> _balls = new();
    public ModelApiImplementation(LogicApi logicApi)
    {
        _logicApi = logicApi;
    }

    public override void Start()
    {
        _logicApi.StartCircles();
    }

    public override void Stop()
    {
        _logicApi.StopCircles();
    }

    public override void Generate(int count)
    {
        _logicApi.AddCircles(count);
    }

    public override void Reset()
    {
        _balls.Clear();
    }

    public override void GetCanvasWidthHeight()
    {
        _logicApi.GetCanvasDimensions();
    }
}