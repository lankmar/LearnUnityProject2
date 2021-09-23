using UnityEngine;
using UnityEngine.UI;

namespace BerserkAdventure {
[RequireComponent (typeof(Renderer), typeof (SphereCollider))]
    public class EnemySphere : PickUpObject, IInteractibleObject
    {
        string massage = "Забрать";
        [SerializeField] GameObject openedObject;
        UiActionMassageText uiActionMassageText;
        bool isVision = false;

        public void ActivationObject()
        {
            if (isVision)
            {
                if (Main.mainGame.charBerserk.inventory.Count <= Berserk.INVENTORYSIZE)
                {
                    Main.mainGame.charBerserk.inventory.Add(this);
                    Main.mainGame.charBerserk.RenewInventory(this);
                    GetComponent<Renderer>().enabled = false;
                    GetComponent<SphereCollider>().enabled = false;
                }
                Debug.Log("ActivationObject Enemy");
            }
            GetComponent<Renderer>().enabled = true;
            GetComponent<SphereCollider>().enabled = true;
            isVision = true;

            if (!openedObject) return;
            if (openedObject.GetComponent<IInteractibleObject>() == null) return;

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
