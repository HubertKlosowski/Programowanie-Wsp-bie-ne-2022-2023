using Logic;
using Data;

namespace TestProject1;

public class LogicTest
{
    [Fact]
    public void TestCircleGeneration()
    {
        LogicApi logic = LogicApi.Create(DataApi.Create());
        Assert.Empty(logic.GetCircles());
        logic.AddCircles(2);
        List<Circle> tmp = logic.GetCircles();
        Assert.Equal(2, tmp.Count);
        for (int i = 0; i < tmp.Count; i++)
        {
            Assert.True(tmp[i].X < 700);
            Assert.True(tmp[i].Y < 450);
        }
        logic.Reset();
    }
}