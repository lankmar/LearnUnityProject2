using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class UiScoreText : MonoBehaviour
    {
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
            SetPositionAndSize();
        }

        public string Text
        {
            set
            {
                if (!_text)
                {
                    Start();
                }
                _text.text = $"{value}";
            }
        }

        public void SetActive(bool value)
        {
            _text.gameObject.SetActive(value);
        }

        private void SetPositionAndSize()
        {
            gameObject.transform.localScale = new Vector2(1, 1);
           // gameObject.transform.position = new Vector3(Screen.width / 10, Screen.height - Screen.height / 10f);
        }
    }
}
