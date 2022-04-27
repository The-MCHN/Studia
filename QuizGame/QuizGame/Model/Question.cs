using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string RightAnswer { get; set; }

        public Question(string questionText = "Question Text", string answerA = "A",
            string answerB = "B", string answerC = "C", string answerD = "D", string rightAnswer = "")
        {
            QuestionText = questionText;
            AnswerA = answerA;
            AnswerB = answerB;
            AnswerC = answerC;
            AnswerD = answerD;
            RightAnswer = rightAnswer;
        }
        public override string ToString()
        {
            return $"Q: {QuestionText}, A: {AnswerA}, B: {AnswerB}, C: {AnswerC}, D: {AnswerD}, Right is: {RightAnswer}";
        }
    }
}
