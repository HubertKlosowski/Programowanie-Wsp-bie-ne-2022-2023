namespace Data;

public class Circle
{
    private double _x;
    private double _y;
    private int _r;
    private double _velX;
    private double _velY;
    private int _mass;
    private bool _changeX = false;
    private bool _changeY = false;

    public Circle(double x, double y, int r, int mass)
    {
        _x = x;
        _y = y;
        _r = r;
        _mass = mass;
    }
    
    public bool ChangeY
    {
        get { return _changeY; }
        set
        {
            _changeY = value;
        }
    }
    
    public bool ChangeX
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

    public int Mass
    {
        get => _mass;
        set => _mass = value;
    }
    
    public double VelX
    {
        get => _velX;
        set => _velX = value;
    }
    
    public double VelY
    {
        get => _velY;
        set => _velY = value;
    }
}