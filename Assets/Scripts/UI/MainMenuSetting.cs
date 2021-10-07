using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    [RequireComponent(typeof(Image), typeof(RectTransform))]
    public class MainMenuSetting : MonoBehaviour
    {
        Image backgraund;
        Button [] button;
        void Start()
        {
            backgraund = GetComponent<Image>();
            // backgraund.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Backgraund") as Sprite;

            button = GetComponentsInChildren<Button>();
            int counter = 0;
            foreach (var item in button)
            {
                item.transform.localScale = new Vector3(3,5,2);
                item.transform.localPosition += new Vector3(500, - counter * 100,0);
                counter++;
            }
        }
    }
}