using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class Main : MonoBehaviour
    {
        public static Main mainGame;

        [SerializeField] public static GameStage gameState;
        [SerializeField] private GameObject berserk;
        UiLoader uiLoader;
        public static int playerScore;
        [SerializeField]  List<Enemy> enemies;
        public static int enemyCount;
        [HideInInspector] public Berserk charBerserk;
        public Canvas[] allCanvases;

        public GameStage currentGameStage = GameStage.MainMenu;

        public List<Canvas> canvasGroup;
        Camera mainCamera;
        
        #region Timer
        public float timeTrapActivation = 0;
        Timer timer;
        TimeSpan ts = new TimeSpan();
        public bool timerIsActive = false;
        UiTimerText uiTimerText;
        UiHpImage uiHpImage;
        #endregion

        #region GameSettings
        public GameSettings gameSettings;
        public Language language;
        #endregion



        private void Awake()
        {
            gameSettings = new GameSettings();
            allCanvases = FindObjectsOfType<Canvas>();
            uiLoader = GetComponent<UiLoader>();
            mainGame = GetComponent<Main>();
            mainGame.enabled = true;
            mainGame.uiLoader.UiLoaderStart(ref allCanvases, FindObjectsOfType<Image>(), FindObjectsOfType<Button>());
            if (!berserk)
            {
                berserk = FindObjectOfType<InputManager>().gameObject;
            }
            charBerserk = FindObjectOfType<Berserk>();
        }

        private void Start()
        {
            //var path = Application.dataPath;
            uiTimerText = FindObjectOfType<UiTimerText>();
            uiHpImage = FindObjectOfType<UiHpImage>();
            allCanvases = FindObjectsOfType<Canvas>();
            canvasGroup = uiLoader.CanvasInitialization(ref allCanvases);
            timer = new Timer();
            if (Application.systemLanguage == SystemLanguage.Russian)
            {
                language = Language.Russian;
            }
            else language = Language.English;

            mainCamera = FindObjectOfType<Camera>();
            mainCamera.GetComponent<CameraController>().enabled = false;
            berserk.GetComponent<InputManager>().enabled = false;
            //gameState = GameStage.MainMenu; 

            gameState = GameStage.Game;
            CheckStage();

        }


        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Escape))
            //{
            //    gameState = GameStage.Pause;
            //    CheckStage();
            //}
            if (gameState == GameStage.Game)
            { 
                if(!uiHpImage) uiHpImage = FindObjectOfType<UiHpImage>();
                uiHpImage.ImageHp = charBerserk.Hp / 100;
            }
        }

        public static void CheckStage()
        {

            switch (gameState)
            {
                case GameStage.MainMenu:
                    mainGame.MainMenuLoad();
                    break;
                case GameStage.Game:
                    mainGame.GameStart();
                    mainGame.currentGameStage = GameStage.Game;
                    break;
                case GameStage.Help:
                    mainGame.HelpLoad();
                    break;
                case GameStage.Win:
                    mainGame.Win();
                    break;
                case GameStage.Lose:
                    mainGame.Lose();
                    break;
                case GameStage.Settings:
                    mainGame.SettingsMenuLoad();
                    break;
                case GameStage.GameContinue:
                    mainGame.GameContinue();
                    break;
                case GameStage.Pause:
                    mainGame.GamePause();
                    break;
                case GameStage.Quest:
                    mainGame.GameQuest();
                    break;
                default:
                    break;
            }
        }

        private void SettingsMenuLoad()
        {
            mainCamera = FindObjectOfType<Camera>();
            mainCamera.GetComponent<CameraController>().enabled = false;
            allCanvases = FindObjectsOfType<Canvas>();
            canvasGroup = uiLoader.CanvasInitialization(ref allCanvases);
            uiLoader.CanvasSwitchOn("Settings", null);
        }

        private void GameQuest()
        {
            ts = TimeSpan.FromSeconds(timeTrapActivation);
            uiLoader.CanvasSwitchOn("Quest", "GameUI");
            foreach (var item in FindObjectsOfType<Canvas>())
            {
                if (item.GetComponent<QuestTextSettings>() != null) item.GetComponentInChildren<Text>().text = string.Format("Выберететесь из ловушки за {0}:{1}", ts.Minutes, ts.Seconds);
            }
        }

        private void MainMenuLoad()
        {
            mainCamera = FindObjectOfType<Camera>();
            mainCamera.GetComponent<CameraController>().enabled = false;
            allCanvases = FindObjectsOfType<Canvas>();
            canvasGroup = uiLoader.CanvasInitialization(ref allCanvases);
            uiLoader.CanvasSwitchOn("MainMenu", null);
        }

        private void GamePause()
        {
            uiLoader.CanvasSwitchOn("Pause", "GameUI");
            Time.timeScale = 0;
        }

        private void GameContinue()
        {
            mainCamera = FindObjectOfType<Camera>();
            mainCamera.GetComponent<CameraController>().enabled = true;
            uiLoader.CanvasSwitchOn("GameUI", null);
            Time.timeScale = 1;
        }
        public void HelpLoad(string help = "Help")
        {
            mainCamera = FindObjectOfType<Camera>();
            mainCamera.GetComponent<CameraController>().enabled = false;
            ReloadGame();
            uiLoader.CanvasSwitchOn(help, null);

            uiLoader.CanvasSwitchOn(help, null);
        }

        private void GameStart()
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            enemyCount = enemies.Length;
            currentGameStage = GameStage.Game;
            StartLoadGame();
            //uiTimerText = FindObjectOfType<UiTimerText>();
            Time.timeScale = 1;
            //if (uiTimerText != null) uiTimerText.Text = " ";
        }

        private void StartLoadGame()
        {
            uiLoader.CanvasSwitchOn("GameUI", null);
            if (!mainCamera)
            {
                mainCamera = FindObjectOfType<Camera>();
            }
            mainCamera.GetComponent<CameraController>().enabled = true;
            if (!berserk)
            {
                berserk = FindObjectOfType<MovementCharController>().gameObject;
                if (!berserk) berserk = GameObject.FindGameObjectWithTag("Player");
            }
            berserk.GetComponent<MovementCharController>().enabled = true;
            berserk.GetComponent<InputManager>().enabled = true;
            Time.timeScale = 1;
        }

        #region Reload
        private void ReloadGame(string srt = "full")
        {
            
        }

       
        #endregion


        private void Win()
        {
            if (mainGame.currentGameStage == GameStage.Game)
            {
                    uiLoader.CanvasSwitchOn("Win", null);
                    Time.timeScale = 0;
                    return;
            }
          
            Time.timeScale = 0;
        }

        private void Lose()
        {
            if (mainGame.currentGameStage == GameStage.Game)
            {
                uiLoader.CanvasSwitchOn("Lose", null);
                Time.timeScale = 0;
            }
        }

        public void ReloadMenu()
        { }

    }
}