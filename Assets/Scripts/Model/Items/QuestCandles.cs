using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    public class QuestCandles : MonoBehaviour, IInteractibleObject
    {
        string massage = "Задуть";
        [SerializeField] GameObject openedObject;
        UiActionMassageText uiActionMassageText;
        bool isActive = true;

        public void ActivationObject()
        {
            if (isActive)
            {
                Transform[] candles = GetComponentsInChildren<Transform>();
                foreach (var item in candles)
                {
                    if (item.GetComponentInChildren<ParticleSystem>())
                    {
                        item.GetComponentInChildren<ParticleSystem>().Stop();
                    }
                }
                isActive = false;
                massage = "Зажечь";
            }
            else
            {
                Transform[] candles = GetComponentsInChildren<Transform>();
                foreach (var item in candles)
                {
                    if (item.GetComponentInChildren<ParticleSystem>())
                    {
                        item.GetComponentInChildren<ParticleSystem>().Play();
                    }
                }
                isActive = true;
                massage = "Задуть";
            }

            //if (openedObject.GetComponent<IInteractibleObject>() == null) return;
            if (!openedObject)
            {
                openedObject = FindObjectOfType<EnemySphere>().gameObject;
            }

            openedObject.GetComponent<IInteractibleObject>().ActivationObject();
        }

        public string ObjectMassage()
        {
            if (!uiActionMassageText)
            {
                uiActionMassageText = FindObjectOfType<UiActionMassageText>();
            }
            uiActionMassageText.Text = massage;
            //Debug.Log(massage);
            return massage;
        }
    }
}