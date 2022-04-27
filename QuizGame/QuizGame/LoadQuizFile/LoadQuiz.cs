using QuizGame.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizGame
{
    public static class LoadQuiz
    {
        public static List<Question> LoadFromFile(string path)
        {
            List<Question> questions = new List<Question>();
            if (File.Exists(path))
            {
                string dane = File.ReadAllText(path);
                dane = Crypt.Decipher(File.ReadAllText(path), 3);
                if (dane.Trim() == "")
                    return questions;

                string[] qst = dane.Split('\n');
                Console.WriteLine(qst.Length);
                for (int i = 0; i + 1 < qst.Length; i += 6)
                {
                    questions.Add(new Question(qst[i], qst[i + 1], qst[i + 2], qst[i + 3], qst[i + 4], qst[i + 5]));
                }

            }
            else
            {
                MessageBox.Show("File does not exsists!");
            }
            return questions;
        }
    }
}
