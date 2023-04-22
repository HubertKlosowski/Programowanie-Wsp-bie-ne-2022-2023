using Data;

namespace TestProject1;

public class DataTest
{
    [Fact]
    public void TestCircleData()
    {
        Circle circle = new Circle(5, 10, 4, 1);
        Assert.Equal(5, circle.X);
        Assert.Equal(10, circle.Y);
        Assert.Equal(4, circle.R);
        Assert.Equal(1, circle.Mass);
    }
    
    [Fact]
    public void TestTwoCircles()
    {
        Circle circle1 = new Circle(5, 10, 4, 1);
        Circle circle2 = new Circle(15, 10, 4, 2);
        Assert.NotEqual(circle1, circle2);
    }
    
    [Fact]
    public void TestCanvasData()
    {
        Canvas canvas = new Canvas(700, 450);
        Assert.Equal(700, canvas.Width);
        Assert.Equal(450, canvas.Height);
    }
    
    [Fact]
    public void TestCanvasAddCircles()
    {
        Canvas canvas = new Canvas(700, 450);
        canvas.AddCirclesToCanvas(3);
        Assert.Equal(3, canvas.AllCircles.Count);
    }
    
    [Fact]
    public void TestCanvasAddCircles2()
    {
        Canvas canvas = new Canvas(700, 450);
        canvas.AddCirclesToCanvas(3);
        Assert.Equal(3, canvas.AllCircles.Count);
        canvas.AddCirclesToCanvas(3);
        Assert.Equal(6, canvas.AllCircles.Count);
    }
}