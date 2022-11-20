using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int points;
    public float healthPoints;
    public static Collectables instance;
	
    public void SuperCollected()
	{
        ScoreTracker.instance.UseSpecialAttack();

        Destroy(gameObject);
        
       
    }
    
    public void HealthCollect()
	{
        ScoreTracker.instance.IncreaseHealth(healthPoints);
        Destroy(gameObject);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if (collision.tag == "Collector")
		//{
  //          if (this.tag =="Coin")
		//	{
  //              CoinCollected();
		//	}
		//	//switch (this.tag)
			//{
   //             case "Coin":

   //                 break;
   //             case "SuperObject":
   //                 break;
   //             case"HealthObject":
   //                 break;
   //             default:
   //                 break;
			//}
		//}

		Player playerRef = collision.GetComponent<Player>();
        if (playerRef != null)
		{
            if (!playerRef.super)
			{
                SuperCollected();
			}
            if (playerRef.health>0 && playerRef.health<playerRef.maxHealth)
			{
                HealthCollect();
                if (playerRef.health>playerRef.maxHealth)
				{
                    playerRef.health = playerRef.maxHealth;
				}
                
			}
            
		}
	}
   
}
