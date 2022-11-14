using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;
    public AudioSource backgroundAudio;
    
    void Awake()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player playerRef = collision.GetComponent<Player>();
        if (playerRef != null)
        {
			winScreen.SetActive(true);
			backgroundAudio.Stop();

		}
    }
}
