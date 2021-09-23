using UnityEngine;
namespace BerserkAdventure
{
    public struct InfoOfCollision 
    {
		private readonly float _damage;
		private readonly Vector3 _direction;

		public InfoOfCollision(float damge, Vector3 direction)
		{
			_damage = damge;
			_direction = direction;
		}

		public float Damage
		{
			get { return _damage; }
		}

		public Vector3 Direction
		{
			get { return _direction; }
		}
	}
}