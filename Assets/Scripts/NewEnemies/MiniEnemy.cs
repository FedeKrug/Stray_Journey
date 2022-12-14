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
			if (inAttackRange)
			{
				ConstantAttack();

			}
			//else
			//{
			//}
			Move(playerRef);
		}

		private void ConstantAttack()
		{
			if (timeRate <= 0)
			{
				timeRate = remainingTime;
				Attack();
			}
		}


		public override void Move(Transform target)
		{
			//Vector3 newTarget = new Vector3(0,0, target.rotation.z - this.transform.transform.rotation.z);
			//transform.LookAt(newTarget);
			//transform.Rotate(target.rotation.z, this.transform.rotation.y, this.transform.rotation.x);
			//buscar como mover al enemigo para ver al player usando vectores
			//moverse
			//persigue al player constantemente.
			//Debug.Log("Mini Enemy Moving...");
		}

		public void Attack()
		{
			EventManager.instance.enemyShootingEvent.Invoke(bulletGens, bullet); //esto funcionaria para las turret
		     //determinar una zona de ataque									 //Attack - disparos cuando esta el player esta en zona.
		}

		public void SpecialAttack()
		{
			//Special Attack - un ataque kamikaze.
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				StaticDamage();
			}
		}
		[ContextMenu("Death")]
		public override void Death(EnemyHealth enemyHealth)
		{
			Debug.Log("Mini Enemy Dead");
		}
	}
}
