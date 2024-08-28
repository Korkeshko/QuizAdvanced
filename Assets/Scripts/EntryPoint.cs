using System.Collections;
using QuizGameCore.Utils;
using Quizs;
using Quizs.Fails;
using Quizs.QuizSources;
using UnityEngine;
using View;


public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private QuizView quizView;
    [SerializeField] private Attempts attempts;
    [SerializeField] private float rewardTime;
    [SerializeField] private float suspendNextQuestion;

    IEnumerator Start()
    {
        var waitFail = WaitFail(
            new IFail.Any(
                new AttemptsFail(attempts),
                new TimerFail(timer)
            ).Cache(out var fail)
        );

        foreach (var info in GetComponent<IQuizSource>().QuizeList())
        {
            quizView.Render(
                new AwaitCorrectAnswerQuiz(
                    new ShuffledQuiz(
                        new AttemptsQuiz(
                            new TimedQuiz(
                                info,
                                timer,
                                rewardTime
                            ),
                            attempts
                        )
                    )
                ).Cache(out var quiz)
            );
            
            yield return WaitAny(
                quiz.WaitCorrect(),
                waitFail
            );

            if (fail.Failed)
            {
                Debug.Log("Fail");
                break;
            }

            yield return new WaitForSeconds(suspendNextQuestion);
        }

        quizView.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
    }

    private IEnumerator WaitAny(params IEnumerator[] items)
    {
        bool doneAny = false;
        IEnumerator WaitDone(IEnumerator enumerator)
        {
            yield return enumerator;
            doneAny = true;
        }

        foreach (var item in items)
        {
            StartCoroutine(WaitDone(item));
        }

        while (doneAny == false)
        {
            yield return null;
        }
    }
    
    private IEnumerator WaitFail(IFail fail)
    {
        while (fail.Failed == false)
        {
            yield return null;
        }
    }
}