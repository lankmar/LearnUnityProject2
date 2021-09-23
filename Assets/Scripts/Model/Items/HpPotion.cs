using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure
{
    public class HpPotion : MonoBehaviour, IInteractibleObject
    {
        PotionType type = PotionType.HpPotion;
        int potionPower = 70;

        string massage = "Взять";
        [SerializeField] UiHpCountInfo countInfo;
        UiActionMassageText uiActionMassageText;


        public void PotionActivation()
        {
            Main.mainGame.charBerserk.IncreaseParameter(potionPower, type);
        }


        public void ActivationObject()
        {
                Main.mainGame.charBerserk.hpPotionCount++;
                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                if (!countInfo)
                {
                    countInfo = FindObjectOfType<UiHpCountInfo>();
                }
            if (countInfo)
            {
                countInfo.Text = Main.mainGame.charBerserk.hpPotionCount.ToString();
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