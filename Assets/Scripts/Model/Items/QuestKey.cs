using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    [RequireComponent(typeof(AudioSource))]
    public class QuestKey : MonoBehaviour, IInteractibleObject
    {
        [SerializeField] AudioSource audio;
        [SerializeField] AudioClip clip;

        [SerializeField] string massage = "Нажать";

        [ SerializeField] GameObject openedObject;
        UiActionMassageText uiActionMassageText;

        public void ActivationObject()
        {
            if (!openedObject) return;
            if (openedObject.GetComponent<IInteractibleObject>() == null) return;
            if (audio) audio.PlayOneShot(clip);
            openedObject.GetComponent<IInteractibleObject>().ActivationObject();
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
