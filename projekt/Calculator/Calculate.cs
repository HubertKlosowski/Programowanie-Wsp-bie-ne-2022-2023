using System;

namespace projekt
{
    public class Calculate
    {
        public static double ArithmeticOperation(double num1, double num2, string wybor)
        {
            double res = 0.0;
            switch (wybor)
            {
                case "+":
                    res = num1 + num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "/":
                    try
                    {
                        res = num1 / num2;
                    }
                    catch (Exception e)
                    {
                        string xd = e.Message;
                        res = -1;
                    }
                    break;
                default:
                    res = -1;
                    break;
            }
            return res;
        }
    }
}
