using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    [RequireComponent(typeof(Text))]
    public class QuestTextSettings : MonoBehaviour
    {
        Text text;
        Vector2 screenSize;

        void Start()
        {
            text = GetComponent<Text>();
            screenSize = new Vector2(Screen.height, Screen.width);
            SetSizeDelta();

            // SetSpasing();
        }

         private void SetSizeDelta()
         {
            text.fontSize = (int)(screenSize.y / 75);
            text.fontStyle = FontStyle.Bold;
         }
    }
}
