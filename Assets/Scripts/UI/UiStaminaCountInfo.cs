using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BerserkAdventure
{
    [RequireComponent(typeof(Text))]
    public class UiStaminaCountInfo : MonoBehaviour
    {
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
            if (Main.mainGame.charBerserk)
            {
                _text.text = $"{Main.mainGame.charBerserk.staminaPotionCount}";
            }
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
    }
}
