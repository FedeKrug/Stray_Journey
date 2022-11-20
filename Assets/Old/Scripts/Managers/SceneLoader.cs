using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject selectLevelScreen;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject pauseScreen;
    void Awake()
    {
        
    }

   
    void Update()
    {
        
    }
    public void ChangeScene(string sceneName)
	{
        SceneManager.LoadScene(sceneName);
        
	}
    public void QuitGame()
	{
        Application.Quit();
	}
    public void ReloadScene()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    public void ActiveScreen()
	{
        selectLevelScreen.SetActive(true);
	}
    public void ShowTutorial()
	{
        tutorialPanel.SetActive(true);
    }
    public void ResumeGame()
	{
        pauseScreen.GetComponent<PauseScreen>().ResumeGame() ;
	}
    public void PassLevel()
	{
        Scene currentScene = SceneManager.GetActiveScene();
        int currentBuildIndex = currentScene.buildIndex;
        int nextSceneBuildIndex = currentBuildIndex+1;
        SceneManager.LoadScene(nextSceneBuildIndex);
	}
}
