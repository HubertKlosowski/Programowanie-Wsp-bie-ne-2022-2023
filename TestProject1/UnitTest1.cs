namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestArithmeticOperation()
        {
            Assert.True(projekt.Calculate.ArithmeticOperation(1, -23, "+") == -22);
            Assert.True(projekt.Calculate.ArithmeticOperation(23, -23, "-") == 46);
            Assert.True(projekt.Calculate.ArithmeticOperation(0.1, -2, "*") == -0.2);
            Assert.True(projekt.Calculate.ArithmeticOperation(23, -23, "/") == -1);
            Assert.False(projekt.Calculate.ArithmeticOperation(1, 0, "/") == 69);
        }
    }
}