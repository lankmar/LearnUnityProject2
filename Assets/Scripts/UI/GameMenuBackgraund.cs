using UnityEngine;

namespace BerserkAdventure
{
    public class GameMenuBackgraund : MonoBehaviour
    {
        [SerializeField] SpriteRenderer scoreTitle;
        [SerializeField] SpriteRenderer levelTitle;
       // [SerializeField] GameObject gameOver;

        //int currentLevel;
        //string path;

        //private void Update()
        //{
        //    //if (GameObject.FindObjectOfType<TetrisGame>())
        //    //{
        //    //    currentLevel = TetrisGame.CurrentLevel;
        //    //    Debug.Log("CurrentLevel - " + currentLevel);
        //    //    //SetLevel();
        //    //}
        //}

        private void SetTitleSprite()
        {
            if (Main.mainGame.gameSettings.LanguageSetting == Language.English)
            {
                scoreTitle.sprite = Resources.Load<Sprite>("UI/En/Score") as Sprite;
                levelTitle.sprite = Resources.Load<Sprite>("UI/En/Level") as Sprite;
            }
            if (Main.mainGame.gameSettings.LanguageSetting == Language.Russian)
            {
                scoreTitle.sprite = Resources.Load<Sprite>("UI/Ru/Score") as Sprite;
                levelTitle.sprite = Resources.Load<Sprite>("UI/Ru/Level") as Sprite;
            }
        }

        //public void SetLevel(int num)
        //{
        //    //if (currentLevel == 0)
        //    //    {
        //    //        currentLevel = 1;
        //    //    } 

        //    // Debug.Log("SetLevel() - 111 "+ currentLevel);
        //    num++;
        //    path = string.Format("Numbers/{0}", num);
        //    level.sprite = Resources.Load<Sprite>(path);
        //    level.gameObject.transform.localScale = new Vector3(3, 3, 0);
        //}


        public void SetMenu()
        {
            SetTitleSprite();
        }

        //public void SwitchGameOver(bool flag)
        //{
        //    if (flag)
        //    {
        //        gameOver.GetComponent<SpriteRenderer>().enabled = true;
        //        SetGameOverSprite();
        //    }
        //    if (!flag)
        //    {
        //        gameOver.GetComponent<SpriteRenderer>().enabled = false;
        //        gameOver.transform.GetComponentInChildren<ScoreUi>().SetScore();
        //    }

        //    //SetGameOverScore();
        //}

        //private void SetGameOverSprite()
        //{ 
            
        //}

        //public void SetGameOverScore()
        //{

        //}

    }
}
