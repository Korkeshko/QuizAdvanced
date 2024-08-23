using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace View.Buttons
{
    public class WobbleButton : MonoBehaviour, IButtonEffect
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => Notify(Random.Range(0, 2) > 0));
        }
        
        public void Notify(bool correct)
        {
            if (!correct) Wobble();
        }

        private void Wobble()
        {
            transform.DOKill();
            transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0), 0.5f, 10, 1);
        }
    }
}