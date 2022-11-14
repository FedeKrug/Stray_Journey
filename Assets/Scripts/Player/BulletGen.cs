using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGen : MonoBehaviour
{
    [SerializeField] private List<GameObject> typeOfBullets;
    [SerializeField] private int bulletIndex;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot(int typeOfShoot)
	{
        Instantiate(typeOfBullets[bulletIndex], transform.position, transform.rotation);
	}
}
