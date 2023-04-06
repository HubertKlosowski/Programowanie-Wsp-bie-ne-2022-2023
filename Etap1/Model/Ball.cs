using System.ComponentModel;

namespace Model;

public class Ball : INotifyPropertyChanged
{
    private double _x = 0;
    private double _y = 0;
    private int _r = 0;
    private bool _changeX = false;
    private bool _changeY = false;
    private double _velX = 1;
    private double _velY = 1;

    public Ball(int x, int y, int r)
    {
        _x = x;
        _y = y;
        _r = r;
    }
    
    public double velX
    {
        get { return _velX; }
        set
        {
            _velX = value;
            OnPropertyChanged("velX");
        }
    }
    
    public double velY
    {
        get { return _velY; }
        set
        {
            _velY = value;
            OnPropertyChanged("velY");
        }
    }
    
    public bool changeY
    {
        get { return _changeY; }
        set
        {
            _changeY = value;
            OnPropertyChanged("changeY");
        }
    }
    
    public bool changeX
    {
        get { return _changeX; }
        set
        {
            _changeX = value;
            OnPropertyChanged("changeX");
        }
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

    private void OnPropertyChanged(string direction)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(direction));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}