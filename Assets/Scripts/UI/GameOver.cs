using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] SpriteRenderer backgraund;
        //[SerializeField] public ScoreUiGameOver scoreUiGameOver;

        private void SetSprites(bool isNewScore)
        {
            if (!backgraund)
            {
                backgraund = gameObject.GetComponent<SpriteRenderer>();
            }
            if (!isNewScore)
            {
                if (Main.mainGame.gameSettings.LanguageSetting == Language.English)
                {
                    backgraund.sprite = Resources.Load<Sprite>("UI/En/GameOver1") as Sprite;
                }
                if (Main.mainGame.gameSettings.LanguageSetting == Language.Russian)
                {
                    backgraund.sprite = Resources.Load<Sprite>("UI/Ru/GameOver1") as Sprite;
                }
            }
            if (isNewScore)
            {
                if (Main.mainGame.gameSettings.LanguageSetting == Language.English)
                {
                    backgraund.sprite = Resources.Load<Sprite>("UI/En/GameOver2") as Sprite;
                }
                if (Main.mainGame.gameSettings.LanguageSetting == Language.Russian)
                {
                    backgraund.sprite = Resources.Load<Sprite>("UI/Ru/GameOver2") as Sprite;
                }
            }
        }

        public void SetMenu(bool isNewScore)
        {
            Debug.Log("SetMenu(bool isNewScore)" + isNewScore);

            SetSprites(isNewScore);
            SetScore();
        }

        private void SetScore()
        {
           // scoreUiGameOver.SetScore();
        }
    }
}
