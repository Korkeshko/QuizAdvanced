using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View.MainMenu
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Canvas canvas;
        [SerializeField] private float delay;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(int sceneID)
        {
            StartCoroutine(Load(sceneID));
        }

        private IEnumerator Load(int sceneID)
        {
            canvas.enabled = true;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);
            while (!asyncLoad.isDone)
            {
                slider.value = asyncLoad.progress;
                yield return null;
            }

            slider.value = 1;
            yield return new WaitForSecondsRealtime(delay);
            canvas.enabled = false;
        }
    }
}