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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        double number1 = 0;
        double number2 = 0;
        string operation = "";
        bool commaClicked = false;
        bool sign = false;
        int help = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void button_Ok_Click(object sender, RoutedEventArgs e)
        //{
        //    var btn = sender as Button;

        //    MessageBox.Show($"Działa {btn.Content.ToString()}");


        //    if(double.TryParse("2,1", out double x))
        //    {
        //        MessageBox.Show($"{2 * x}");
        //    }
        //}
        
   
        private void equals_Click(object sender, RoutedEventArgs e)
        {
            Button eq = sender as Button;
            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (number1 + number2).ToString();
                    number1 += number2;
                    number2 = 0;
                    
                    break;
                case "-":
                    txtDisplay.Text = (number1 - number2).ToString();
                    number1 -= number2;
                    number2 = 0;
                    break;
                case "/":
                    if (number2 == 0)
                    {
                        txtDisplay.Text = "Nie dziel przez zero!";
                        number1 = 0;
                        number2 = 0;
                        
                        break;
                    }
                    txtDisplay.Text = (number1 / number2).ToString();
                    number1 /= number2;
                    number2 = 0;
                    break;
                case "x":
                    txtDisplay.Text = (number1 * number2).ToString();
                    number1 *= number2;
                    number2 = 0;
                    break;
            }
            operation = "";

        }

        private void one_Click(object sender, RoutedEventArgs e)
        {

            int h_num = 1;
        
            if (operation == "" && !commaClicked) {
                number1 = (number1 * 10) + 1;
                if (sign)
                {
                    number1 = -number1;
                    sign = false;
                }
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 1;
                if (sign)
                {
                    number2 = -number2;
                    sign = false;
                }
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);

                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }

            
            
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            int h_num = 2;
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10) + 2;
               
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 2;             
              
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }

        }

        private void tree_Click(object sender, RoutedEventArgs e)
        {
            int h_num = 3;
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10) + 3;
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 3;
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }

        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            int h_num = 4;
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10) + 4;
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 4;
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            int h_num = 5;
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10) + 5;
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 5;
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            int h_num = 6;
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10) + 6;
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 6;
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            int h_num = 7;
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10) + 7;
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 7;
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            int h_num = 8;
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10) + 8;
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 8;
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            int h_num = 9;
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10) + 9;
                txtDisplay.Text = number1.ToString();
            }
            else if (operation != "" && !commaClicked)
            {
                number2 = (number2 * 10) + 9;
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                number1 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number1.ToString();
                help -= 1;
            }
            else
            {
                number2 += h_num * Math.Pow(10, help);
                txtDisplay.Text = number2.ToString();
                help -= 1;
            }
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "" && !commaClicked)
            {
                number1 = (number1 * 10);
                txtDisplay.Text = number1.ToString();
            }
            else if (operation!= "" && !commaClicked)
            {
                number2 = (number2 * 10);
                txtDisplay.Text = number2.ToString();
            }
            else if (operation == "" && commaClicked)
            {
                
                txtDisplay.Text = number1.ToString()+",0";
                help -= 1;
            }
            else
            {
                
                txtDisplay.Text = number2.ToString()+",0";
                help -= 1;
            }

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            commaClicked = false;
            help = -1;
            number1 = 0;
            number2 = 0;
            operation = "";
            txtDisplay.Text = number1.ToString();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
           
                commaClicked = false;
                help = -1;
                operation = "+";
                txtDisplay.Text = "0";
            
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            
                commaClicked = false;
                help = -1;
                operation = "/";
                txtDisplay.Text = "0";
            
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            
                commaClicked = false;
                help = -1;
                operation = "x";
                txtDisplay.Text = "0";
            
        }

        private void subtract_Click(object sender, RoutedEventArgs e)
        {
            
                commaClicked = false;
                help = -1;


                //txtDisplay.Text = (number1).ToString();
                operation = "-";
                txtDisplay.Text = "0";
            
        }

        private void root_Click(object sender, RoutedEventArgs e)
        {
            commaClicked = false;
            help = -1;
            txtDisplay.Text = Math.Sqrt(number1).ToString();
            number1 = Math.Sqrt(number1);
        }

        private void power_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = Math.Pow(number1, 2).ToString();
            number1 = Math.Pow(number1, 2);
        }

        private void plusorminus_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                txtDisplay.Text = (-number1).ToString();
                number1 = -number1;
            }
            else
            {
                txtDisplay.Text = (-number2).ToString();
                number2 = -number2;
            }
        }

        private void comma_Click(object sender, RoutedEventArgs e)
        {
            commaClicked = true;
            string message;
            if (operation == "")
            {
                message = number1.ToString() + ",";
            }
            else
            {
                message = number2.ToString() + ",";
            }
            txtDisplay.Text = message;
        }
  
    }
}
