namespace Data;

public abstract class DataApi
{
    public static DataApi Create()
    {
        return new DataApiImplementation();
    }
    public abstract List<Circle> GetCircles();
    public abstract double GetCanvasWidth();
    public abstract double GetCanvasHeight();
    public abstract void AddCircles(int count);
    public abstract void AddCircle(Circle circle);
    public abstract void Update();
}