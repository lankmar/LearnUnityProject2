using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class SettingsMenuBackground : MonoBehaviour
    {
        [SerializeField] Image musicTitle;
        [SerializeField] Image effectsTitle;
        [SerializeField] Image languageTitle;
        //[SerializeField] Image control;
        [SerializeField] Button exitButton;
        GridLayoutGroup gridLayoutGroup;
        Vector2 screenSize;
        [SerializeField] Image imageBackground;

        private void Start()
        {
            imageBackground = gameObject.GetComponent<Image>() as Image;
            gridLayoutGroup = gameObject.GetComponent<GridLayoutGroup>();
            screenSize = new Vector2(Screen.height, Screen.width);
            SetSellSize();
            SetSpasing();
            SetImageSize();
            //SetTitleSprite();
        }


        private void SetImageSize()
        {
            if (imageBackground) imageBackground.transform.localScale = new Vector2(0.5f, 0.5f);
        }

        //private void SetTitleSize()
        //{
        //    Vector2 size = new Vector2(1,0.5f);
        //    if (musicTitle) musicTitle.transform.localScale = size;
        //    if (effectsTitle) effectsTitle.transform.localScale = size;
        //    if (languageTitle) languageTitle.transform.localScale = size;
        //    //if (control) control.transform.localScale = size;
        //}

        private void SetTitleSprite()
        {
            if (Main.mainGame.language == Language.English)
            {
                musicTitle.sprite = Resources.Load<Sprite>("UI/En/Music") as Sprite;
                effectsTitle.sprite = Resources.Load<Sprite>("UI/En/Effects") as Sprite;
                languageTitle.sprite = Resources.Load<Sprite>("UI/En/Language") as Sprite;
               // control.sprite = Resources.Load<Sprite>("UI/En/Control") as Sprite;
                exitButton.image.sprite = Resources.Load<Sprite>("UI/En/Exit") as Sprite;
            }
            if (Main.mainGame.language == Language.Russian)
            {
                musicTitle.sprite = Resources.Load<Sprite>("UI/Ru/Music") as Sprite;
                effectsTitle.sprite = Resources.Load<Sprite>("UI/Ru/Effects") as Sprite;
                languageTitle.sprite = Resources.Load<Sprite>("UI/Ru/Language") as Sprite;
               // control.sprite = Resources.Load<Sprite>("UI/Ru/Control") as Sprite;
                exitButton.image.sprite = Resources.Load<Sprite>("UI/Ru/Exit") as Sprite;
            }
        }
        private void SetSpasing()
        {
            gridLayoutGroup.spacing = new Vector2(600, 170);
        }

        private void SetSellSize()
        {
            gridLayoutGroup.cellSize = new Vector2(screenSize.x / 1f, screenSize.y / 8f);
        }

        public void SetMenu()
        {
            Start();
            SetTitleSprite();
        }
    }
}