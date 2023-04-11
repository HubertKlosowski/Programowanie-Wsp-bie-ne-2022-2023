using Data;
using Model;
using Logic;

namespace TestProject
{
    public class Tests
    {
        public void TestCreateBall()
        {
            Ball ball1 = new Ball(new Circle(5, 10, 4), "red");
            Assert.Equal(5, ball1.X);
            Assert.Equal(10, ball1.Y);
            Assert.Equal(4, ball1.R);
            Assert.Equal("red", ball1.Color);
        }

    
        public void TestCreateTwoBalls()
        {
            Ball ball1 = new Ball(new Circle(5, 10, 4), "red");
            Ball ball2 = new Ball(new Circle(15, 10, 4), "blue");
            Assert.NotEqual(ball1, ball2);
        }

      
        public void TestBallPop()
        {
            DataApi xd2 = new DataApiImplementation();
            LogicApi xd1 = new LogicApiImplementation(xd2);
            ModelApi xd = new ModelApiImplementation(xd1);
            xd.Generate(2);
            List<Circle> tmp = xd1.GetCircles();
            Assert.NotEqual(tmp[0], tmp[1]);
        }
    }
}
