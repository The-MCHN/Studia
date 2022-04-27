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
using System.Windows.Shapes;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        public SummaryWindow(int record, int score, List<string> wrongAnswers, string elapsedTime)
        {
            InitializeComponent();
            Text_Box.Text = $"Your score is: {record}/{score}\nElapsed time: {elapsedTime}";

            foreach(string s in wrongAnswers)
            {
                Wrong_Answers.Items.Add(s);
            }

        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("See you again!", "Goodbye", MessageBoxButton.OK);
            this.Close();
        }
    }
}
