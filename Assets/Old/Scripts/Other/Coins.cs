using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value;
    public ObjectsSound objSound;
    void Awake()
    {
        
    }

   
    void Update()
    {
        
    }
    public void CoinCollected()
    {
        ScoreTracker.instance.IncreaseScore(value);
        objSound.TurnSoundOn();
        Destroy(gameObject);

    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag =="Collector")
		{
            CoinCollected();
		}
	}
}
