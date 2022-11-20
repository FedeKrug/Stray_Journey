using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> commonBullets;
    [SerializeField] private List<GameObject> specialBullets;
    [HideInInspector] public bool super = false;


    public static BulletGenerator instance;
    void Awake()
    {
        if (instance == null)
		{
            instance = this;
		}
  //      else
		//{
  //          Destroy(gameObject);
		//}
    }

   
    void Update()
    {
       
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag =="superObject")
		{
            super = true;
		}
	}
    public void SpecialShooting(int listCount)
	{
        Instantiate(specialBullets[listCount], transform.position, transform.rotation);
        super = false;
	}
    public void Shoot(int listCount)
	{
        Instantiate(commonBullets[listCount], gameObject.transform.position, transform.rotation);
        Debug.Log("Player Shot");
    }
}
