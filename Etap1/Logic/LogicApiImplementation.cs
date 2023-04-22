using Data;

namespace Logic;

public class LogicApiImplementation : LogicApi
{
    private DataApi _dataApi;
    
    public LogicApiImplementation(DataApi dataApi)
    {
        _dataApi = dataApi;
    }
    
    public override List<Circle> GetCircles()
    {
        return _dataApi.GetCircles();
    }

    public override double GetCanvasWidth()
    {
        return _dataApi.GetCanvasWidth();
    }

    public override double GetCanvasHeight()
    {
        return _dataApi.GetCanvasHeight();
    }

    public override void AddCircles(int count)
    {
        try
        {
            _dataApi.AddCircles(count);
        }
        catch (ArgumentException)
        {
            _dataApi.AddCircles(3);
        }
    }
    
    public override void Update()
    {
        _dataApi.Update();
    }
    
    public override void AddCircle(Circle circle)
    {
        _dataApi.AddCircle(circle);
    }
}