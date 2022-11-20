using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialPanel : MonoBehaviour
{
    public GameObject tutorialPanel;
    void Awake()
    {
        
    }

   
    void Update()
    {
        
    }
	private void OnTriggerExit2D(Collider2D collision)
	{
        tutorialPanel.SetActive(false);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("Tutorial Panel, use Space to Active");
		if (Input.GetKeyDown(KeyCode.Space))
		{
            tutorialPanel.SetActive(true);
		}
	}
}
