using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure {
    public class PickUpObject : MonoBehaviour, IPickUpObject
    {
        [SerializeField] Image icon;
        public void DropObject()
        {
            Debug.Log("DropObject ");
        }

        public void PickUp()
        {
            Debug.Log("PickUp ");
        }

        public void UseObject()
        {
            Debug.Log("UseObject ");
        }
    }
}