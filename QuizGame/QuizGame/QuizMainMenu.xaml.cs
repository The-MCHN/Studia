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
    /// Interaction logic for QuizMainMenu.xaml
    /// </summary>
    public partial class QuizMainMenu : Window
    {
        private List<Question> questions;
        public QuizMainMenu(List<Question> q)
        {
            InitializeComponent();
            this.questions = q;
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            //QuizGamePlay quizGame = new QuizGamePlay(questions);
            //quizGame.Show();
            //this.Close();
        }
    }
}
