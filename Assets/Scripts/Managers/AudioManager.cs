using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private Player playerRef;
    private AudioSource aSource;
    void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (playerRef.enabled ==false)
		{
            aSource.Pause();
		}
        else
		{
            aSource.Play();
		}
    }
}
