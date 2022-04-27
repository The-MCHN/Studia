using System;
using System.Collections.Generic;
using System.IO;
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

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Question> questions;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            String Selected_path = @"C:/Users/acer/Downloads/WpfQuizzGenerator/WpfQuizzGenerator/WpfQuizzGenerator/QuizFiles";
            
            String[] files = Directory.GetFiles(Selected_path);


            //ładuje quizy do listy
            Load_Quiz.Items.Clear();

            foreach (string file in files)
            {
                
                Load_Quiz.Items.Add(file);
            }

            if (Load_Quiz.Items.Count == 0)
            {
                MessageBox.Show("Brak quizów do rozwiązania!");
            }
            
        }

        private void Choose_Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Load_Quiz.SelectedItem.ToString();
            //Console.WriteLine(Load_Quiz.SelectedItem.ToString());
            //string[] pathSplitted = path.Split('/');
            //foreach (string s in pathSplitted)
            //    Console.WriteLine(s);

            questions = LoadQuiz.LoadFromFile(path);

            //QuizMainMenu qmm = new QuizMainMenu(questions);
            QuizGamePlay qgp = new QuizGamePlay(questions);
            qgp.Show();
            this.Close();
        }
    }
}
