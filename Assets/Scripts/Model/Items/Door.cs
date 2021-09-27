using UnityEngine;

namespace BerserkAdventure
{
    [RequireComponent(typeof(Animation),typeof(AudioSource))]
    public class Door : MonoBehaviour, IInteractibleObject
    {
        [SerializeField] AudioSource audio;
        [SerializeField] AudioClip clip;
        public void ActivationObject()
        {
            GetComponent<Animation>().Play();
            if (audio) audio.PlayOneShot(clip);
        }

       public string ObjectMassage()
        {
            return string.Empty;
        }
    }
}