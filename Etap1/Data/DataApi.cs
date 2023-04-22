namespace Data;

public abstract class DataApi
{
    public static Canvas Canvas = new (700, 450);
    public static DataApi Create()
    {
        return new DataApiImplementation();
    }
    public abstract List<Circle> GetCircles();
    public abstract double GetCanvasWidth();
    public abstract double GetCanvasHeight();
    public abstract void AddCircles(int count);
    public abstract void AddCircle(Circle circle);
}