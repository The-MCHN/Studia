using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for QuizGamePlay.xaml
    /// </summary>
    public partial class QuizGamePlay : Window
    {
        #region Quiz
        List<Question> questions;
        List<string> wrongAnswer = new List<string>();
        private int currentQuestion = 0;
        private int score = 0;
        private string answer;
        #endregion

        #region Timer
        private Stopwatch _stopwatch;
        private Timer _timer;
        #endregion
        public QuizGamePlay(List<Question> q)
        {
            InitializeComponent();
            this.questions = q;
        }

        private void Answer_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            answer = btn.Name;
            Check_Answer(answer);
            Update_Quiz();

        }

        private void Check_Answer(String answer)
        {
            if (answer == questions[currentQuestion].RightAnswer)
            {
                score++;
            }
            else
            {
                wrongAnswer.Add($"{questions[currentQuestion]} You chose: {answer}");
            }
        }
        private void Update_Quiz()
        {

            currentQuestion++;
            if (currentQuestion < questions.Count())
            {
                Question_Text_Box.Text = questions[currentQuestion].QuestionText;
                A.Content = questions[currentQuestion].AnswerA;
                B.Content = questions[currentQuestion].AnswerB;
                C.Content = questions[currentQuestion].AnswerC;
                D.Content = questions[currentQuestion].AnswerD;
                Score_Text_Box.Text = $"Score: {score}";
            }
            else
            {
                
                _stopwatch.Stop();
                _timer.Stop();

                MessageBox.Show("The End!");

                SummaryWindow sw = new SummaryWindow(score, currentQuestion, wrongAnswer, Timer_Text_Box.Text);
                sw.Show();
                this.Close();

            }
        }

        private void Start_Quiz_Click(object sender, RoutedEventArgs e)
        {
            #region Quiz
            Question_Text_Box.Text = questions[0].QuestionText;
            A.Content = questions[0].AnswerA;
            B.Content = questions[0].AnswerB;
            C.Content = questions[0].AnswerC;
            D.Content = questions[0].AnswerD;
            Score_Text_Box.Text = $"Score: {score}";
            Start_Quiz.IsEnabled = false;
            #endregion

            #region Timer
            _stopwatch = new Stopwatch();
            _timer = new Timer(1000);

            _timer.Elapsed += OnTimerElapse;

            _timer.Start();
            _stopwatch.Start();
            #endregion
        }

        private void OnTimerElapse(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Timer_Text_Box.Text = _stopwatch.Elapsed.ToString(@"mm\:ss");
            });
        }

        private void Exit_Quiz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
