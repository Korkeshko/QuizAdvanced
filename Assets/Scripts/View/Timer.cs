using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace View
{
    [RequireComponent(typeof(Slider))]
    public class Timer : MonoBehaviour
    {
        public float TimeLasts => slider.value;

        [SerializeField] private float maxTime = 20f;
        [SerializeField] private Slider slider;
        [SerializeField] private Image sliderBar;
        [SerializeField] private Gradient gradient;
        public readonly UnityEvent EndOfTimeEvent = new();

        private void Awake()
        {
            slider.maxValue = maxTime;
            slider.value = maxTime;
        }

        void Update()
        {
            slider.value -= Time.deltaTime;
            if (slider.value <= 0)
            {
                EndOfTimeEvent.Invoke();
            }

            float normalizedTime = slider.value / maxTime;
            sliderBar.color = gradient.Evaluate(normalizedTime);
        }

        public void Add(float value)
        {
            slider.value += value;
        }
    }
}