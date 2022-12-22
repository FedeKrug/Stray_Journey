using UnityEngine;

namespace Game.Enemies
{
	public abstract class PassiveEnemy : Enemy
	{
		//un enemigo que no necesita ni quiere ir a buscar al player para atacarlo, pero puede conocerlo y verlo
		//son mas conocidos como enemigos a larga distancia
		[SerializeField] protected float speed;
		[SerializeField, Range(0, 5)] protected float remainingTime;
		protected float timeRate;
	}
}
