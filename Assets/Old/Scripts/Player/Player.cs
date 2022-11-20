using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Movement: ")]
    [SerializeField, Range(0,250f)]  private float baseSpeed;
                                     private float speed;
    [SerializeField, Range(0,250f)]  private float boostSpeed;
    [SerializeField, Range(-720, 720f)] private float baseRotateSpeed, rotateSpeed, maxRotateSpeed;
   

    [Header ("Health: ")]
    [SerializeField, Min(3)] private float baseHealth;
                             public float health;
                             public float maxHealth;
    [SerializeField, Range(0, 5f)] private float mercyTime;
    [SerializeField] private EnemyBullet enemyBullets;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color hurtColor;

    [Header("Times to Shoot: ")]
    [SerializeField, Range(0, 3)] private float baseCoolDown;
    [SerializeField, Range(0, 3)] private float attackCoolDown;
    [SerializeField, Range(0, 3)]  private float coolDownMod;
    [SerializeField] private float remainingAttackInterval;
    [Space]
    [SerializeField, Tooltip("Type of bullets to get")] private List<GameObject>[] typeOfBullets;
    [SerializeField, Tooltip("Type of bullets to get")] private List<GameObject>[] specialBullets;
    [SerializeField] private List<GameObject> bulletGen;
    [SerializeField] private GameObject specialGenerator;

    [Space]
    
    [Header("Animations")]
    [SerializeField] private string horizontalAxis;
    [SerializeField] private string verticalAxis;
    [SerializeField] private GameObject fire;
    [SerializeField] private string speedParameterA;
    [SerializeField] private string deathParameter = "died";
    [Space]
     public bool super = false;
    
    [Space]
    [Header("UI Elements: ")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject defeatScreen;
    [SerializeField] private GameObject backgroundAudio;
    
    
    
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
        fireAnim = fire.GetComponent<Animator>();
        health = maxHealth;
        rotateSpeed = maxRotateSpeed;
        speed = baseSpeed;
        attackCoolDown = baseCoolDown;
        spriteR = GetComponent<SpriteRenderer>();
    }
	

	void Update()
    {  
        float moveX = Input.GetAxis(horizontalAxis);
        float moveY = Input.GetAxisRaw(verticalAxis);

        moveInput = new Vector2(moveX,moveY).normalized;


       
       // transform.position += transform.up * moveY *speed * Time.deltaTime;
       transform.Rotate(0,0,moveX * rotateSpeed * Time.deltaTime);
       
        if (healthBar !=null)
		{
            healthBar.UpdateBar(health, maxHealth);
		}

        

		if (remainingAttackInterval > 0)
		{
			remainingAttackInterval -= Time.deltaTime;
		}
        
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
		
        if (Input.GetKeyDown(KeyCode.C)|| Input.GetKey(KeyCode.C)) //common bullet
		{
            MultiShooting(0);
            attackCoolDown = baseCoolDown;
		}
	
       
        if (Input.GetKeyDown(KeyCode.V)|| Input.GetKey(KeyCode.V) && !Input.GetKeyDown(KeyCode.C)&& !Input.GetKey(KeyCode.C))
		{
            MultiShooting(1);
            attackCoolDown = coolDownMod;
        }
 
       

       
	}
	private void FixedUpdate()
	{
        rb2d.AddForce(transform.up * moveInput.y * speed);
	}
    
	private void OnTriggerEnter2D(Collider2D collision)
	{
		switch (collision.tag)
		{
            case "SuperObject":
                if (super == false)
				{
					super = true;
				}
                break;
            case "EnemyBullet":
                CheckDeath();
                StartCoroutine(InvencibleTime());
                break;
			default:
				break;
		}

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
            health--;
            CheckDeath();
		}
	}

	void MultiShooting(int typeOfShoot)
	{
        if (remainingAttackInterval <= 0)
		{
            remainingAttackInterval = attackCoolDown;
            for (int i=0; i < bulletGen.Count; i++)
		    {
             
             bulletGen[i].GetComponent<BulletGenerator>().Shoot(typeOfShoot);
		    }
		}
	}
	
	void CheckDeath()
	{
        if (health <= 0)
        {
            if (defeatScreen != null) //Defeat Screen
            {
                defeatScreen.SetActive(true);
               // aSource.Stop();
               AudioSource gManagerAudio = backgroundAudio.GetComponent<AudioSource>();
                gManagerAudio.Stop();
            }
            anim.SetTrigger(deathParameter);
            Debug.Log("Player is dead");

        }
    }
    IEnumerator InvencibleTime()
	{
        this.tag = "Enemy";
        spriteR.color = hurtColor;
        yield return new WaitForSeconds(mercyTime);
        Debug.Log("Inmunidad");
        this.tag = "Player";
        spriteR.color = normalColor;
	}
}


