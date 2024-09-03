using LeaderBoard;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.LeaderBoards
{
    public class SubmitLeaderView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameField;
        [SerializeField] private Timer timer;
        [SerializeField] private Button button;
        [SerializeField] private Attempts attempts;

        private void Start()
        {
            button.onClick.AddListener(async () => await GetComponent<LocalLeaderBoard>().NoteAsync(nameField.text, timer.TimeLasts, attempts.Count));
        }
    }
}