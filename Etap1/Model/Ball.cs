using System.ComponentModel;
using Logic;

namespace Model;

public class Ball : INotifyPropertyChanged
{
    private double _x;
    private double _y;
    private int _r;
    private string _color;

    public string Color
    {
        get => _color;
        set => _color = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Ball(Circle circle, string color)
    {
        _x = circle.X;
        _y = circle.Y;
        _r = circle.R;
        _color = color;
    }

    public double X
    {
        get { return _x; }
        set
        {
            _x = value;
            OnPropertyChanged("x");
        }
    }
    
    public double Y
    {
        get { return _y; }
        set
        {
            _y = value;
            OnPropertyChanged("y");
        }
    }
    
    public int R
    {
        get { return _r; }
        set
        {
            _r = value;
            OnPropertyChanged("r");
        }
    }

    public void UpdatePos(double x, double y)
    {
        X = x;
        Y = y;
    }

    private void OnPropertyChanged(string direction)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(direction));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}