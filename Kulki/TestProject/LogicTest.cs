using Logic;
using Data;

namespace TestProject1;

public class LogicTest
{
    private LogicApi _logic = LogicApi.Create(DataApi.Create());
    
    [Fact]
    public void TestResetLogic()
    {
        _logic.AddCircles(2);
        Assert.Equal(2, _logic.GetCircles().Count);
        _logic.Reset();
        Assert.Empty(_logic.GetCircles());
    }
    
    [Fact]
    public void TestCircleGeneration()
    {
        Assert.Empty(_logic.GetCircles());
        _logic.AddCircles(2);
        List<Circle> tmp = _logic.GetCircles();
        Assert.Equal(2, tmp.Count);
        for (int i = 0; i < tmp.Count; i++)
        {
            Assert.True(tmp[i].X < 700);
            Assert.True(tmp[i].Y < 450);
        }
        _logic.Reset();
    }

    [Fact]
    public void TestStopAndStart()
    {
        Circle circle = new Circle(250, 100, 1);
        circle.VelX = 1;
        circle.VelY = 1;
        _logic.AddCircle(circle);
        _logic.Update();
        Thread.Sleep(100);
        _logic.Stop();
        Assert.Equal(258, circle.X, 3e0);
        Assert.Equal(108, circle.Y, 3e0);
        _logic.Start();
        _logic.Update();
        Thread.Sleep(100);
        Assert.Equal(266, circle.X, 3e0);
        Assert.Equal(115, circle.Y, 3e0);
        _logic.Reset();
    }
}