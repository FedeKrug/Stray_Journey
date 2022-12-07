using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    [Range(0,250f)] public float speed;
    [SerializeField,Tooltip("Change damage " +
    "with a boost later"), Range(0,250f)] private float damageModifier;
    [Header("Destroying Bullets: ")]
    [SerializeField, Range(0, 30f)] private float timeToDestroy;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioSource _aSource;
    

	private void Update()
	{
        Destroy(gameObject, timeToDestroy);
	}

	private void FixedUpdate()
	{
        _rb2d.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);  
	}

}
