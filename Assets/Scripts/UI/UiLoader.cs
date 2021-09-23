using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class UiLoader  : MonoBehaviour
    {
        float screenHeight;
        float screenWidth;
        float screenRatio; // соотношение экрана
        Text text;

        public float ScreenHeight { get => screenHeight; private set => screenHeight = value; }
        public float ScreenWidth { get => screenWidth; private set => screenWidth = value; }
        public float ScreenRatio { get => screenRatio; private set => screenRatio = value; }
        public List<Canvas> uiLoaderArr = new List<Canvas>(); //TODO выдает  ошибку
        public Canvas[] canvases; //TODO выдает  ошибку
        Canvas canvasMainMenu;
        Canvas game;
        Canvas win;
        Canvas settings;
        Canvas lose;
        Canvas pause;
        Canvas quest;
        Image title;
        Image background;
        //Button[] buttons;
        Button pauseButton;

        public void UiLoaderStart(ref Canvas [] can, Image [] images, Button [] buttons )
        {
            ScreenHeight = Screen.height;
            ScreenWidth = Screen.width;
            ScreenRatio = ScreenHeight / ScreenWidth;
            ImageInitialization(images);
        }


        public List<Canvas> CanvasInitialization(ref Canvas[] can)
        {
            if (can == null) can = UnityEngine.GameObject.FindObjectsOfType<Canvas>();
            foreach (var item in can)
            {
                if (item.name == "MainMenu")
                {
                    canvasMainMenu = item;
                    uiLoaderArr.Add(item);
                }
                if (item.name == "GameUI")
                {
                    game = item;
                    uiLoaderArr.Add(item);
                }
                if (item.name == "Lose")
                {
                    game = item;//game over 
                    uiLoaderArr.Add(item);
                }
                if (item.name == "Pause")
                {
                    pause = item;
                    uiLoaderArr.Add(item);
                }
                if (item.name == "Win")
                {
                    win = item;
                    uiLoaderArr.Add(item);
                } 
                if (item.name == "Quest")
                {
                    quest = item;
                    uiLoaderArr.Add(item);
                }
                if (item.name == "Settings")
                {
                    settings = item;
                    uiLoaderArr.Add(item);
                }
            }
            return uiLoaderArr;
        }

        private void ImageInitialization(Image [] images)
        {
            foreach (var item in images)
            {
                if (item.name == "Title") item.GetComponent<RectTransform>().sizeDelta = new Vector2(ScreenWidth / 3f, screenHeight / 5);
                if (item.name == "Background") item.GetComponent<RectTransform>().sizeDelta = new Vector2(ScreenWidth, screenHeight);
            }
        }

        #region CanvasSwitchOn

        public void CanvasSwitchOn(string activeCanvas, string activeCanvas2)
        {
            for (int i = 0; i < Main.mainGame.canvasGroup.Count; i++)
            {
                if (Main.mainGame.canvasGroup[i].name == activeCanvas || Main.mainGame.canvasGroup[i].name == activeCanvas2)
                {
                    Main.mainGame.canvasGroup[i].enabled = true;
                    Main.mainGame.canvasGroup[i].transform.gameObject.SetActive(true);
                }
                else
                {
                    Main.mainGame.canvasGroup[i].gameObject.SetActive(false);
                }
            }
            //CheckMenuSettings(activeCanvas, activeCanvas2);
        }

        private void CheckMenuSettings(string activeCanvas, string activeCanvas2)
        {
            if (activeCanvas == "Settings")
            {
                var activeCan = GameObject.FindObjectOfType<SettingsMenu>();
                activeCan.GetComponent<SettingsMenu>().SetElementValue();
            }
        }
        #endregion
    }
}