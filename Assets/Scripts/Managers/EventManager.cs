using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager: MonoBehaviour
{
	#region Singleton and Awake
	public static EventManager instance;
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
	public Shoot normalShootingEvent = new Shoot();
	
}

public class Shoot: UnityEvent <List<GameObject>, GameObject>{ }
