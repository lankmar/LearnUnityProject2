using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    public interface ISetHp 
    {
        void SetHp(InfoOfCollision info);
        float Hp { get; }
    }
}
