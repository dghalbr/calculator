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

namespace Calculator
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
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender.Equals(multiplicationButton))
                selectedOperator = SelectedOperator.Multiplication;
            else if (sender.Equals(divideButton))
                selectedOperator = SelectedOperator.Division;
            else if (sender.Equals(addButton))
                selectedOperator = SelectedOperator.Addition;
            else if (sender.Equals(subtractButton))
                selectedOperator = SelectedOperator.Subtraction;
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = double.TryParse(resultLabel.Content.ToString(), out lastNumber) ? lastNumber * -1 : lastNumber;
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = double.TryParse(resultLabel.Content.ToString(), out lastNumber) ? lastNumber / 100 : lastNumber;
        }
  
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;
            if (sender.Equals(oneButton))
                selectedValue = 1;
            else if (sender.Equals(twoButton))
                selectedValue = 2;
            else if (sender.Equals(threeButton))
                selectedValue = 3;
            else if (sender.Equals(fourButton))
                selectedValue = 4;
            else if (sender.Equals(fiveButton))
                selectedValue = 5;
            else if (sender.Equals(sixButton))
                selectedValue = 6;
            else if (sender.Equals(sevenButton))
                selectedValue = 7;
            else if (sender.Equals(eightButton))
                selectedValue = 8;
            else if (sender.Equals(nineButton))
                selectedValue = 9;
            resultLabel.Content = resultLabel.Content.Equals("0") ? $"{selectedValue}" : $"{resultLabel.Content.ToString()}{selectedValue}";
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if(!resultLabel.Content.ToString().Contains("."))
                resultLabel.Content = $"{resultLabel.Content}.";
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double newNumber))
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
                        result = SimpleMath.Mutliply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
            }
            resultLabel.Content = result.ToString();
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
        public static double Add(double n1, double n2) => n1 + n2;
        public static double Subtract(double n1, double n2) => n1 - n2;
        public static double Mutliply(double n1, double n2) => n1 * n2;
        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division by Zero is not supported.", "Invalid Operation.", MessageBoxButton.OK, MessageBoxImage.Stop);
                return 0;
            }
            return n1 / n2;
        }
    }
}
