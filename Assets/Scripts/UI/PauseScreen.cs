using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private bool isGamePaused;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject backgroundAudio;
    
    void Awake()
    {
        Time.timeScale = 1f;
        
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(pauseKey) || Input.GetKeyDown(KeyCode.Escape))
		{
                isGamePaused = !isGamePaused;
                pauseScreen.SetActive(isGamePaused);
            if (isGamePaused)
			{
                Time.timeScale = 0f;
                backgroundAudio.GetComponent<AudioSource>().Pause();
            }
            else
			{
                Time.timeScale = 1f;
                ResumeGame();
            }
		}
    }
    public void ResumeGame()
	{
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        backgroundAudio.GetComponent<AudioSource>().Play();
    }
}
