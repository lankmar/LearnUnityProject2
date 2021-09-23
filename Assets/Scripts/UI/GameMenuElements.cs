using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class GameMenuElements : MonoBehaviour
    {
        [SerializeField] Image imageHp;
        //[SerializeField] Image levelTitle;
        //[SerializeField] Text score;
        //[SerializeField] Text level;
        Vector2 screenSize;
        Vector2 size = new Vector2(1, 0.3f);
        Vector2 scoreSize = new Vector2(200, 40);
        Vector3 scoreTitlePosition = new Vector3(1, 0.3f, 0);
        Vector3 levelTitlePosition = new Vector3(1, 0.3f, 0);
        Vector3 scorePosition = new Vector3(1, 0.3f, 0);
        Vector3 levelPosition = new Vector3(1, 0.3f, 0);
        //float scoreSize = 2;

        // [SerializeField] Image imageBackground;

        public void Start()
        {
            //imageHp = GetComponent<UiHpImage>().gameObject.GetComponent<Image>();
            //    imageBackground = gameObject.GetComponent<Image>() as Image;
            //    screenSize = new Vector2(Screen.height, Screen.width);
            //    SetTitleSprite();
            //    SetTitleSize();
            //    SetTitlesPosition();
            //    SetImageSize();
        }


            private void SetImageSize()
        {
           // if (imageBackground) imageBackground.transform.localScale = new Vector2(0.5f, 0.5f);
        }

        private void SetTitleSize()
        {
            SetElementsSize();
            //Debug.Log("SetTitleSize()");
            //Vector2 size = new Vector2(1, 0.3f);
            //if (scoreTitle) scoreTitle.transform.localScale = size;
            //if (levelTitle) levelTitle.transform.localScale = size;
        }

        private void SetTitleSprite()
        {
            if (Main.mainGame.gameSettings.LanguageSetting == Language.English)
            {
                //scoreTitle.sprite = Resources.Load<Sprite>("UI/En/Score") as Sprite;
                //levelTitle.sprite = Resources.Load<Sprite>("UI/En/Level") as Sprite;
            }
            if (Main.mainGame.gameSettings.LanguageSetting == Language.Russian)
            {
                //scoreTitle.sprite = Resources.Load<Sprite>("UI/Ru/Score") as Sprite;
                //levelTitle.sprite = Resources.Load<Sprite>("UI/Ru/Level") as Sprite;
            }
        }

        private void SetTitlesPosition()
        {
            SetElementsPosition();
            //scoreTitle.transform.position = scoreTitlePosition;
            //levelTitle.transform.position = levelTitlePosition;
           // Debug.Log("scorePosition  score.transform.position " + scorePosition    +"   "+ score.transform.position);

            //score.GetComponent<RectTransform>().sizeDelta = scoreSize;
            //score.fontSize = 35;

            ////score.gameObject.transform.localScale = scoreSize; 
            //score.transform.position = scorePosition;
           // Debug.Log("scorePosition  score.transform.position " + scorePosition    +"   "+ score.transform.position);
            //level.transform.position = levelPosition;
            //level.transform.position = levelPosition;
        }

        public void SetMenu()
        {
            Debug.Log("SetMenu()");

            SetTitleSprite();
            SetElementsPosition();
            SetElementsSize();
            SetTitleSize();
            SetTitlesPosition();
        }

        private void SetElementsSize()
        {
            if (Screen.height < 800) size = new Vector2(1, 0.3f);
            if (Screen.height >= 800 && Screen.height < 1280) size = new Vector2(2f, 0.5f);
            if (Screen.height >= 1280 && Screen.height < 1920) size = new Vector2(2.7f, 0.7f);
            if (Screen.height >= 1920 && Screen.height < 2160) size = new Vector2(3.7f, 1.2f);
            if (Screen.height >= 2160 && Screen.height < 2560) size = new Vector2(2.6f, 0.9f);
            if (Screen.height >= 2560 && Screen.height < 2960) size = new Vector2(3.1f, 1.2f);
            if (Screen.height >= 2960) size = new Vector2(5.1f, 5.1f);
            //gameObject.transform.localScale = size;
            //music.transform.localScale = ;
            //    effects;
            //     language;
            //     control;
        }

        private void SetElementsPosition()
        {
            if (Screen.height < 800) scoreTitlePosition = new Vector2(1, 0.3f);
            if (Screen.height >= 800 && Screen.height < 1920)
            {
            Debug.Log("SetElementsPosition()");
                scoreTitlePosition = new Vector3(Screen.width/4.5f, Screen.height - Screen.height / 8.8f, 0);
                levelTitlePosition = new Vector3(Screen.width - Screen.width / 5.5f, Screen.height - Screen.height / 6f, 0);
                scorePosition = new Vector3(Screen.width / 2.3f, Screen.height - Screen.height/9, 0);
                levelPosition = new Vector3(0, 0, 0);
                //scoreSize = new Vector2();
            }
            else if (Screen.height >= 1280 && Screen.height < 1920) size = new Vector2(2.1f, 0.7f);
            {
                scoreTitlePosition = new Vector3(Screen.width / 6, Screen.height - Screen.height / 10f, 0);
                levelTitlePosition = new Vector3(Screen.width - Screen.width / 6, Screen.height - Screen.height / 8f, 0);
            }
            if(Screen.height >= 1920 && Screen.height < 2160) size = new Vector2(3.7f, 1.2f);
            else if (Screen.height >= 2160 && Screen.height < 2560) size = new Vector2(2.6f, 0.9f);
            else if(Screen.height >= 2560 && Screen.height < 2960) size = new Vector2(3.1f, 1.2f);
            else if(Screen.height >= 2960) size = new Vector2(5.1f, 5.1f);
        }
    }
}
