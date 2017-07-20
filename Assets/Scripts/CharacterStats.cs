using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
	public List<BaseStat> stats = new List<BaseStat>(); //This script has a list of base stats named 'stats'

	void Start()
	{
		/* Here we can create all of our base stats + any modifiers and add them to our 'stats' list */
		stats.Add (new BaseStat(4, "Power", "Your power level.")); //create a base stat called power at level 4
		stats[0].AddStatBonus(new StatBonus(5));                   //add a bonus to it
		Debug.Log (stats [0].CalculateFinalValue ());
	}
}
