using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private List<GameObject> _bulletGens;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float  _maxTimeRate;
    private float _timeRate;
    void Awake()
    {
    }

   
    void Update()
    {
        _timeRate -= Time.deltaTime;
        if (Input.GetKey(KeyCode.C))
		{

        if (_timeRate <=0)
		{
            _timeRate = _maxTimeRate;
                EventManager.instance.normalShootingEvent.Invoke(_bulletGens, _bullet);
            }
		}
        if (Input.GetKeyDown(KeyCode.C))
		{
            EventManager.instance.normalShootingEvent.Invoke(_bulletGens,_bullet);
        }
        
    }
}
