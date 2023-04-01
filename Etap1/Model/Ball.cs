using System.ComponentModel;

namespace Model;

public class Ball
{
    private int _x = 0;
    private int _y = 0;
    private int _radius = 0;

    public Ball(int x, int y, int r)
    {
        _x = x;
        _y = y;
        _radius = r;
    }
}