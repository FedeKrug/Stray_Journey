using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionAudio;
    [SerializeField] private AudioSource _explosionASource;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _bulletToDestroy;
    [SerializeField, Range(0.5f, 5)] private float _explosionTime;
    [SerializeField] private Bullet _bulletRef;
   
    IEnumerator DestroyBullets()
    {
        _bulletRef.speed = 0;
        yield return null;
        _anim.SetTrigger("Explode"); //explosion
        _explosionASource.PlayOneShot(_explosionAudio);
        yield return new WaitForSeconds(_explosionTime);
        gameObject.SetActive(false);
        Debug.Log("BulletDestroyed");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Destroyer")
        {
            //Destroy(_bulletToDestroy);
            _bulletToDestroy.SetActive(false);
            StartCoroutine(DestroyBullets());
        }
    }
}
