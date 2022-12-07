using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionAudio;
    [SerializeField] private AudioSource _explosionASource;
    [SerializeField] private Animator _anim;
    
   
   
    IEnumerator DestroyBullets()
    {
        _anim.Play(""); //explosion
        _explosionASource.PlayOneShot(_explosionAudio);
        yield return new WaitForSeconds(0.1f);
        //Destroy(gameObject);
        Debug.Log("BulletDestroyed");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Destroyer")
        {
            StartCoroutine(DestroyBullets());
        }
    }
}
