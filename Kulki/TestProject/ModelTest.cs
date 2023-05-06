using Data;
using Model;
using Logic;

namespace TestProject1;

public class ModelTest
{
    private ModelApi _modelApi = ModelApi.Create(LogicApi.Create(DataApi.Create()));
    
    [Fact]
    public void TestBallGeneration()
    {
        _modelApi.Generate(4);
        Assert.Equal(4, _modelApi.GetBalls().Count);
        _modelApi.Reset();
    }

    [Fact]
    public void TestBallMove()
    {
        Circle circle = new Circle(250, 100, 1);
        circle.VelX = 1;
        circle.VelY = 1;
        _modelApi.AddCircle(circle);
        Assert.Single(_modelApi.GetBalls());
        _modelApi.Update();
        Thread.Sleep(100);
        _modelApi.Stop();
        Assert.Equal(258, circle.X, 3e0);
        Assert.Equal(108, circle.Y, 3e0);
        _modelApi.Reset();
    }
    
    [Fact]
    public void TestEdgeCollision()
    {
        Circle circle = new Circle(200, 50, 1);
        circle.VelY = -1;
        circle.VelX = 1;
        _modelApi.AddCircle(circle);
        _modelApi.Update();
        Thread.Sleep(1000);
        Assert.Equal(53, circle.Y, 3e0);
        Assert.Equal(264, circle.X, 3e0);
        _modelApi.Reset();
    }

    [Fact]
    public void TestBallCollisions()
    {
        Circle circle = new Circle(200, 50, 1);
        circle.VelY = 1;
        circle.VelX = 1;
        Circle circle2 = new Circle(200, 100, 1);
        circle2.VelY = -1;
        circle2.VelX = 1;
        _modelApi.AddCircle(circle);
        _modelApi.AddCircle(circle2);
        _modelApi.Update();
        Thread.Sleep(100);
        Assert.Equal(53, circle.Y, 3e0);
        Assert.Equal(208, circle.X, 3e0);
        Assert.Equal(98, circle2.Y, 3e0);
        Assert.Equal(208, circle2.X, 3e0);
        Thread.Sleep(100);
        Assert.Equal(45, circle.Y, 3e0);
        Assert.Equal(215, circle.X, 3e0);
        Assert.Equal(104, circle2.Y, 3e0);
        Assert.Equal(215, circle2.X, 3e0);
        _modelApi.Reset();
    }
}