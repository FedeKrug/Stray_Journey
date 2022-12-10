using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			//make damage to player
			PlayerManager.instance.playerHealth.value -= damage;
			
		}
	}
	
}
