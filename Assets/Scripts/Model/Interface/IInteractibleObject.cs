using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    public interface IInteractibleObject
    {
        string ObjectMassage();
        void ActivationObject();
    }
}