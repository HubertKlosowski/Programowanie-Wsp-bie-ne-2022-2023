namespace Data;

public class Canvas
{
    private double _width;
    private double _height;
    private List<Circle> _circles = new ();

    public Canvas(double width, double height)
    {
        _width = width;
        _height = height;
    }
    
    public void AddCirclesToCanvas(int count)
    {
        Random random = new Random();
        if (count <= 0 || count > 200)
        {
            count = 3;
        }
        for (int i = 0; i < count; i++)
        {
            double mass = random.NextDouble() * (1 - 0.1) + 0.1;
            double r = mass * 20;
            double x = random.NextDouble() * (_width - r) + r;
            double y = random.NextDouble() * (_height - r) + r;
            Circle circle = new Circle(x, y, r, mass);
            while (!CheckInitialCoordinates(circle))
            {
                circle.X = random.NextDouble() * (_width - r) + r;
                circle.Y = random.NextDouble() * (_height - r) + r;
                if (CheckInitialCoordinates(circle))
                {
                    break;
                }
            }
            circle.VelX = random.NextDouble() * 2 - 1;
            if (circle.VelX == 0)
                circle.VelX -= 1;
            circle.VelX = random.NextDouble() * 2 - 1;
            if (circle.VelY == 0)
                circle.VelY -= 1;
            _circles.Add(circle);
        }
    }
    
    public bool CheckInitialCoordinates(Circle newcircle)
    {
        if (_circles.Count == 0)
        {
            return true;
        }
        if (newcircle.Y - newcircle.R < 0 || newcircle.Y + newcircle.R > _height
            || newcircle.X - newcircle.R < 0 || newcircle.X + newcircle.R > _width)
        {
            return false;
        }
        for (int i = 0; i < _circles.Count; i++)
        {
            if (((newcircle.X - _circles[i].X) * (newcircle.X - _circles[i].X))
                + ((newcircle.Y - _circles[i].Y) * (newcircle.Y - _circles[i].Y))
                <= (newcircle.R + _circles[i].R) * (newcircle.R + _circles[i].R))
            {
                return false;
            }
        }
        return true;
    }
    
    public double Width
    {
        get => _width;
        set => _width = value;
    }

    public double Height
    {
        get => _height;
        set => _height = value;
    }

    public List<Circle> AllCircles
    {
        get => _circles;
        set => _circles = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public void AddCircle(Circle circle)
    {
        if (CheckInitialCoordinates(circle))
            _circles.Add(circle);
        else
            throw new ArgumentException("Błąd!! Niepoprawne współrzędne.");
    }
    
    private void CheckBallCollisions(Circle c)
    {
        foreach (var circle in _circles)
        {
            if ((c.X - circle.X) * (c.X - circle.X)
                + (c.Y - circle.Y) * (c.Y - circle.Y)
                <= (c.R + circle.R) * (c.R + circle.R))
            {
                double fi = Math.Atan(Math.Abs(c.Y - circle.Y) / Math.Abs(c.X - circle.X));
                double v1 = Math.Sqrt(c.VelY * c.VelY + c.VelX * c.VelX);
                double v2 = Math.Sqrt(circle.VelY * circle.VelY + circle.VelX * circle.VelX);
                double alpha = Math.Acos(c.VelX / v1);
                double beta = Math.Acos(circle.VelX / v2);
                c.VelX = (v1 * Math.Cos(alpha - fi) * (c.Mass - circle.Mass) + 2 * circle.Mass * v2 * Math.Cos(beta - fi)) /
                    (c.Mass + circle.Mass) * Math.Cos(fi) + v1 * Math.Sin(alpha - fi) * Math.Cos(fi + Math.PI / 2);
                c.VelY = (v1 * Math.Cos(alpha - fi) * (c.Mass - circle.Mass) + 2 * circle.Mass * v2 * Math.Cos(beta - fi)) /
                    (c.Mass + circle.Mass) * Math.Sin(fi) + v1 * Math.Sin(alpha - fi) * Math.Sin(fi + Math.PI / 2);
                circle.VelX = (v2 * Math.Cos(beta - fi) * (circle.Mass - c.Mass) + 2 * c.Mass * v1 * Math.Cos(alpha - fi)) /
                    (c.Mass + circle.Mass) * Math.Cos(fi) + v1 * Math.Sin(beta - fi) * Math.Cos(fi + Math.PI / 2);
                circle.VelY = (v2 * Math.Cos(beta - fi) * (circle.Mass - c.Mass) + 2 * c.Mass * v1 * Math.Cos(alpha - fi)) /
                    (c.Mass + circle.Mass) * Math.Sin(fi) + v1 * Math.Sin(beta - fi) * Math.Sin(fi + Math.PI / 2);
            }
        }
    }
    
    private void CheckEdgeCollisions(Circle circle)
    {
        if (circle.Y >= _height - circle.R || circle.Y <= circle.R)
        {
            circle.VelY *= -1;
        }
        if (circle.X >= _width - circle.R || circle.X <= circle.R)
        {
            circle.VelX *= -1;
        }
    }

    public void MoveCircleOnCanvas(Circle c)
    {
        c.Move();
        CheckEdgeCollisions(c);
        //CheckBallCollisions(c);
    }
}