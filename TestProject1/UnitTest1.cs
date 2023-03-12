namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestArithmeticOperation()
        {
            Assert.Equal(-22, projekt.Calculate.ArithmeticOperation(1, -23, "+"));
            Assert.Equal(46, projekt.Calculate.ArithmeticOperation(23, -23, "-"));
            Assert.Equal(-0.2, projekt.Calculate.ArithmeticOperation(0.1, -2, "*"));
            Assert.True(projekt.Calculate.ArithmeticOperation(23, -23, "/") == -1);
            Assert.False(projekt.Calculate.ArithmeticOperation(1, 0, "/") == 69);
            Assert.Equal(-1, projekt.Calculate.ArithmeticOperation(1, 0, "/"));
        }
    }
}