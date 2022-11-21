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

    private Rigidbody2D _rb2d;
    private Animator _anim;
    [SerializeField] private Animator _fireAnim;
    private AudioSource _aSource;
    private SpriteRenderer _spriteR;
    private Vector2 _moveInput;

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        float moveX = Input.GetAxis(horizontalAxis);
        float moveY = Input.GetAxisRaw(verticalAxis);

        _moveInput = new Vector2(moveX, moveY).normalized;
        
        transform.Rotate(0, 0, moveX * rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = boostSpeed;
            _fireAnim.SetBool("inBoost", true);
            rotateSpeed = maxRotateSpeed;
        }

        else
        {
            speed = baseSpeed;
            _fireAnim.SetBool("inBoost", false);
            rotateSpeed = baseRotateSpeed;
        }
    }
    private void FixedUpdate()
    {
        _rb2d.AddForce(transform.up * _moveInput.y * speed);
    }
}
