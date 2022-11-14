using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float offsetX, offsetY;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.position + new Vector3(offsetX,offsetY,this.transform.position.z) ;
    }
}
