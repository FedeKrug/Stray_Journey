using UnityEngine;
using System.Collections.Generic;
namespace Game.Enemies
{
	public class MiniEnemyWPMover : MiniEnemy
	{
		[SerializeField] protected List<Transform> wpPoints;

		private void Update()
		{

		}

		public override void Death(EnemyHealth enemyHealth)
		{

		}

		public override void Move(Transform target)
		{

		}
		protected override void Attack()
		{
			base.Attack();
		}
		protected override void SpecialAttack()
		{
			base.SpecialAttack();
		}
		protected override void LookAtTarget(Transform target)
		{
			base.LookAtTarget(target);
		}
	}
}
