using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private List<GameObject> _bulletList;
    [SerializeField] private int _poolSize = 10;
    [SerializeField] private Transform _parentObject;
    public static BulletPool instance;
   
    void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		AddBulletsToList(_poolSize);
	}

	private void AddBulletsToList(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject bullet = Instantiate(_bullet);
			bullet.SetActive(false);
			_bulletList.Add(bullet);
			bullet.transform.parent = _parentObject;
		}
	}

	public GameObject RequestBullets()
	{
		for (int i =0; i<_bulletList.Count; i++)
		{
			if (!_bulletList[i].activeSelf)
			{
				_bulletList[i].SetActive(true);
				return _bulletList[i];
			}
			
		}
		AddBulletsToList(1);
		GameObject newBullet = _bulletList[_bulletList.Count - 1];
		newBullet.SetActive(true);
		return newBullet;

	}
}
