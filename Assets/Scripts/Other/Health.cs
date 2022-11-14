using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (GetComponent<Life>() !=null)
		{
            GetComponent<Life>().TakeDamage(0);
		}
	}
}

public interface Life
{
    public void TakeDamage(float damage);
    public void CheckDeath();
}