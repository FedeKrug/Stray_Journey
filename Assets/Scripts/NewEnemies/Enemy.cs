using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Enemies
{
	public abstract class Enemy : MonoBehaviour
	{
		[SerializeField, Range(0,100)] protected float health;
		[SerializeField,Range (0,10)] protected float idleDamage;
		[SerializeField] protected EnemyHealth enemyLife;
		public abstract void Death(EnemyHealth enemyHealth);
		
	}

	#region Interfaces
	public interface IDamagable
	{
		public void TakeDamage();
		public void Death();
	}

	public interface IAttacks
	{
		public void Attack();
		public void SpecialAttack();
	}
	#endregion
}
