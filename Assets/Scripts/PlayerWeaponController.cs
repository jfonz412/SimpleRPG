using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// can be modified for different weapons, armors, ect
public class PlayerWeaponController : MonoBehaviour {
	
	public GameObject playerHand; // empty var for our hand object
	public GameObject EquippedWeapon { get; set; } // will/does have weapon interface

	IWeapon equippedWeapon; //testing? or shorthand to the weapon interface
	CharacterStats characterStats;

	void Start()
	{
		characterStats = GetComponent<CharacterStats> ();
	}

	public void EquipWeapon(Item itemToEquip) 
	{
		// if we are already holding a weapon
		if (EquippedWeapon != null) 
		{
			//get the weapon interface stats and remove any bonuses from the char stats
			characterStats.RemoveStatBonus (EquippedWeapon.GetComponent<IWeapon>().Stats);
			Destroy (playerHand.transform.GetChild (0).gameObject);
		}
		// then we create a object by looking through our resources folder for an object named after itemToEquip's ObjectSlug
		EquippedWeapon = (GameObject)Instantiate (Resources.Load<GameObject> ("Weapons/" + itemToEquip.ObjectSlug),
			playerHand.transform.position, playerHand.transform.rotation);
		
		equippedWeapon = EquippedWeapon.GetComponent<IWeapon> (); //testing?
		equippedWeapon.Stats = itemToEquip.Stats;

		//EquippedWeapon.GetComponent<IWeapon> ().Stats = itemToEquip.Stats; //set weapon stats
		EquippedWeapon.transform.SetParent (playerHand.transform); //set the parent of weapon's transform to the hand's transform
		characterStats.AddStatBonus (itemToEquip.Stats); // add item's stats as bonus stats to the player
		Debug.Log(equippedWeapon.Stats[0].CalculateFinalValue());
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.X)) {
			PerformWeaponAttack ();
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			PerformSpecialAttack ();
		}
	}


	public void PerformWeaponAttack()
	{
		equippedWeapon.PerformAttack ();
		//EquippedWeapon.GetComponent<IWeapon> ().PerformAttack ();
	}
	public void PerformSpecialAttack()
	{
		equippedWeapon.PerformSpecialAttack ();
		//EquippedWeapon.GetComponent<IWeapon> ().PerformAttack ();
	}
}
