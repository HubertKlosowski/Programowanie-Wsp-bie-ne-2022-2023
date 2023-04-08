namespace Data;

public abstract class DataApi
{
    public abstract void Hello();
    
    public static DataApi Create()
    {
        return new DataApiImplementation();
    }
}