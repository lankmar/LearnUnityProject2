using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
	[RequireComponent (typeof(AudioSource))]
	public class Bow : BaseWeapon
	{
		[SerializeField] AudioSource audio;
		public AudioClip clip;
		private void Start()
		{
			Ammunition = UnityEngine.Resources.Load<Arrow>("Arrow");
			audio.GetComponent<AudioSource>();

		}
		public override void Fire()
		{
			Invoke("ArrowInst", 0.9f);
		}

		private void ArrowInst()
		{
			if (!_isReady) return;
			if (Ammunition)
			{
				audio.PlayOneShot(clip);
				var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);// Pool object
				temAmmunition.AddForce(_barrel.forward * _force);

				_isReady = false;
				Invoke(nameof(ReadyShoot), _rechergeTime);
			}
		}
	}
}