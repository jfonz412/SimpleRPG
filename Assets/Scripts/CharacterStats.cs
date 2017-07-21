using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
	public List<BaseStat> stats = new List<BaseStat>(); //This script has a list of base stats named 'stats'

	void Start()
	{
		/* Here we can create all of our base stats */
		stats.Add (new BaseStat(4, "Power", "Your power level.")); //create a base stat called power at level 4
		stats.Add (new BaseStat(2, "Vitality", "Your vitality level."));
	}

	// For equipping 
	public void AddStatBonus(List<BaseStat> statBonuses) //takes a list of BaseStats from the weapon
	{
		//cycle through the list of BaseStats from the weapon, reffered to as a Stat bonus to the character
		foreach (BaseStat statBonus in statBonuses) 
		{
			// search through the character's base stats for a StatName that matches a weapon's stat name, add it to the Charectar's list of statbonus's as a new StatBonus 
			stats.Find (x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}

	// For unequipping, reverse of the above
	public void RemoveStatBonus(List<BaseStat> statBonuses)
	{
		foreach (BaseStat statBonus in statBonuses) 
		{
			stats.Find (x=> x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
		}
	}
}
