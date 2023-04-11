using System.Windows.Input;
using Logic;

namespace Model;

public class ModelApiImplementation : ModelApi
{
    private LogicApi _logicApi;

    private List<Ball> _balls = new();

    private List<String> _colors = new() {"red", "blue", "green", "yellow", "pink", "black", "white", "orange", "purple", "brown"};

    public override List<Ball> GetBalls()
    {
        return _balls;
    }

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
        for (int i = 0; i < count; i++)
        {
            _balls.Add(new Ball(_logicApi.GetCircles()[i], _colors[i % count]));
        }
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