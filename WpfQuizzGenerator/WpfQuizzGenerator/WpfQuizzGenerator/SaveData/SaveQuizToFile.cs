using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuizzGenerator.Model;
using WpfQuizzGenerator.SaveData;

namespace WpfQuizzGenerator
{
    public class SaveQuizToFile
    {
        public static string QuestionToTextFile(Question q) 
        {
            string result = $"{q.QuestionText}\n{q.AnswerA}\n{q.AnswerB}\n{q.AnswerC}\n{q.AnswerD}\n{q.RightAnswer}\n";

            return result;
        }
    
        public static void SaveQuizToTextFile(Quiz q)
        {
            string path = $"../../QuizFiles/{q.QuizName}.txt";
            string finalText = "";
            foreach (Question que in q.ListOfQuestions) { 
            string text = QuestionToTextFile(que);
                text = Encrypt.Encipher(text, 3);
                finalText += text;
                //File.WriteAllText(path, text);
                
                
            }
            File.WriteAllText(path, finalText);
        }
    }
}
