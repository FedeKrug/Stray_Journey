using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
	Animator anim;
	[SerializeField] private string deathParameter;
	void Awake()
	{
		anim = GetComponent<Animator>();
	}


	void Update()
	{
		
	}
	public void DeadAnimation()
	{
		anim.SetTrigger(deathParameter);
	}
}
