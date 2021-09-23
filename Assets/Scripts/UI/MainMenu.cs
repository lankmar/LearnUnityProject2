using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Button play;
        [SerializeField] Button settings;
        [SerializeField] Button exit;

        public void Start()
        {
            SetButtonsImage();
            //SetButtonSettingsImage();
            //SetButtonExitImage();
            //AudioSource audio = FindObjectOfType<AudioSource>();
            //if (audio.mute == true)
            //{
            //    GameObject go = GameObject.Find("Audio");
            //    go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Music/sound_off");
            //}
            //if (audio.mute == false)
            //{
            //    GameObject go = GameObject.Find("Audio");
            //    go.GetComponent<Image>().sprite = Resources.Load<Sprite>("Music/sound_on");
            //}

        }

        private void SetButtonsImage()
        {

            if (Main.mainGame.gameSettings != null)
            {
                if (Main.mainGame.gameSettings.LanguageSetting == Language.English)
                {
                    play.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/En/Play") as Sprite;
                    settings.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/En/SettingsBut") as Sprite;
                    exit.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/En/Exit") as Sprite;
                }
                if (Main.mainGame.gameSettings.LanguageSetting == Language.Russian)
                {
                    play.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Ru/Play") as Sprite;
                    settings.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Ru/SettingsBut") as Sprite;
                    exit.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Ru/Exit") as Sprite;
                }
            }
            else
            {
                if (Application.systemLanguage == SystemLanguage.Russian)
                {
                    play.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Ru/Play") as Sprite;
                    settings.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Ru/SettingsBut") as Sprite;
                    exit.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Ru/Exit") as Sprite;
                }
                else
                {
                    play.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/En/Play") as Sprite;
                    settings.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/En/SettingsBut") as Sprite;
                    exit.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/En/Exit") as Sprite;
                }
            }
        }

        public void SetMenu()
        {
            SetButtonsImage();
        }
        
    }
}

