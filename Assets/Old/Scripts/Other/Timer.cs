using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image SpecialPowerUI;
    public  float maxTime;
    [HideInInspector]              public float timeRemaining;
    [SerializeField] private GameObject specialBulletGen;
    public GameObject playerRef;
    
	void Awake()
	{

	}

	private void OnEnable()
	{
        timeRemaining = maxTime;
        specialBulletGen.SetActive(true);
    }
	private void OnDisable()
	{
        specialBulletGen.SetActive(false);
    }
	void Update()
    {
        if (timeRemaining>0)
		{
            timeRemaining -= Time.deltaTime;
            SpecialPowerUI.fillAmount = timeRemaining / maxTime;
		}
        if (timeRemaining<=0 )
		{
            this.gameObject.SetActive(false);
            playerRef.GetComponent<Player>().super = false;
		}
       
        
    }
}
