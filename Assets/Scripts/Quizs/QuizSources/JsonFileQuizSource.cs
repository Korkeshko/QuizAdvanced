using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using QuizGameCore;
using System.Linq;

namespace Quizs.QuizSources
{
    public class JsonFileQuizSource : MonoBehaviour, IQuizSource
    {
        [SerializeField] private TextAsset jsonFile;

        public IReadOnlyList<IQuiz> QuizeList()
        {
            string rawText = jsonFile.text;
            List<QuizData> data = JsonConvert.DeserializeObject<List<QuizData>>(rawText);

            return data.Select(quizData => quizData.Create()).ToList();

            // List<IQuiz> iquizzes = new List<IQuiz>();
            // foreach (QuizData quizData in data)
            // {
            //     IQuiz newQuiz = quizData.Create();
            //     iquizzes.Add(newQuiz);
            // }
            // return iquizzes;
        }
    }

    public class QuizData
    {
        public string question;
        public string correctAnswer;
        public string[] wrongAnswers;

        public IQuiz Create()
        {
            return new Quiz(question, correctAnswer, wrongAnswers);
        }
    }
}