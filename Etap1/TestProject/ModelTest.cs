using Data;
using Model;
using Logic;

namespace TestProject1;

public class ModelTest
{
    [Fact]
    public void TestBallGeneration()
    {
        ModelApi modelApi = ModelApi.Create(LogicApi.Create(DataApi.Create()));
        modelApi.Generate(4);
        Assert.Equal(4, modelApi.GetBalls().Count);
        modelApi.Reset();
    }

    [Fact]
    public void TestBallMove()
    {
        ModelApi modelApi = ModelApi.Create(LogicApi.Create(DataApi.Create()));
        Circle circle = new Circle(250, 100, 1);
        circle.VelX = 1;
        circle.VelY = 1;
        modelApi.AddCircle(circle);
        Assert.Single(modelApi.GetBalls());
        modelApi.Update();
        Thread.Sleep(100);
        modelApi.Stop();
        Assert.Equal(258, circle.X, 1e0);
        Assert.Equal(108, circle.Y, 1e0);
        modelApi.Reset();
    }
    
    [Fact]
    public void TestEdgeCollision()
    {
        ModelApi modelApi = ModelApi.Create(LogicApi.Create(DataApi.Create()));
        Circle circle = new Circle(200, 50, 1);
        circle.VelY = -1;
        circle.VelX = 1;
        modelApi.AddCircle(circle);
        modelApi.Update();
        Thread.Sleep(600);
        Assert.Equal(29, circle.Y, 1e0);
        Assert.Equal(240, circle.X, 1e0);
        modelApi.Reset();
    }

    [Fact]
    public void TestBallCollisions()
    {
        ModelApi modelApi = ModelApi.Create(LogicApi.Create(DataApi.Create()));
        Circle circle = new Circle(200, 50, 1);
        circle.VelY = 1;
        circle.VelX = 1;
        Circle circle2 = new Circle(200, 100, 1);
        circle2.VelY = -1;
        circle2.VelX = 1;
        modelApi.AddCircle(circle);
        modelApi.AddCircle(circle2);
        modelApi.Update();
        Thread.Sleep(200);
        Assert.Equal(46, circle.Y, 1e0);
        Assert.Equal(210, circle.X, 1e0);
        Assert.Equal(106, circle2.Y, 1e0);
        Assert.Equal(210, circle2.X, 1e0);
        modelApi.Reset();
    }
}