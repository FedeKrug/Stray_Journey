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
		protected float idleTime = 0;
		[SerializeField] protected EnemyHealth enemyLife;
		
		
		public bool inAttackRange, playerDetected;

		public abstract void Death(EnemyHealth enemyHealth);
		protected abstract void Attack();
		protected abstract void SpecialAttack();

		protected void StaticDamage()
		{
			PlayerManager.instance.TakeDamage(idleDamage);
		}

		protected IEnumerator ChargeSpecial()
		{
			yield return new WaitForSeconds(timeToSpecial);
			SpecialAttack();
		}
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
