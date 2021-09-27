using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace BerserkAdventure
{
    public class Enemy : BaseObjectScene, ISetHp
    {
		private NavMeshAgent _agent;
		[SerializeField] private Transform _target;
		private bool _isTarget;
		[SerializeField]private float _hp = 100;
		private bool _isDeath;

		private Patrol _patrol;
		[SerializeField] List<Transform> patrolPoints;
		Vector3 currentPoint;
		private float _curTime;
		private const float TIMEWAIT = 5;

		[SerializeField] private Vision _vision;

		[SerializeField] private BaseWeapon _weapon;
		Animator _enemyAnimator;


		private void Start()
		{
			
			_agent = GetComponent<NavMeshAgent>();
			_patrol = new Patrol();
			if (!_target) _target = GameObject.FindGameObjectWithTag("Player").transform;
			_enemyAnimator = GetComponentInChildren<Animator>();
		}

		private void Update()
		{
			if (_isDeath) return;

			if (_isTarget)
			{
				_agent.SetDestination(_target.position);
				_agent.stoppingDistance = 3;
				if (_vision.VisionMath(Transform, _target))
				{
					transform.LookAt(_target);
					if (_weapon != null)
					{   _weapon.Fire();
						_enemyAnimator.Play("Attack1");
						_agent.isStopped = true;
					}
				}
				else
				{
					_isTarget = false;
					_patrol.GenericPoint(_agent, SetPoint(),true );
					_enemyAnimator.Play("Walk");
				}
			}
			else
			{
				if (!_agent.hasPath)
				{
					_curTime += Time.deltaTime;
					if (!_enemyAnimator) _enemyAnimator = GetComponentInChildren<Animator>();
					if (_enemyAnimator) _enemyAnimator.Play("idle1");
					if (_curTime >= TIMEWAIT)
					{
						_curTime = 0;
						_patrol.GenericPoint(_agent, SetPoint(),true );
						_enemyAnimator.Play("Walk");
					}
				}

				if (_vision.VisionMath(Transform, _target))
				{
					_isTarget = true;
				}
			}
		}

		public float Hp
		{
			get { return _hp; }
			private set { _hp = value; }
		}

		public void SetHp(InfoOfCollision info)
		{
			if (Hp > 0)
			{
				Hp -= Random.Range(60,70);
				//Hp -= info.Damage;
			}

			if (Hp <= 0)
			{
				_isDeath = true;
				_agent.enabled = false;
				_enemyAnimator.Play("Death1");
				Main.enemyCount--;
				gameObject.GetComponent<Collider>().enabled = false;
				Debug.Log(Main.enemyCount);
				if (Main.enemyCount == 0)
				{
					Invoke("WinGame", 2.5f);

				}
			}

		}

		private void WinGame()
		{
			Main.gameState = GameStage.Win;
			Main.CheckStage();
		}

		private Vector3 SetPoint()
		{
			Vector3 tempVector = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
			if (currentPoint == tempVector)
			{
				SetPoint();
			}
			else currentPoint = tempVector;
			return currentPoint;
		}
	}
}