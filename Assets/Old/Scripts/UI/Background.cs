using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField, Range(0,2)] private float speed;
    [SerializeField] private float lastPosY;
    [SerializeField] private float firstPos;
    void Awake()
    {
        transform.position = new Vector3(0,firstPos,0);
    }

   
    void Update()
    {
        transform.position -= new Vector3(0,speed * Time.deltaTime,0);

        if (transform.position.y <= lastPosY)
		{
            transform.position = new Vector3(0, firstPos, 0);
        }
    }
}
