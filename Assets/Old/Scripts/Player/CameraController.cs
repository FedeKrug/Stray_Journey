using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField,Range(-50,50)] private float offset;
    [SerializeField] private Transform target;

    Vector3 auxVector;
    void Awake()
    {
            
    }

   
    void Update()
    {
        if (target != null)
		{
             this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offset, this.transform.position.z);
         
        }
    }
    void DelayMovement()
	{
        auxVector = Vector2.MoveTowards(transform.position, target.position, offset * Time.deltaTime);
        auxVector.z = this.transform.position.z;
        this.transform.position = auxVector;
    }
}
