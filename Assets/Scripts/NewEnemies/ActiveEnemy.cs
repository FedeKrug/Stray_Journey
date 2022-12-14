using UnityEngine;

namespace Game.Enemies
{

	public abstract class ActiveEnemy:Enemy
	{
		//un enemigo que quiere ir a buscar al player y atacarlo de frente
		[SerializeField] protected float movementSpeed;
		[SerializeField] protected Transform playerRef;
		public abstract void Move(Transform target);
		public bool inAttackRange;
	}

	
}
