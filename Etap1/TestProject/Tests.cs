using Model;
using Logic;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Tests
    {
  
        public void TestCreateBall()
        {
            Ball ball1 = new Ball(5, "red");
            Assert.AreEqual(5, ball1.Size);
            Assert.AreEqual("red", ball1.Color);
        }

    
        public void TestCreateTwoBalls()
        {
            Ball ball1 = new Ball(5, "red");
            Ball ball2 = new Ball(7, "blue");
            Assert.AreNotEqual(ball1, ball2);
        }


        public void TestBallBounce()
        {
            Ball ball1 = new Ball(5, "red");
            Assert.AreEqual(0, ball1.BounceCount);
            ball1.Bounce();
            Assert.AreEqual(1, ball1.BounceCount);
        }

      
        public void TestBallPop()
        {
            Ball ball1 = new Ball(5, "red");
            Assert.IsFalse(ball1.IsPopped);
            ball1.Pop();
            Assert.IsTrue(ball1.IsPopped);
        }
    }
}
