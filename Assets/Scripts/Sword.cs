using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon // our sword must meet the standards of the weapon interface
{
	
	public List<BaseStat> Stats { get; set; } // a weapon has it's own base stats

	public void PerformAttack ()
	{
		Debug.Log ("Sword Attack");
	}
		
}
