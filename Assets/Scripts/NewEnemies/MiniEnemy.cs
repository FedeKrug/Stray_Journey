using UnityEngine;
using System.Collections.Generic;
using Game.Player;

namespace Game.Enemies
{
	public class MiniEnemy : ActiveEnemy, IAttacks
	{
		[SerializeField, Range(0, 5)] protected float remainingTime;
		protected float timeRate;
		[SerializeField] protected List<GameObject> bulletGens;
		[SerializeField] protected GameObject bullet;
		
		private void Update()
		{
			timeRate -= Time.deltaTime;
			if (timeRate <= 0)
			{
				timeRate = remainingTime;
				Attack();
			}
		}



		public override void Move()
		{
			//moverse
			//persigue al player constantemente.
		}

		public void Attack()
		{
			EventManager.instance.enemyShootingEvent.Invoke(bulletGens, bullet); //esto funcionaria para las turret
																				 //Attack - disparos cuando esta el player esta en zona.
		}

		public void SpecialAttack()
		{
			//Special Attack - un ataque kamikaze.
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				PlayerManager.instance.TakeDamage(idleDamage);
			}
		}

		public override void Death(EnemyHealth enemyHealth)
		{
			
		}
	}
}
