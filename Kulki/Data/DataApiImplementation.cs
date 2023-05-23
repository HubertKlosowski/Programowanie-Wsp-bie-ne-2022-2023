namespace Data;

public class DataApiImplementation : DataApi
{
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
            Canvas.AddCirclesToCanvas(3);
        }
        List<Circle> circles = Canvas.AllCircles;
        foreach (var circle in circles)
        {
            Logger.LogDiagnosticData(circle);
        }
    }

    public override void AddCircle(Circle circle)
    {
        if (Canvas.CheckInitialCoordinates(circle))
        {
            Canvas.AddCircle(circle);
            Logger.LogDiagnosticData(circle);
        }
        else
        {
            throw new ArgumentException("Błąd!! Niepoprawne współrzędne.");
        }
    }
}