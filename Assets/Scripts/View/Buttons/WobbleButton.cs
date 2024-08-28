using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace View.Buttons
{
    [RequireComponent(typeof(Button))]
    public class WobbleButton : MonoBehaviour, IButtonEffect
    {
        [SerializeField] private float power = 0.2f;
        [SerializeField] private float duration = 0.3f;
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => Notify(Random.Range(0, 2) > 0));
        }
        
        public void Notify(bool correct)
        {
            if (correct)
            {
                return;
            }
            
            transform.DOKill();
            transform.DOPunchScale(Vector3.one * power, duration);
        }
    }   
}