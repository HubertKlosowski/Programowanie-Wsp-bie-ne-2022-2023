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
            int mass = random.Next(1, 5);
            int r = mass * 5;
            int x = random.Next(r, (int)_width - r);
            int y = random.Next(r, (int)_height - r);
            Circle circle = new Circle(x, y, r, mass);
            while (!CheckInitialCoordinates(circle))
            {
                circle.X = random.Next(r, (int)_width - r);
                circle.Y = random.Next(r, (int)_height - r);
                if (CheckInitialCoordinates(circle))
                {
                    break;
                }
            }
            circle.VelX = random.NextDouble() * 2 - 1;
            if (circle.VelX == 0)
                circle.VelX -= 1;
            if (circle.VelX > 0)
                circle.ChangeX = true;
            else
                circle.ChangeX = false;
            circle.VelX = random.NextDouble() * 2 - 1;
            if (circle.VelY == 0)
                circle.VelY -= 1;
            if (circle.VelY > 0)
                circle.ChangeY = true;
            else
                circle.ChangeY = false;
            _circles.Add(circle);
        }
    }
    
    public bool CheckInitialCoordinates(Circle newcircle)
    {
        if (_circles.Count == 0)
        {
            return true;
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
    
    private void CheckBallCollisions(Circle c1, Circle c2)
    {
        if ((c1.X - c2.X) * (c1.X - c2.X)
            + (c1.Y - c2.Y) * (c1.Y - c2.Y)
            <= (c1.R + c2.R) * (c1.R + c2.R))
        {
            double fi = Math.Atan(Math.Abs(c1.Y - c2.Y) / Math.Abs(c1.X - c2.X));
            double v1 = Math.Sqrt(c1.VelY * c1.VelY + c1.VelX * c1.VelX);
            double v2 = Math.Sqrt(c2.VelY * c2.VelY + c2.VelX * c2.VelX);
            double alpha = Math.Acos(c1.VelX / v1);
            double beta = Math.Acos(c2.VelX / v2);
            c1.VelX = (v1 * Math.Cos(alpha - fi) * (c1.Mass - c2.Mass) + 2 * c2.Mass * v2 * Math.Cos(beta - fi)) /
                       (c1.Mass + c2.Mass) * Math.Cos(fi) + v1 * Math.Sin(alpha - fi) * Math.Cos(fi + Math.PI / 2);
            c1.VelY = (v1 * Math.Cos(alpha - fi) * (c1.Mass - c2.Mass) + 2 * c2.Mass * v2 * Math.Cos(beta - fi)) /
                       (c1.Mass + c2.Mass) * Math.Sin(fi) + v1 * Math.Sin(alpha - fi) * Math.Sin(fi + Math.PI / 2);
            c2.VelX = (v2 * Math.Cos(beta - fi) * (c2.Mass - c1.Mass) + 2 * c1.Mass * v1 * Math.Cos(alpha - fi)) /
                       (c1.Mass + c2.Mass) * Math.Cos(fi) + v1 * Math.Sin(beta - fi) * Math.Cos(fi + Math.PI / 2);
            c2.VelY = (v2 * Math.Cos(beta - fi) * (c2.Mass - c1.Mass) + 2 * c1.Mass * v1 * Math.Cos(alpha - fi)) /
                       (c1.Mass + c2.Mass) * Math.Sin(fi) + v1 * Math.Sin(beta - fi) * Math.Sin(fi + Math.PI / 2);
            c1.ChangeX = !c1.ChangeX;
            c1.ChangeY = !c1.ChangeY;
            c2.ChangeX = !c2.ChangeX;
            c2.ChangeY = !c2.ChangeY;
        }
    }

    public void Move(Circle c)
    {
        CheckEdgeCollisions(c);
        /*foreach (var circle in _circles)
        {
            if (c != circle)
            {
                CheckBallCollisions(c, circle);
            }
        }*/
    }
    
    private void CheckEdgeCollisions(Circle circle)
    {
        if (circle.Y > _height - circle.R || circle.ChangeY)
        {
            if (circle.VelY > 0)
                circle.Y -= circle.VelY;
            else
                circle.Y += circle.VelY;
            circle.ChangeY = true;
        }
        if (circle.Y < circle.R)
        {
            if (circle.VelY > 0)
                circle.Y += circle.VelY;
            else
                circle.Y -= circle.VelY;
            circle.ChangeY = false;
        }
        if (!circle.ChangeY)
        {
            if (circle.VelY > 0)
                circle.Y += circle.VelY;
            else
                circle.Y -= circle.VelY;
        }
        if (circle.ChangeY)
        {
            if (circle.VelY > 0)
                circle.Y -= circle.VelY;
            else
                circle.Y += circle.VelY;
        }
        if (circle.X > _width - circle.R || circle.ChangeX)
        {
            if (circle.VelX > 0)
                circle.X -= circle.VelX;
            else
                circle.X += circle.VelX;
            circle.ChangeX = true;
        }
        if (circle.X < circle.R)
        {
            if (circle.VelX > 0)
                circle.X += circle.VelX;
            else
                circle.X -= circle.VelX;
            circle.ChangeX = false;
        }
        if (!circle.ChangeX)
        {
            if (circle.VelX > 0)
                circle.X += circle.VelX;
            else
                circle.X -= circle.VelX;
        }
        if (circle.ChangeX)
        {
            if (circle.VelX > 0)
                circle.X -= circle.VelX;
            else
                circle.X += circle.VelX;
        }
    }
}