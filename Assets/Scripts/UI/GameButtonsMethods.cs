using UnityEngine;

namespace BerserkAdventure
{
    public class GameButtonsMethods : MonoBehaviour
    {

        public void LabyrinthPause()
        {
            Main.gameState = GameStage.Pause;
            Main.CheckStage();
        }

        public void Play()
        {
            Debug.Log("Play");
            Main.gameState = GameStage.Game;
            Main.CheckStage();
        }


        public void GameContinue()
        {
            Main.gameState = GameStage.GameContinue;
            Main.CheckStage();
        }

        public void Settings()
        {
            Main.gameState = GameStage.Settings;
            Main.CheckStage();
        }

        public void ExitMenu()
        {
            if (Main.gameState == GameStage.Settings)
            {
                Main.gameState = GameStage.MainMenu;
                Main.CheckStage();
                return;
            }

            else 
            {
                Main.gameState = GameStage.MainMenu;
            }
            Main.CheckStage();
        }
        public void ExitGame()
        {
            Application.Unload();
            Application.Quit();
        }


        public void Again()
        {
            //Time.timeScale = 1;
            //Main.gameState = GameStage.Play;
            Main.CheckStage();
        }
    }
}
