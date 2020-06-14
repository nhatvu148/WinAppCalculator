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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            acBtn.Click += AcBtn_Click;
            negBtn.Click += NegBtn_Click;
            percentBtn.Click += PercentBtn_Click;
            equalBtn.Click += EqualBtn_Click;
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {
            double tempNum;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNum))
            {
                tempNum = tempNum / 100;
                if (lastNumber != 0)
                {
                    tempNum *= lastNumber;
                }
                resultLabel.Content = tempNum.ToString();
            }
        }

        // 50 + 5% (2.5) = 52.5
        // 80 + 10% (8) = 88

        private void NegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiplyBtn)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            else if (sender == divideBtn)
            {
                selectedOperator = SelectedOperator.Division;
            }
            else if (sender == plusBtn)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            else if (sender == minusBtn)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
        }

        private void pointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
                resultLabel.Content = $"{resultLabel.Content}.";
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroBtn)
            {
                selectedValue = 0;
            }
            else if (sender == oneBtn)
            {
                selectedValue = 1;
            }
            else if (sender == twoBtn)
            {
                selectedValue = 2;
            }
            else if (sender == threeBtn)
            {
                selectedValue = 3;
            }
            else if (sender == fourBtn)
            {
                selectedValue = 4;
            }
            else if (sender == fiveBtn)
            {
                selectedValue = 5;
            }
            else if (sender == sixBtn)
            {
                selectedValue = 6;
            }
            else if (sender == sevenBtn)
            {
                selectedValue = 7;
            }
            else if (sender == eightBtn)
            {
                selectedValue = 8;
            }
            else if (sender == nineBtn)
            {
                selectedValue = 9;
            }

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}
