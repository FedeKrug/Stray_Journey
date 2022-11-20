using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField, Range(0,250f)] private float speed;
    public float enemyDamage;
    public float timeToDestroyBullet;
    Rigidbody2D rb2d;
    Animator anim;
    AudioSource aSource;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        EnemyShoot();
    }

    public void EnemyShoot()
	{
        rb2d.MovePosition(transform.position + transform.right   * speed * Time.fixedDeltaTime);
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        Player playerRef = collision.GetComponent<Player>();
        if (playerRef!= null)
		{
            playerRef.health -= enemyDamage;
		}
        Destroy(this.gameObject, timeToDestroyBullet);
	}
}
