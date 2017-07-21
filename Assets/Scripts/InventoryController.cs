using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//how we define and equip an item
public class InventoryController : MonoBehaviour {

	//testing
	public PlayerWeaponController playerWeaponController;
	public Item sword; //define a new Item called sword

	void Start()
	{
		playerWeaponController = GetComponent<PlayerWeaponController> ();

		// will change or remove to be less specific, this is for testing
		List<BaseStat> swordStats = new List<BaseStat> (); // create a List of BaseStats for the sword
		swordStats.Add(new BaseStat(6, "Power", "Your power level.")); // add a stat to it
		sword = new Item(swordStats, "sword"); // define item with the stats list and a string
	}

	//testing
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.V)) {
			playerWeaponController.EquipWeapon(sword);
		}
	}
}
