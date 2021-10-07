using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    public class StaminaPotion : MonoBehaviour, IInteractibleObject
    {
        PotionType type = PotionType.HpPotion;
        int potionPower = 70;

        string massage = "Взять";
        [SerializeField] UiStaminaCountInfo countInfo;
        UiActionMassageText uiActionMassageText;


        public void PotionActivation()
        {
            Main.mainGame.charBerserk.IncreaseParameter(potionPower, type);
        }


        public void ActivationObject()
        {

                Main.mainGame.charBerserk.staminaPotionCount++;
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                if (!countInfo)
                {
                    countInfo = FindObjectOfType<UiStaminaCountInfo>();
                }
                if (countInfo)
                {
                    countInfo.Text = Main.mainGame.charBerserk.staminaPotionCount.ToString();
                }

        }

        public string ObjectMassage()
        {
            if (!uiActionMassageText)
            {
                uiActionMassageText = FindObjectOfType<UiActionMassageText>();
            }
            uiActionMassageText.Text = massage;
            return massage;
        }
    }
}