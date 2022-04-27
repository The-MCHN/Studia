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
using System.Windows.Shapes;

namespace WpfQuizzGenerator
{
    /// <summary>
    /// Interaction logic for ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Window
    {
        public ChooseWindow()
        {
            InitializeComponent();
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            //sciezka
            String Selected_path = $"../../SaveData/";
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
            String Selected_Quiz;
            if (Load_Quiz.SelectedItem != null)
            {
                Selected_Quiz = Load_Quiz.SelectedItem.ToString();
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wybierz quiz!");
            }
        }

        private void Create_New_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
