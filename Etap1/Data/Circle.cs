using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data;

public class Circle : INotifyPropertyChanged
{
    private double _x;
    private double _y;
    private int _r;
    private double _velX;
    private double _velY;
    private int _mass;
    private bool _changeX = false;
    private bool _changeY = false;
    private string? _color;

    public Circle(double x, double y, int r, int mass)
    {
        _x = x;
        _y = y;
        _r = r;
        _mass = mass;
    }

    public Circle(double x, double y, int mass)
    {
        _x = x;
        _y = y;
        _mass = mass;
        _r = mass * 5;
    }
    
    public string? Color
    {
        get => _color;
        set => _color = value;
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
        set
        {
            _x = value;
            OnPropertyChanged("x");
        }
    }
    
    public double Y
    {
        get => _y;
        set
        {
            _y = value;
            OnPropertyChanged("y");
        }
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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}