using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    [SerializeField, Range(-20,20)] private float maxFollowingSpeed;
    Vector3 targetPos;


    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
   
    void Update()
    {
        if (target != null)
		{
            targetPos = Vector2.MoveTowards(transform.position, target.position, maxFollowingSpeed * Time.deltaTime);
            targetPos.z = this.transform.position.z;
            this.transform.position = targetPos;
		}
    }
	
}
