using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField, Range(0,5f)] float coolDown;
    [SerializeField] private List<GameObject> bulletGen;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject playerRef;
    void Awake()
    {
        
    }
	private void OnEnable()
	{
        StartCoroutine(MultiShoot());
	}
    
    IEnumerator MultiShoot()
	{
        for (int i = 0; i < bulletGen.Count; i++)
        {
           
            Instantiate(bullet, bulletGen[i].transform.position, bulletGen[i].transform.rotation);
            yield return new WaitForSeconds(coolDown);
            Debug.Log("Shoot");

        }
        StartCoroutine(MultiShoot());
    }
}
