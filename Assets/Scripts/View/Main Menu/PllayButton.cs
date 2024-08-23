using UnityEngine;
using UnityEngine.UI;

namespace View.MainMenu
{
    public class PllayButton : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private LoadingScreen loadingScreen;

        private void Awake()
        {
            playButton.onClick.AddListener(() => loadingScreen.LoadScene(1));
        }
    }
}