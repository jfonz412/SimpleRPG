using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon // our sword must meet the standards of the weapon interface
{
	private Animator animator;
	public List<BaseStat> Stats { get; set; } // a weapon has it's own base stats

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	public void PerformAttack ()
	{
		animator.SetTrigger ("BaseAttack"); //trigger this animation trigger
	}

	//example
	public void PerformSpecialAttack ()
	{
		animator.SetTrigger ("SpecialAttack");
	}

	void OnTriggerEnter(Collider col) //arg gives us infor about what we hit
	{
		Debug.Log("Hit: " + col.name);
	}
		
}
