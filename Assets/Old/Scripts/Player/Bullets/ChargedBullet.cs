using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedBullet : MonoBehaviour
{
    [SerializeField] private KeyCode chargedShoot;
    [SerializeField] private GameObject chargedBullet;

    void Awake()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyUp(chargedShoot))
		{
            Instantiate(chargedBullet, transform.position, transform.rotation);
		}
    }
}
