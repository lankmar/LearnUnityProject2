using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
	public abstract class BaseWeapon : BaseObjectScene
	{
		public BaseAmmunition Ammunition;
		//public Clip Clip;
		//public int ClipSize = 5;

		//protected AmmunitionType[] _ammunitionType = new AmmunitionType[] { AmmunitionType.Bullet };

		[SerializeField] protected Transform _barrel;
		[SerializeField] protected float _force = 999;
		[SerializeField] protected float _rechergeTime = 0.9f;
		//private Queue<Clip> _clips = new Queue<Clip>();

		protected bool _isReady = true;
		protected Timer _timer = new Timer();

		public abstract void Fire();

        protected virtual void Update()
        {
            _timer.Update();
            if (_timer.IsEvent())
            {
                ReadyShoot();
            }
        }

        protected void ReadyShoot()
		{
			_isReady = true;
		}

		//protected void AddClip(Clip clip)
		//{
		//	_clips.Enqueue(clip);
		//}

		//public void ReloadClip()
		//{
		//	if (CountClip <= 0) return;
		//	Clip = _clips.Dequeue();
		//}

		//public int CountClip => _clips.Count;
	}
}