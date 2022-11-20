using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActiveSuper : MonoBehaviour
{
    [SerializeField] private GameObject specialBulletGen;
    public Player playerRef;
    public List<GameObject> timerRef;
    public ScoreTracker powerNames;
    public List<GameObject> specialSign;
    public GameObject commonBulletsSign;
    private bool isActive;
    [SerializeField] private KeyCode activeSuper;
    [SerializeField] private KeyCode specialShoot;
    
    void Awake()
    {
        
    }

   
    void LateUpdate()
    {
      
       
        if (timerRef != null && playerRef != null && powerNames!=null)
		{
            if (playerRef.super==true)
            {
                StartCoroutine(PowerSelected(powerNames.UseSpecialAttack()));
			}

           
		}
    }
	

	public IEnumerator ActivePower()
	{
        if (Input.GetKeyDown(activeSuper) && !isActive)
        {
            for (int i = 0; i < specialSign.Count; i++)
            {
                specialSign[i].SetActive(false);
			}

			switch (powerNames.UseSpecialAttack())
            {
                case 0:
                    timerRef[0].SetActive(true);
                    timerRef[1].SetActive(false);
                    timerRef[2].SetActive(false);
                    break;
                case 1:
                    timerRef[1].SetActive(true);
                    timerRef[0].SetActive(false);
                    timerRef[2].SetActive(false);
                    break;
                case 2:
                    timerRef[2].SetActive(true);
                    timerRef[0].SetActive(false);
                    timerRef[2].SetActive(false);
                    break;
			}
			//timerRef[].SetActive(true);
            specialBulletGen.SetActive(true);
            Debug.Log(powerNames.UseSpecialAttack());
            isActive = true;
        }
            float timeCompleted = timerRef[powerNames.UseSpecialAttack()].GetComponent<Timer>().maxTime;
            yield return new WaitUntil(() => playerRef.super);
            isActive = false;
            yield return null;
           
            SelectPower(powerNames.UseSpecialAttack());
       
	}
    public void SelectPower(int listPos) {
            switch (listPos)
            {
                case 0:
                    specialSign[0].SetActive(true);
                    //ActiveTimer(0);
                    StartCoroutine("ActivePower");
                    //StartCoroutine(ActivePower());
                    break; //RAY
                case 1:
                    specialSign[1].SetActive(true);
                    // ActiveTimer(1);
                    StartCoroutine("ActivePower");
                    //StartCoroutine(ActivePower());
                    break; //EXPLOSION
                case 2:
                    specialSign[2].SetActive(true);
                    // ActiveTimer(2);
                    StartCoroutine("ActivePower");
                    //StartCoroutine(ActivePower());
                    break; //DISPERSION
                default:

                    break;
            }

    }
    IEnumerator PowerSelected(int listPos)
		    {
        switch (listPos)
        {
            case 0:
                specialSign[0].SetActive(true);
                yield return null;
                StartCoroutine("ActivePower");
                break; 
            case 1:
                specialSign[1].SetActive(true);
                yield return null;
                StartCoroutine("ActivePower");
                break; //EXPLOSION
            case 2:
                specialSign[2].SetActive(true);
                yield return null;
                StartCoroutine("ActivePower");
                break; //DISPERSION
            default:

                break;
        }
    } 
}
