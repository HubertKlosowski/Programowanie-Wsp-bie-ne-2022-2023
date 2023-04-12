using Data;

namespace Logic;

public class LogicApiImplementation : LogicApi
{
    private readonly DataApi _dataApi;
    public Canvas Canvas = new Canvas(700, 450);
    
    public LogicApiImplementation(DataApi dataApi)
    {
        _dataApi = dataApi;
    }
    
    public override List<Circle> GetCircles()
    {
        return Canvas.AllCircles;
    }

    public override double GetCanvasWidth()
    {
        return Canvas.Width;
    }

    public override double GetCanvasHeight()
    {
        return Canvas.Height;
    }

    public override void AddCircles(int count)
    {
        try
        {
            Canvas.AddCirclesToCanvas(count);
        }
        catch (ArgumentException)
        {
            
        }
    }
    
    public override void Update()
    {
        Canvas.Update();
    }
    
    public override void AddCircle(Circle circle)
    {
        if (Canvas.CheckInitialCoordinates(circle))
            Canvas.AllCircles.Add(circle);
        else
            throw new ArgumentException("Błąd!! Niepoprawne współrzędne.");
    }
}