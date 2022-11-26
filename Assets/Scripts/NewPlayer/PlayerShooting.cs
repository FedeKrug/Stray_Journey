using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] private List<GameObject> _bulletGens;
	[SerializeField] private GameObject _bullet;
	[SerializeField] private float _maxTimeRate;
	[SerializeField] private ShootType _shootType;
	private float _timeRate;
	void Awake()
	{
	}


	void Update()
	{
		_timeRate -= Time.deltaTime;
		if (_shootType == ShootType.Automatic)
		{
			if (Input.GetKey(KeyCode.C))
			{
				if (_timeRate <= 0)
				{
					_timeRate = _maxTimeRate;
					EventManager.instance.normalShootingEvent.Invoke(_bulletGens, _bullet);
				}
			}
		}

		if (_shootType == ShootType.Manual)
		{

			if (Input.GetKeyDown(KeyCode.B))
			{
				_timeRate = _maxTimeRate;
				EventManager.instance.normalShootingEvent.Invoke(_bulletGens, _bullet);
			}
		}

	}
}
public enum ShootType
{
	Manual,
	Automatic
}