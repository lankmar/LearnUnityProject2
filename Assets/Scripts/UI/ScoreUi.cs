using System;
using UnityEngine;
namespace BerserkAdventure
{
    public class ScoreUi : MonoBehaviour
    {
        [SerializeField] SpriteRenderer[] sprites;

        void Update()
        {
            SetScore();
        }

        public void SetScore()
        {
            if (Main.gameState == GameStage.Game)
            {
                string score = Main.playerScore.ToString();
                char[] scoreReverse = score.ToCharArray();
                Array.Reverse(scoreReverse);
                for (int i = 0; i < scoreReverse.Length; i++)
                {
                    string path = string.Format("Numbers/{0}", scoreReverse[i].ToString());
                    //Debug.Log(path);
                    sprites[i].enabled = true;
                    sprites[i].sprite = Resources.Load<Sprite>(path);
                }
            }
        }

        public void SetScoreNull()
        {
            string path = string.Format("Numbers/empty");
            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].sprite = Resources.Load<Sprite>(path);
            }
        }

    }
}