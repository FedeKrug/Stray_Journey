using Game.Enemies;
using Game.Player;
namespace Game.Enemies
{
	public abstract class Obstacle : PassiveEnemy
	{
		//los obstaculos seran abstractos
		protected abstract void InteractionWithPlayer();
	}

	
}
