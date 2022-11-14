using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCollector : MonoBehaviour
{
    [SerializeField] private float magnetSpeed;
    Vector3 targetPos;
    void Awake()
    {
        
    }

   
    void Update()
    {
        
    }
   
	private void OnTriggerStay2D(Collider2D collision)
	{
        Coins collectedCoins = collision.GetComponent<Coins>();
        if (collectedCoins !=null)
        {
            targetPos = Vector2.MoveTowards(collectedCoins.transform.position, this.transform.position, magnetSpeed * Time.deltaTime);
            targetPos.z = this.transform.position.z;
            collectedCoins.transform.position = this.transform.position;
            
		}
	}
}
