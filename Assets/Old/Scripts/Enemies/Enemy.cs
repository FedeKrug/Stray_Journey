using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    
    [Header("Attack: ")]
    public float maxDamage;
    [SerializeField] private List<GameObject> commonBullets;
    [SerializeField] private List<GameObject> specialBullets;
    [Header("Health: ")]
    [SerializeField] private float life;
    [SerializeField] private List<GameObject> coins;
    [SerializeField] private Bullet bulletRefs;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private float timeOfDamaged;
    [SerializeField] private Color normalColor, hurtColor;


    private Animator anim;
    private AudioSource aSource;

    [SerializeField] private List<AudioClip> clips;
	[SerializeField] private int maxCantOfCoins;
    [SerializeField] private string deadParameter;

	void Awake()
    {
      
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        
        spriteR = GetComponent<SpriteRenderer>();
    }
   
    void CheckDeath()
    {

        if (life <= 0)
        {
            this.gameObject.SetActive(false);
            int randomCoin = Random.Range(0,coins.Count);
            Instantiate(coins[randomCoin],transform.position,transform.rotation);
            StopAllCoroutines();
        }
    }
    IEnumerator TakeDamage(float timeOfDamaged, Color normalColor, Color hurtColor)
	{
        this.spriteR.color = hurtColor;
        yield return new WaitForSeconds(timeOfDamaged);
        this.spriteR.color = normalColor;
	}

	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.tag == "Bullet")
		{
            
            life -= bulletRefs.damage;
            StartCoroutine(TakeDamage(timeOfDamaged, normalColor,hurtColor));
            //CheckDeath();
            ImprovedCheckDeath();
        }
       
    }
    void ImprovedCheckDeath()
    {
        if (life <= 0)
        {
            StartCoroutine(EnemyDead());
        }
    }
    void DeathAnimation()
    {
        anim.SetTrigger(deadParameter); // Animation hecha desde any state, y no por parametros dependientes del animator.
    }
    void Death()
    {
        this.gameObject.SetActive(false);
        int randomCoin = Random.Range(0, coins.Count);
        int randomCoinCant = Random.Range(0, maxCantOfCoins);
        Instantiate(coins[randomCoin], transform.position, transform.rotation);
        //for (int i = 0; i < randomCoinCant; i++)
        //{
        //}//puedo instanciar varias monedas a la vez, con una misma funcion. Me falta crear un rango de distancias para que las monedas no se instancien en el mismo lugar.
    }

    IEnumerator EnemyDead()
    {
        DeathAnimation();
        this.GetComponent<ObjectsSound>().TurnSoundOn();
        DisableEnemies();
        yield return new WaitForSeconds(2);
        Death();
        yield  break;
    }
    public void DisableEnemies()
	{
        if (this.GetComponent<FollowObject>() !=null)
		{
            this.GetComponent<FollowObject>().enabled = false;

		}
        if (this.GetComponent<LookAtObject>() != null)
		{
            this.GetComponent<LookAtObject>().enabled = false;

		}
        if (this.GetComponent<EnemyShooting>() != null)
		{
            this.GetComponentInChildren<EnemyShooting>().enabled = false;
		}
    }
}
