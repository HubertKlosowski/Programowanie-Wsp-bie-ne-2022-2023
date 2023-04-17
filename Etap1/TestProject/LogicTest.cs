using Logic;

namespace TestProject1;

public class LogicTest
{
    [Fact]
    public void TestCircleData()
    {
        Circle circle = new Circle(5, 10, 4);
        Assert.Equal(5, circle.X);
        Assert.Equal(10, circle.Y);
        Assert.Equal(4, circle.R);
    }
    
    [Fact]
    public void TestTwoCircles()
    {
        Circle circle1 = new Circle(5, 10, 4);
        Circle circle2 = new Circle(15, 10, 4);
        Assert.NotEqual(circle1, circle2);
    }
    
    [Fact]
    public void TestCircleGeneration()
    {
        LogicApi logic = LogicApi.Create();
        logic.AddCircles(4);
        List<Circle> tmp = logic.GetCircles();
        Assert.Equal(4, tmp.Count);
        for (int i = 0; i < tmp.Count; i++)
        {
            Assert.True(tmp[i].X < logic.GetCanvasWidth() - tmp[i].R);
            Assert.True(tmp[i].Y < logic.GetCanvasHeight() - tmp[i].R);
        }
    }
    
    [Fact]
    public void TestCircleBounceAdd()
    {
        LogicApi logicApi = LogicApi.Create();
        logicApi.AddCircle(new Circle(5, 10, 4));
        logicApi.AddCircle(new Circle(15, 10, 4));
        Assert.Equal(2, logicApi.GetCircles().Count);
        try
        {
            logicApi.AddCircle(new Circle(6, 12, 4));
        }
        catch (Exception e)
        {
            Assert.Equal("Błąd!! Niepoprawne współrzędne.", e.Message);
        }
        Assert.Equal(2, logicApi.GetCircles().Count);
    }
    
    [Fact]
    public void TestCanvasDimensions()
    {
        LogicApi logicApi = LogicApi.Create();
        Assert.Equal(700, logicApi.GetCanvasWidth());
        Assert.Equal(450, logicApi.GetCanvasHeight());
    }
}