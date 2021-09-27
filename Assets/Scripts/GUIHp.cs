using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GUITest
{
    public class GUIHp : MonoBehaviour
    {
        [SerializeField] BerserkAdventure.Berserk berserk;
        bool flag = true;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnGUI()
        {
            GUI.Box(new Rect(Screen.width-300, 10, 200, 140), "Character selection");
            if (GUI.Button(new Rect(Screen.width - 280, 50, 180, 30), "+10HP"))
            {
                Debug.Log("+10");
                berserk.SetHp(10);
                flag = true;
            }
            if (GUI.Button(new Rect(Screen.width - 280, 100, 180, 30), "-10HP"))
            {
                berserk.SetHp(-10);
                Debug.Log("-10");
                flag = true;
            }
            if (flag)
            {
               // GUI.HorizontalScrollbar(new Rect(Screen.width - 1000, Screen.height - 100, 300, 40), berserk.Hp, 1f, 0, 100);
                GUI.HorizontalSlider(new Rect(Screen.width - 1000, Screen.height - 100, 300, 40), berserk.Hp, 0, 100);
            }


        }

        

    }
}