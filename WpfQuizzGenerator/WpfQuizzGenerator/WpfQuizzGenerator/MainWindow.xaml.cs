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
using WpfQuizzGenerator.Model;

namespace WpfQuizzGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<Question> listOfQuestions = new List<Question>();
        string rightAnswer = string.Empty;

        public MainWindow()
        {

            InitializeComponent();
            var result = MessageBox.Show("Would you like to create a new quiz?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

           if (result == MessageBoxResult.No)
            {
                string quiz_name = "Bula";
                listOfQuestions = LoadData.LoadFromFile($"../../QuizFiles/{quiz_name}.txt");
                textBoxQuizName.Text = quiz_name;
                foreach (Question q in listOfQuestions)
                    Quizzes.Items.Add(q);
            }
            
        }


        private void AddToQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (IsNotEmpty(textBoxQuizName) & IsNotEmpty(textBoxQuestion) & IsNotEmpty(textBoxAA) & IsNotEmpty(textBoxAB) & IsNotEmpty(textBoxAC) & IsNotEmpty(textBoxAD))
            {
                Question question = new Question(textBoxQuestion.Text, textBoxAA.Text, textBoxAB.Text,
                    textBoxAC.Text, textBoxAD.Text, rightAnswer);

                Quizzes.Items.Add(question);
                listOfQuestions.Add(question);
                foreach (Question q in listOfQuestions)
                {
                    Console.WriteLine(q);

                }
                rightAnswer = string.Empty;
                textBoxQuestion.Text = "";
                textBoxAA.Text = "";
                textBoxAB.Text = "";
                textBoxAC.Text = "";
                textBoxAD.Text = "";
                A.IsChecked = false;
                B.IsChecked = false;
                C.IsChecked = false;
                D.IsChecked = false;
            }
        }
        private bool IsNotEmpty(TextBoxErrorProvider tb)
        {
            if (tb.Text.Trim() == "")
            {
                tb.SetError("Pole nie może być puste!");
                return false;
            }
            tb.SetError("");
            return true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Quiz quiz = new Quiz(textBoxQuizName.Text, listOfQuestions);
            quiz.ListOfQuestions.ElementAt(0);
            Console.WriteLine(quiz.QuizName);
            SaveQuizToFile.SaveQuizToTextFile(quiz);

            //foreach (Question q in quiz.ListOfQuestions)
            //{
            //    Console.WriteLine(q.AnswerA);
            //    Console.WriteLine(SaveQuizToFile.QuestionToTextFile(q));
            //}

        }

        private void Quizzes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Question q = Quizzes.SelectedItem as Question;
            if (q != null)
            {
                textBoxQuestion.Text = q.QuestionText;
                textBoxAA.Text = q.AnswerA;
                textBoxAB.Text = q.AnswerB;
                textBoxAC.Text = q.AnswerC;
                textBoxAD.Text = q.AnswerD;
                switch (q.RightAnswer)
                {
                    case "A":
                        A.IsChecked = true;
                        B.IsChecked = false;
                        C.IsChecked = false;
                        D.IsChecked = false;
                        break;
                    case "B":
                        B.IsChecked = true;
                        A.IsChecked = false;
                        C.IsChecked = false;
                        D.IsChecked = false;
                        break;
                    case "C":
                        C.IsChecked = true;
                        A.IsChecked = false;
                        B.IsChecked = false;
                        D.IsChecked = false;
                        break;
                    case "D":
                        D.IsChecked = true;
                        A.IsChecked = false;
                        B.IsChecked = false;
                        C.IsChecked = false;

                        break;
                }


            }
        }
        private void checkBoxClicked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rightAnswer += c.Name.ToString();
            Console.WriteLine(rightAnswer);
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult decision = MessageBox.Show("Do you want to modify this question?", "Modifiy Question", MessageBoxButton.YesNo);
            switch (decision)
            {
                case MessageBoxResult.Yes:


                    ((Question)Quizzes.SelectedItem).QuestionText = textBoxQuestion.Text;
                    ((Question)Quizzes.SelectedItem).AnswerA = textBoxAA.Text;
                    ((Question)Quizzes.SelectedItem).AnswerB = textBoxAB.Text;
                    ((Question)Quizzes.SelectedItem).AnswerC = textBoxAC.Text;
                    ((Question)Quizzes.SelectedItem).AnswerD = textBoxAD.Text;
                    //A.IsChecked = false;
                    //B.IsChecked = false;
                    //C.IsChecked = false;
                    //D.IsChecked = false;
                    switch (((Question)Quizzes.SelectedItem).RightAnswer)
                    {
                        case "A":
                            A.IsChecked = true;

                            break;
                        case "B":
                            B.IsChecked = true;

                            break;
                        case "C":
                            C.IsChecked = true;

                            break;
                        case "D":
                            A.IsChecked = true;

                            break;


                    }
                    ((Question)Quizzes.SelectedItem).RightAnswer = C.Name;
                    Quizzes.Items.Refresh();

                    rightAnswer = string.Empty;
                    textBoxQuestion.Text = "";
                    textBoxAA.Text = "";
                    textBoxAB.Text = "";
                    textBoxAC.Text = "";
                    textBoxAD.Text = "";
                    A.IsChecked = false;
                    B.IsChecked = false;
                    C.IsChecked = false;
                    D.IsChecked = false;


                    break;
            }
        }

        private void checkBoxUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rightAnswer = rightAnswer.Trim(c.Name.ToCharArray());
            Console.WriteLine(rightAnswer);
        }

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Quizzes.SelectedItem != null)
            {
                MessageBoxResult result =
                    MessageBox.Show("Do you want to delete this Question?",
                    "Delete Question", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (Quizzes.SelectedItem != null)
                            Quizzes.Items.Remove(Quizzes.SelectedItem);
                        break;
                }
            }
        }
    }
}
