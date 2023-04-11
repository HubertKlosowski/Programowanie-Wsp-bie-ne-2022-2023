using Data;
using Model;
using Logic;

namespace TestProject1;

public class UnitTest
{
    [Fact]
    public void TestCreateBall()
    {
        Ball ball1 = new Ball(new Circle(5, 10, 4), "red");
        Assert.Equal(5, ball1.X);
        Assert.Equal(10, ball1.Y);
        Assert.Equal(4, ball1.R);
        Assert.Equal("red", ball1.Color);
    }

    [Fact]
    public void TestCreateTwoBalls()
    {
        Ball ball1 = new Ball(new Circle(5, 10, 4), "red");
        Ball ball2 = new Ball(new Circle(15, 10, 4), "blue");
        Assert.NotEqual(ball1, ball2);
    }

    [Fact]
    public void TestCircleGeneration()
    {
        DataApi data = new DataApiImplementation();
        LogicApi logic = new LogicApiImplementation(data);
        Canvas canvas = new Canvas(300, 400);
        canvas.AddCirclesToCanvas(4);
        List<Circle> tmp = logic.GetCircles();
        Assert.Equal(4, canvas.AllCircles.Count);
    }

    [Fact]
    public void TestBallGeneration()
    {
        DataApi data = new DataApiImplementation();
        LogicApi logic = new LogicApiImplementation(data);
        ModelApi modelApi = new ModelApiImplementation(logic);
        modelApi.Generate(4);
        Assert.Equal(4, modelApi.GetBalls().Count);
    }
}