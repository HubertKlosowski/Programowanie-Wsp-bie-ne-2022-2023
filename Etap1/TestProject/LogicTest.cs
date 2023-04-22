using Logic;
using Data;

namespace TestProject1;

public class LogicTest
{
    [Fact]
    public void TestCircleGeneration()
    {
        LogicApi logic = LogicApi.Create();
        logic.AddCircles(4);
        List<Circle> tmp = logic.GetCircles();
        Assert.Equal(4, tmp.Count);
        for (int i = 0; i < tmp.Count; i++)
        {
            Assert.True(tmp[i].X < 700);
            Assert.True(tmp[i].Y < 450);
        }
    }
    
    [Fact]
    public void TestCircleBounceAdd()
    {
        LogicApi logicApi = LogicApi.Create();
        logicApi.AddCircle(new Circle(5, 10, 4, 4));
        logicApi.AddCircle(new Circle(15, 10, 4, 4));
        Assert.Equal(2, logicApi.GetCircles().Count);
        try
        {
            logicApi.AddCircle(new Circle(6, 12, 4, 1));
        }
        catch (Exception e)
        {
            Assert.Equal("Błąd!! Niepoprawne współrzędne.", e.Message);
        }
        Assert.Equal(2, logicApi.GetCircles().Count);
    }
}