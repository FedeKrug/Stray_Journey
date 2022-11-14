using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public Transform target;
   
    void Awake()
    {
        
    }

   
    void Update()
    {
        if (target !=null)
		{
            this.transform.up = this.transform.position - target.position;

		}
    }
	
}
