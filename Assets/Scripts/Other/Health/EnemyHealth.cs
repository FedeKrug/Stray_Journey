using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enemies;
public class EnemyHealth : MonoBehaviour,IHealth
{
	[SerializeField] private float _health;
	[SerializeField] private Enemy _enemyRef;
	public void CheckDeath()
	{
		if (_health <=0)
		{
			//Death
			_enemyRef.Death(this);
		}
	}

	public void IncreaseHealth(float healthBooster)
	{
		_health += healthBooster;
	}

	public void TakeDamage(float damage)
	{
		_health-= damage;
		
	}
	
	
}
