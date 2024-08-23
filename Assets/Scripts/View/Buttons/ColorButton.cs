using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace View.Buttons
{
    public class ColorButton : MonoBehaviour, IButtonEffect
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => Notify(Random.Range(0, 2) > 0));
        }

        public void Notify(bool correct)
        {
            Color color = correct ? Color.green : Color.red;
            button.image.DOColor(color, 0.5f).OnComplete(() =>
            {
                button.image.DOColor(Color.white, 0.5f);
            });
        }
    }
}