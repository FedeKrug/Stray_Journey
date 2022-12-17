using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enemies;

public class EnemyManager : MonoBehaviour, IHealth
{
	[SerializeField] private FloatSO _enemyHealth;
	
	#region Singleton
	public static EnemyManager instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	#endregion

	private void OnEnable()
	{
		EventManager.instance.enemyShootingEvent.AddListener(HandleEnemyShooting);	
	}

	private void OnDisable()
	{
		EventManager.instance.enemyShootingEvent.RemoveListener(HandleEnemyShooting);	
		
	}


	public void HandleEnemyShooting(List<GameObject> bulletGenerators, GameObject bullet)
	{
		for (int i = 0; i < bulletGenerators.Count; i++)
		{
			if (bullet)
			{
				GameObject _bullet = Instantiate(bullet,bulletGenerators[i].transform.position, bulletGenerators[i].transform.rotation);
				Debug.Log("Disparo Enemigo");
				
			}
		}
	}

	public void TakeDamage(float damage)
	{
		_enemyHealth.value -= damage;
	}

	public void IncreaseHealth(float healthBooster)
	{
		_enemyHealth.value += healthBooster;
	}

	public void CheckDeath()
	{
		if (_enemyHealth.value <=0)
		{
			//evento de muerte
		}
	}
}
