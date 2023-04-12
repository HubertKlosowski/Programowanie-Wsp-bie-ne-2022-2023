namespace Logic;

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
        if (count <= 0)
        {
            count = 3;
        }
        int r = random.Next(5, 11);
        if (count * r * r > _width * _height)
        {
            count = (int)(_width * _height / (r * r));
        }
        for (int i = 0; i < count; i++)
        {
            int x = random.Next(r, (int)_width - r);
            int y = random.Next(r, (int)_height - r);
            Circle circle = new Circle(x, y, r);
            while (circle.X <= _width && circle.Y <= _height && !CheckInitialCoordinates(circle))
            {
                circle.X = random.Next(r, (int)_width - r);
                circle.Y = random.Next(r, (int)_height - r);
                if (CheckInitialCoordinates(circle))
                {
                    break;
                }
            }
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

    public void Update()
    {
        for (int i = 0; i < _circles.Count; i++)
        {
            CheckEdgeCollisions(_circles[i]);
            for (int j = i + 1; j < _circles.Count; j++)
            {
                CheckBallCollisions(_circles[i], _circles[j]);
            }
        }
    }
    
    public void CheckBallCollisions(Circle circle1, Circle circle2)
    {
        if (((circle1.X - circle2.X) * (circle1.X - circle2.X))
            + ((circle1.Y - circle2.Y) * (circle1.Y - circle2.Y))
            <= ((circle1.R + circle2.R) * (circle1.R + circle2.R)))
        {
            double fi = Math.Atan(Math.Abs(circle1.Y - circle2.Y) / Math.Abs(circle1.X - circle2.X));
            double v1 = Math.Sqrt((circle1.velY * circle1.velY) + (circle1.velX * circle1.velX));
            double v2 = Math.Sqrt((circle2.velY * circle2.velY) + (circle2.velX * circle2.velX));
            double alpha = Math.Acos(circle1.velY / v1);
            double beta = Math.Acos(circle2.velY / v2);
            circle1.velX = v2 * Math.Cos(beta - fi) * Math.Cos(fi) + (v1 * Math.Sin(alpha - fi) * Math.Cos(fi + Math.PI / 2));
            circle1.velY = v2 * Math.Cos(beta - fi) * Math.Sin(fi) + (v1 * Math.Sin(alpha - fi) * Math.Sin(fi + Math.PI / 2));
            circle2.velX = v1 * Math.Cos(alpha - fi) * Math.Cos(fi) + (v2 * Math.Sin(beta - fi) * Math.Cos(fi + Math.PI / 2));
            circle2.velY = v1 * Math.Cos(alpha - fi) * Math.Sin(fi) + (v2 * Math.Sin(beta - fi) * Math.Sin(fi + Math.PI / 2));
            circle1.changeX = !circle1.changeX;
            circle1.changeY = !circle1.changeY;
            circle2.changeX = !circle2.changeX;
            circle2.changeY = !circle2.changeY;
        }
    }
    
    public void CheckEdgeCollisions(Circle circle)
    {
        if (circle.Y > _height - circle.R || circle.changeY)
        {
            circle.Y -= circle.velY;
            circle.changeY = true;
        }
        if (circle.Y < circle.R)
        {
            circle.Y += circle.velY;
            circle.changeY = false;
        }
        if (!circle.changeY)
        {
            circle.Y += circle.velY;
        }
        if (circle.changeY)
        {
            circle.Y -= circle.velY;
        }
        if (circle.X > _width - circle.R || circle.changeX)
        {
            circle.X -= circle.velX;
            circle.changeX = true;
        }
        if (circle.X < circle.R)
        {
            circle.X += circle.velX;
            circle.changeX = false;
        }
        if (!circle.changeX)
        {
            circle.X += circle.velX;
        }
        if (circle.changeX)
        {
            circle.X -= circle.velX;
        }
    }
}