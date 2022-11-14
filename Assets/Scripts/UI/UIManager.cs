using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
   
    public List<Image> specialAttacks;
    private GameManager gameManager;
    [SerializeField] private TMP_Text scoreText;
    public ScoreTracker scoreTrackerText;
    public EnemyCounter enemyCounterRef;
    [SerializeField] private TMP_Text enemyCantRef;
    public static UIManager instance;
    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        //scoreTrackerText = GetComponent<ScoreTracker>();
    }

   
    void Update()
    {
        
        if (scoreTrackerText != null )
		{
            scoreText.text = "x" + scoreTrackerText.score;
		}
        if (enemyCantRef != null && enemyCounterRef!=null)
		{
            enemyCantRef.text = "x" + enemyCounterRef.enemyCant;

		}
        
	}
    
    
}
