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
        DataApi data = DataApi.Create();
        Assert.Equal(700, data.GetCanvasWidth());
        Assert.Equal(450, data.GetCanvasHeight());
    }
    
    [Fact]
    public void TestCanvasAddCircles()
    {
        DataApi data = DataApi.Create();
        data.Canvas.AddCirclesToCanvas(3);
        Assert.Equal(3, data.Canvas.AllCircles.Count);
        data.Canvas.AllCircles.Clear();
        Assert.Empty(data.Canvas.AllCircles);
    }
}