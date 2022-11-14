using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score = 0;
    public List<string> superPowers;
    public static ScoreTracker instance;
    public Player playerRef;
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

    }
    public void IncreaseScore(int amount)
	{
        score += amount;
        Debug.Log("Your score is "  + score);
    }
    public int UseSpecialAttack()
	{
        int listPos = Random.Range(0, superPowers.Count);
        string power= superPowers[listPos];
        
        Debug.Log(power);
        return listPos;
	}
    public void IncreaseHealth(float healthPoints)
	{
        playerRef.health += healthPoints;
        if (playerRef.health>playerRef.maxHealth)
		{
            playerRef.health = playerRef.maxHealth;
		}
	}
    public  IEnumerator SpecialAttack()
	{
        //int listPos = Random.Range(0, superPowers.Count);
        //string power = superPowers[listPos];

        //Debug.Log(power);
        UseSpecialAttack();
      
        yield break;
    }
}
