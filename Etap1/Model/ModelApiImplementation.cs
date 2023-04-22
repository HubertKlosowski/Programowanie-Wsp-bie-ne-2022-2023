using System.Collections.ObjectModel;
using Logic;
using Data;

namespace Model;

public class ModelApiImplementation : ModelApi
{
    private LogicApi _logicApi;
    private ObservableCollection<Ball> _balls = new();
    private List<String> _colors = new() {"red", "blue", "green", "yellow", "black", "orange", "purple", "brown"};

    public ModelApiImplementation(LogicApi logicApi)
    {
        _logicApi = logicApi;
    }
    public override ObservableCollection<Ball> GetBalls()
    {
        return _balls;
    }
    public override void Generate(int count)
    {
        _logicApi.AddCircles(count);
        List<Circle> list = _logicApi.GetCircles();
        for (int i = 0; i < count; i++)
        {
            _balls.Add(new Ball(list[i], _colors[i % _colors.Count]));
        }
    }
    public override void Reset()
    {
        _balls.Clear();
        _logicApi.GetCircles().Clear();
        _logicApi.Reset();
    }
    public override double GetCanvasWidth()
    {
        return _logicApi.GetCanvasWidth();
    }
    public override double GetCanvasHeight()
    {
        return _logicApi.GetCanvasHeight();
    }

    public override void Update()
    {
        _logicApi.Update();
        List<Circle> list = _logicApi.GetCircles();
        for (int i = 0; i < list.Count; i++)
        {
            _balls[i].X = list[i].X;
            _balls[i].Y = list[i].Y;
        }
    }
    
    public override void Stop()
    {
        _logicApi.Stop();
    }
    
    public override void Start()
    {
        _logicApi.Start();
    }
}