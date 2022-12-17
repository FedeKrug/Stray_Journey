using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

namespace Game.Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		
		[SerializeField, Range(0, 10)] protected float idleDamage;
		[SerializeField, Range(0, 10)] protected float timeToSpecial;
		protected float idleTime;
		[SerializeField] protected EnemyHealth enemyLife;
		[SerializeField] protected EnemyRangeDetector rangeOfView;
		protected bool inSpecial, specialReady;


		private void Awake()
		{
			idleTime = timeToSpecial;
		}
		public bool inAttackRange, playerDetected;

		public abstract void Death(EnemyHealth enemyHealth);
		protected abstract void Attack();
		protected abstract void SpecialAttack();
		
		protected void StaticDamage()
		{
			PlayerManager.instance.TakeDamage(idleDamage);
		}

		public virtual IEnumerator ChargingSpecial()
		{
			yield return new WaitForSeconds(timeToSpecial);
			specialReady = true;
			yield return null;
			SpecialAttack();
		}

		//private void OnTriggerStay2D(Collider2D collision)
		//{
		//	if (collision.CompareTag("Player"))
		//	{
		//		StartCoroutine(ChargeSpecial());
		//	}
		//}
		//private void OnTriggerExit2D(Collider2D collision)
		//{
		//	if (collision.CompareTag("Player"))
		//	{
		//		StopCoroutine(ChargeSpecial());
		//		timeToSpecial = idleTime;
		//		Debug.Log($"timeToSpecial :{timeToSpecial}, idleTime: {idleTime}");
		//	}
		//}

	}


	#region Interfaces
	public interface IDamagable
	{
		public void TakeDamage();
		public void Death();
	}

	public interface IAttacks
	{
		public abstract void Attack();
		public abstract void SpecialAttack();
	}
	#endregion
}
