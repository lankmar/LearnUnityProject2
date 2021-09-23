using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    public class Arrow : BaseAmmunition
    {
		[SerializeField] private BulletProjector _bulletProjector;
		private int _count = 1;
		private int _currentDamage;

		private void OnCollisionEnter(UnityEngine.Collision collision)
		{
			SetDamage(collision.gameObject.GetComponent<ISetHp>());
			if (_count <= 0)
			{
				Destroy(InstanceObject);
				var contact = collision.contacts[0];
				CreateDecal(contact, collision.transform);
			}
			--_count;
		}


        private void SetDamage(ISetHp obj)
		{
			//_curDamage = Random.Range(10,20);
			if (obj != null) obj.SetHp(new InfoOfCollision(_currentDamage, transform.forward));
		}

		private void CreateDecal(ContactPoint contact, Transform objCollision)
		{
			var projectorRotation = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
			if (_bulletProjector != null)
			{
				var obj = Instantiate(_bulletProjector, contact.point + contact.normal * 0.25f, projectorRotation, objCollision);
				obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, Random.Range(0, 360));
			}
		}
	}
}