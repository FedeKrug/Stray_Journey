using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField, Range(0,25000)] private float speed;
    [SerializeField, Range(0,500)] private float damage;
    [SerializeField] private float timeToDestroy;

    Rigidbody2D rb2d;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(transform.right * speed * Time.fixedDeltaTime);
    }
	private void Update()
	{
        Destroy(gameObject, timeToDestroy);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.GetComponent<Life>() != null)
		{
            collision.gameObject.GetComponent<Life>().TakeDamage(damage);

        }
	}
}
