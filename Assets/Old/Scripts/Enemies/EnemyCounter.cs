using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    //enemy counter y enemy spawner
                        public int enemyCant;
    [SerializeField]    private GameObject vortex;
    void Awake()
    {
       
    }

   
    void Update()
    {
        if (enemyCant<=0)
		{
            vortex.SetActive(true);
           
		}
    }
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
            Debug.Log("Enemy dead");

            enemyCant--;

		}

	}
    
}
