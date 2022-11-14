using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Health, Life
{
    [Header("Movement: ")]
    [SerializeField, Range(0, 250f)] private float baseSpeed, boostSpeed;
    private float speed;
    [SerializeField, Range(0, 720f)] private float baseRotateSpeed, rotateSpeed, maxRotateSpeed;



    [Header("Times to Shoot: ")]
    [SerializeField, Range(0, 3)] private float baseCoolDown;
    [SerializeField, Range(0, 3)] private float attackCoolDown;
    [SerializeField, Range(0, 3)] private float coolDownMod;
    [SerializeField] private float remainingAttackInterval;
    [Space]
    [SerializeField, Tooltip("Type of bullets to get")] private List<GameObject>[] typeOfBullets;
    [SerializeField, Tooltip("Type of bullets to get")] private List<GameObject>[] specialBullets;
    [SerializeField] private List<GameObject> bulletGen;
    [SerializeField] private GameObject specialGenerator;

    [Space]

    [SerializeField] private string horizontalAxis;
    [SerializeField] private string verticalAxis;
    

  



    private Rigidbody2D rb2d;
    private Animator anim;
    private Animator fireAnim;
    private AudioSource aSource;
    private SpriteRenderer spriteR;
    [SerializeField] private List<AudioClip> audioClips;
    private Vector2 moveInput;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        horizontalAxis = "Horizontal";
        verticalAxis = "Vertical";
        remainingAttackInterval = attackCoolDown;
        rotateSpeed = maxRotateSpeed;
        speed = baseSpeed;
        attackCoolDown = baseCoolDown;
        spriteR = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float moveX = Input.GetAxis(horizontalAxis);
        float moveY = Input.GetAxisRaw(verticalAxis);

        moveInput = new Vector2(moveX, moveY).normalized;



        // transform.position += transform.up * moveY *speed * Time.deltaTime;
        transform.Rotate(0, 0, moveX * rotateSpeed * Time.deltaTime);

      



        if (remainingAttackInterval > 0)
        {
            remainingAttackInterval -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = boostSpeed;
            rotateSpeed = maxRotateSpeed;
        }

        else
        {
            speed = baseSpeed;
            rotateSpeed = baseRotateSpeed;
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKey(KeyCode.C)) //common bullet
        {
            MultiShooting(0);
            attackCoolDown = baseCoolDown;
        }


        if (Input.GetKeyDown(KeyCode.V) || Input.GetKey(KeyCode.V) && !Input.GetKeyDown(KeyCode.C) && !Input.GetKey(KeyCode.C))
        {
            MultiShooting(1);
            attackCoolDown = coolDownMod;
        }




    }
    private void FixedUpdate()
    {
        rb2d.AddForce(transform.right * moveInput.y * speed);
    }

    
    

    void MultiShooting(int typeOfShoot)
    {
        if (remainingAttackInterval <= 0)
        {
            remainingAttackInterval = attackCoolDown;
            for (int i = 0; i < bulletGen.Count; i++)
            {

                bulletGen[i].GetComponent<BulletGen>().Shoot(typeOfShoot);
            }
        }
    }

  
   

	public void TakeDamage(float damage)
	{
		
	}

	public void CheckDeath()
	{
     
    }
}
