using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double num1 = 0.0, num2 = 0.0;
            if (double.TryParse(Num1.Text, out num1) && double.TryParse(Num2.Text, out num2))
            {
                if (Add.IsChecked == true)
                {
                    Result.Content = Calculate.ArithmeticOperation(num1, num2, "+").ToString();
                }
                else if (Subtract.IsChecked == true)
                {
                    Result.Content = Calculate.ArithmeticOperation(num1, num2, "-").ToString();
                }
                else if (Multiply.IsChecked == true)
                {
                    Result.Content = Calculate.ArithmeticOperation(num1, num2, "*").ToString();
                }
                else if (Divide.IsChecked == true)
                {
                    Result.Content = Calculate.ArithmeticOperation(num1, num2, "/").ToString();
                }
                else
                {
                    Result.Content = "Niewybrana operacja!!";
                }
            }
            else
            {
                Result.Content = "Niepoprawny format liczby!!";
            }
        }
    }
}
