using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    public class BerserkSword : MonoBehaviour
    {
		private int _currentDamage;

		private void OnCollisionEnter(UnityEngine.Collision collision)
		{
			SetDamage(collision.gameObject.GetComponent<ISetHp>());
		}
		private void OnTriggerEnter(Collider other)
		{

			if(other.tag == "Enemy") SetDamage(other.gameObject.GetComponent<ISetHp>());
		}

		private void SetDamage(ISetHp obj)
		{
			_currentDamage = Random.Range(50, 60);
			if (obj != null) obj.SetHp(new InfoOfCollision(_currentDamage, transform.forward));
		}

	}
}