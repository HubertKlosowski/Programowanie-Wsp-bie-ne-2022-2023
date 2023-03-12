using System;
using System.Windows;

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
                    if (num2 == 0) 
                    {
                        MessageBox.Show("Błąd!! Dzielenie przez zero.");
                        return -1; 
                    }
                    else { res = num1 / num2; }
                    break;
                default:
                    res = -1;
                    break;
            }
            return res;
        }
    }
}
