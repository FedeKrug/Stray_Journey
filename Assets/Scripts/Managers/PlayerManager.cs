using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager instance;
	
    void Awake()
    {	
        EventManager.instance.normalShootingEvent.AddListener(Shooting);
    }

	private void OnEnable()
	{
		EventManager.instance.normalShootingEvent.AddListener(Shooting);
	}
	private void OnDisable()
	{
		EventManager.instance.normalShootingEvent.RemoveListener(Shooting);
	}

	public void Shooting(List<GameObject> bulletGenerators,GameObject bullet)
	{
		for (int i =0; i< bulletGenerators.Count; i ++)
		{
			if (bullet)
			{
			GameObject _bullet = Instantiate(bullet, bulletGenerators[i].transform.position, bulletGenerators[i].transform.rotation);

			}
			Debug.Log("Disparo");
		}
	}
}
