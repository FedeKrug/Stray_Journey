﻿using UnityEngine;
using System.Collections.Generic;
using Game.Player;

namespace Game.Enemies
{
	public class MiniEnemy : ActiveEnemy
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
			if (playerDetected)
			{
				Move(playerRef);

			}
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
			LookAtTarget(target);
			transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
		}

		protected virtual void LookAtTarget(Transform target)
		{
			this.transform.up = transform.position - target.position;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Player"))
			{
				StaticDamage();
				
			}
		}
		
		public override void Death(EnemyHealth enemyHealth)
		{
			Debug.Log("Mini Enemy Dead");
		}

		

		protected override void Attack()
		{
			EventManager.instance.enemyShootingEvent.Invoke(bulletGens, bullet); //esto funcionaria para las turret
			//determinar una zona de ataque
			//Attack - disparos cuando esta el player esta en zona.
		}

		protected override void SpecialAttack()
		{
			//Special Attack - un ataque kamikaze.
		}
	}
}
