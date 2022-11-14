using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSound : MonoBehaviour
{
    
    private AudioSource aSource;
    public AudioClip clip;
    void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (this.tag =="HealthObject" || this.tag=="SuperObject"|| this.tag =="Coin")
		{
            Player playerRef = collision.GetComponent<Player>();
            if (playerRef!=null)
		    {
                TurnSoundOn();
		    }

		}
       
    }
    public void TurnSoundOn()
	{
        this.aSource.enabled = true;
    }
}
