using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GameOverMenuSettings : MonoBehaviour
    {
        //[SerializeField] Image backgraund;
        [SerializeField] Button next;
        [SerializeField] Button exit;
        [SerializeField] SpriteRenderer[] finalScore;
        GridLayoutGroup layoutGroup;


        private void SetSprites()
        {
            if (Main.mainGame.gameSettings.LanguageSetting == Language.English)
            {
                next.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/En/Play") as Sprite;
                exit.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/En/Exit") as Sprite;
            }
            if (Main.mainGame.gameSettings.LanguageSetting == Language.Russian)
            {
                next.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Ru/Play") as Sprite;
                exit.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Ru/Exit") as Sprite;
            }
        }

        public void SetMenu()
        {
            SetSprites();
            PlayAudio();
        }

        private void PlayAudio()
        {
            AudioClip clip = Resources.Load<AudioClip>("AudioClips/gameOver");
            GetComponent<AudioSource>().volume = Main.mainGame.gameSettings.EffectVolume;
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}