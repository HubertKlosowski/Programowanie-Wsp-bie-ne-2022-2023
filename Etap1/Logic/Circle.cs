namespace Logic;

public class Circle
{
    private double _x;
    private double _y;
    private int _r;
    private double _velX = 1;
    private double _velY = 1;
    private bool _changeX = false;
    private bool _changeY = false;

    public Circle(double x, double y, int r)
    {
        _x = x;
        _y = y;
        _r = r;
    }
    
    public bool changeY
    {
        get { return _changeY; }
        set
        {
            _changeY = value;
        }
    }
    
    public bool changeX
    {
        get { return _changeX; }
        set
        {
            _changeX = value;
        }
    }
    
    public double X
    {
        get => _x;
        set => _x = value;
    }
    
    public double Y
    {
        get => _y;
        set => _y = value;
    }
    
    public int R
    {
        get => _r;
        set => _r = value;
    }
    
    public double velX
    {
        get => _velX;
        set => _velX = value;
    }
    
    public double velY
    {
        get => _velY;
        set => _velY = value;
    }
}