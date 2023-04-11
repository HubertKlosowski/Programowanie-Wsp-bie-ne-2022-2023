using Data;
using System.Threading;

namespace Logic;

public class LogicApiImplementation : LogicApi
{
    private DataApi _dataApi;
    private static Canvas _canvas = new Canvas(684, 411);
    private Timer _timer = new Timer(Update!, null, 0, 10);
    private static bool _running = false;
    private static object _lock = new();
    
    public LogicApiImplementation(DataApi dataApi)
    {
        _dataApi = dataApi;
    }
    
    private static void Update(object state)
    {
        lock (_lock)
        {
            if (_running)
            {
                return;
            }
            _canvas.Update();
        }
    }
    
    public override List<Circle> GetCircles()
    {
        return _canvas.AllCircles;
    }

    public override double[] GetCanvasDimensions()
    {
        return new double[] { _canvas.Width, _canvas.Height };
    }

    public override void StartCircles()
    {
        lock (_lock)
        {
            _running = true;
        }
    }

    public override void StopCircles()
    {
        lock (_lock)
        {
            _running = false;
        }
    }
    
    public override void AddCircles(int count)
    {
        _canvas.AddCirclesToCanvas(count);
    }
}