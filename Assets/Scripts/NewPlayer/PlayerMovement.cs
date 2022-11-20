using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement: ")]
    [SerializeField, Range(0, 250f)] private float baseSpeed;
    private float speed;
    [SerializeField, Range(0, 250f)] private float boostSpeed;
    [SerializeField, Range(-720, 720f)] private float baseRotateSpeed, maxRotateSpeed;
    private float rotateSpeed;


    [SerializeField] private string horizontalAxis;
    [SerializeField] private string verticalAxis;

    private Rigidbody2D rb2d;
    private Animator anim;
    [SerializeField] private Animator fireAnim;
    private AudioSource aSource;
    private SpriteRenderer spriteR;
   // [SerializeField] private List<AudioClip> audioClips;
    private Vector2 moveInput;

    void Start()
    {
        
    }

  
    void Update()
    {
        float moveX = Input.GetAxis(horizontalAxis);
        float moveY = Input.GetAxisRaw(verticalAxis);

        moveInput = new Vector2(moveX, moveY).normalized;



        // transform.position += transform.up * moveY *speed * Time.deltaTime;
        transform.Rotate(0, 0, moveX * rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = boostSpeed;
            fireAnim.SetBool("inBoost", true);
            rotateSpeed = maxRotateSpeed;
        }

        else
        {
            speed = baseSpeed;
            fireAnim.SetBool("inBoost", false);
            rotateSpeed = baseRotateSpeed;
        }
    }
    private void FixedUpdate()
    {
        rb2d.AddForce(transform.up * moveInput.y * speed);
    }
}
