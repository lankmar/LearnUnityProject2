using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class Potion : MonoBehaviour
    {
        [SerializeField] Image passiveImage;
        [SerializeField] Image activeImage;
        //[SerializeField] Text ButtonInfo;
       // [SerializeField] Text countInfo;

       // int potionPower;


    }

    public enum PotionType
    { 
        HpPotion,
        StaminaPotion
    }
}