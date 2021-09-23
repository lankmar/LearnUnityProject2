using System.Collections.Generic;
using UnityEngine;
namespace BerserkAdventure
{
    public class Berserk : MonoBehaviour, ISetHp
    {
		[SerializeField] private float _hp = 10;
		[SerializeField] private float _stamina = 10;
		private bool _isDeath = false;
		public List<PickUpObject> inventory = new List<PickUpObject>();
		public int hpPotionCount = 2;
		public int staminaPotionCount = 2;
		
		public const int INVENTORYSIZE = 4;


        Animator _animator;

		public void SetBelt()
		{
			
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
				//Hp -= info.Damage;
				Hp -= Random.Range(10, 20);
			}

			if (Hp <= 0)
			{
				_isDeath = true;
                Main.gameState = GameStage.Lose;
                Main.CheckStage();
                //_animator.Play("Death");
            }
			//Debug.Log("_hp  - " + Hp);
		}

        internal void SetHp(int v)
        {
			Hp += v;
			if (Hp > 100) Hp = 100;

			if (Hp <= 0)
			{
				Hp = 1;
			}
		}

        public void IncreaseParameter(int potionPower, PotionType potionType)
        {
			if (potionType == PotionType.HpPotion && hpPotionCount > 0)
			{
				_hp += potionPower;
				hpPotionCount--; 
				if (_hp > 100) _hp = 100;
				ChangeHPInfo();
			}
			if (potionType == PotionType.StaminaPotion && staminaPotionCount > 0)
			{
				_stamina += potionPower;
				staminaPotionCount--;
				if (_stamina > 100) _stamina = 100;
				ChangeStaminaInfo();
			}

		}

        private void ChangeStaminaInfo()
        {
			FindObjectOfType<UiStaminaCountInfo>().Text = Main.mainGame.charBerserk.staminaPotionCount.ToString();
		}

        private void ChangeHPInfo()
        {
			FindObjectOfType<UiHpCountInfo>().Text = Main.mainGame.charBerserk.hpPotionCount.ToString();
		}

        internal void RenewInventory(PickUpObject pickUpObject)
        {
			Debug.Log("RenewInventory");
        }
    }
}