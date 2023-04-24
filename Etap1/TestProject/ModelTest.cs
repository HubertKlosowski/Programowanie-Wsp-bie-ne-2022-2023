using Data;
using Model;
using Logic;

namespace TestProject1;

public class ModelTest
{
    [Fact]
    public void TestCreateBall()
    {
        Circle ball1 = new Circle(5, 10, 4, 5);
        Assert.Equal(5, ball1.X);
        Assert.Equal(10, ball1.Y);
        Assert.Equal(4, ball1.R);
    }

    [Fact]
    public void TestCreateTwoBalls()
    {
        Circle ball1 = new Circle(5, 10, 4, 5);
        Circle ball2 = new Circle(5, 10, 4, 5);
        Assert.NotEqual(ball1, ball2);
    }

    [Fact]
    public void TestBallGeneration()
    {
        ModelApi modelApi = ModelApi.Create(LogicApi.Create());
        modelApi.Generate(4);
        Assert.Equal(4, modelApi.GetBalls().Count);
    }
}