using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    public SceneLoader sceneLoaderRef;
    
   
    void Awake()
    {
       
        
    }

   
    void Update()
    {
             
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        Player playerRef = collision.GetComponent<Player>();
        
	}
}
