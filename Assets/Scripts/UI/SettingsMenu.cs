using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] Scrollbar music;
        [SerializeField] Scrollbar effects;
        [SerializeField] Dropdown language;
        [SerializeField] Button control;

        [SerializeField] AudioSource audioSourceMusic;
        [SerializeField] AudioSource audioSourceEffects;

        //[SerializeField] GameObject panel;

        float timer = 0f;
        float prevEffectsValue = -1f;
        float timerOffset = 0.8f;

        private void Start()
        { 
            SetElementsSize();
        }

        private void Update()
        {
            SetElementsSize();
            if (Time.frameCount == 5f ) prevEffectsValue = Main.mainGame.gameSettings.EffectVolume;
            if (!audioSourceMusic)
            {
                Camera go = FindObjectOfType<Camera>();
                if (go) audioSourceMusic = go.GetComponent<AudioSource>();
            }
            SetElementsSize();
            if (!audioSourceEffects)
            {

            }
            if (audioSourceMusic)
            {
                audioSourceMusic.volume = music.value;
            }
            if (audioSourceEffects)
            {
                audioSourceEffects.volume = effects.value;
            }
            if (audioSourceEffects && timer >= timerOffset && effects.value != prevEffectsValue && prevEffectsValue != -1)
            {
                EffectsSound();
                prevEffectsValue = effects.value;
                timer = 0;
            }
            timer += Time.deltaTime;
        }


        public void SetElementValue() 
        {

            #region language
            if (Main.mainGame.gameSettings.LanguageSetting == Language.English)
            {
                language.captionText.text = "English";
                language.options[0].text = "English";
                language.options[1].text = "Russian";
                language.value = 0;
            }
            if (Main.mainGame.gameSettings.LanguageSetting == Language.Russian)
            {
                language.captionText.text = "Русский";
                language.options[0].text = "Английский";
                language.options[1].text = "Русский";
                language.value = 1;
            }
            #endregion



            #region music
            if (Main.mainGame.gameSettings.MusicVolume > 1 || Main.mainGame.gameSettings.MusicVolume < 0)
            {
                music.value = 1;
            }
            else music.value = Main.mainGame.gameSettings.MusicVolume;
            #endregion

            #region effects
            if (Main.mainGame.gameSettings.EffectVolume > 1 || Main.mainGame.gameSettings.EffectVolume < 0)
            {
                effects.value = 1;
            }
            else effects.value = Main.mainGame.gameSettings.EffectVolume;
            #endregion
        }
        private void SetElementsSize()
        {
            Vector2 size = new Vector2(1, 1);  
            size = new Vector2(1,1);

            gameObject.transform.localScale = size;
        }

        public void  СhangeLanguage()
        {
            if (language.value == 0)
            {
                Main.mainGame.gameSettings.LanguageSetting = Language.English;
                Main.mainGame.ReloadMenu();
            }
            if (language.value == 1)
            {
                Main.mainGame.gameSettings.LanguageSetting = Language.Russian;
                Main.mainGame.ReloadMenu();
            }
        }

      
        public void ChangeMusicVolume()
        {
            if (music.value != Main.mainGame.gameSettings.MusicVolume)
            {
                Main.mainGame.gameSettings.MusicVolume = music.value;
                Main.mainGame.ReloadMenu();
            }
        }

        public void ChangeEffectsVolume()
        {
            if (effects.value != Main.mainGame.gameSettings.EffectVolume)
            {
                Main.mainGame.gameSettings.EffectVolume = effects.value;
                Main.mainGame.ReloadMenu();
            }
        }

        private void EffectsSound()
        { 
            AudioClip audioClip = Resources.Load<AudioClip>("AudioClips/move");
            audioSourceEffects.PlayOneShot(audioClip);
        }
    }
}