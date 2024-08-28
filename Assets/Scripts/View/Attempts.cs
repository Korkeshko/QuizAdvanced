using TMPro;
using UnityEngine;

namespace View
{
    public class Attempts : MonoBehaviour
    {
        [SerializeField] private int count;
        [SerializeField] private TMP_Text text;

        private void Awake()
        {
            UpdateText();
        }

        private void Increase()
        {
            //Todo
        }

        public void Decrease()
        {
            if (count <= 0) return;
            count--;
            UpdateText();
        }

        private void UpdateText()
        {
            text.text = $"Attempts: {count}";
        }

        public int Count => count;
    }
}