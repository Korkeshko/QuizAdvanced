using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Button = UnityEngine.UI.Button;


namespace View
{
    [RequireComponent(typeof(Button))]
    public class AnswerButton : MonoBehaviour, IView<string>
    {
        public readonly UnityEvent<string> clicked = new();
        [SerializeField] private TMP_Text answerText = null!;


        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(
                () => clicked.Invoke(answerText.text)
            );
        }


        public void Render(string value)
        {
            answerText.SetText(value);
        }
    }
}