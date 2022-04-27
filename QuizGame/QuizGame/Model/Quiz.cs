using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Model
{
    public class Quiz
    {
        public string QuizName { get; set; }

        public List<Question> ListOfQuestions { get; set; }


        public Quiz(string quizName, List<Question> listOfQuestions)
        {
            QuizName = quizName;
            ListOfQuestions = listOfQuestions;

        }
        public override string ToString()
        {
            return $"Quiz Name: {QuizName}, Questions: {ListOfQuestions}";
        }
    }
}
