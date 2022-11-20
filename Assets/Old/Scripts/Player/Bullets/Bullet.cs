using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0,250f)] private float speed;
                                    public float damage;
    [SerializeField, 
    Tooltip("Change damage " +
    "with a boost later"), Range(0,250f)] private float damageModifier;
    [Header("Destroying Bullets: ")]
    [SerializeField, Range(0, 30f)] private float timeToDestroy;



    Rigidbody2D rb2d;
    Animator anim;
    AudioSource aSource;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
    }

	private void Update()
	{
        Destroy(gameObject, timeToDestroy);
	}

	private void FixedUpdate()
	{
        rb2d.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);  
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag =="Enemy" || collision.tag == "Destroyer")
		{
            Destroy(this.gameObject);
		}
	}
}
