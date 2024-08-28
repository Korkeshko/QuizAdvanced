using QuizGameCore;
using System.Collections.Generic;

namespace Quizs.QuizSources
{
    public interface IQuizSource
    {
        public IReadOnlyList<IQuiz> QuizeList();
    }
}