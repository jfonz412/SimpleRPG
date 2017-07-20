using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Each stat will have it's own BaseStat object
// It is used hold stat info and calculate the final value
public class BaseStat { 
	// a list of StatBonus objects named StatModifiers
	public List<StatBonus> StatModfiers { get; set; }

	// class attributes
	public int    BaseValue { get; set; }
	public string StatName { get; set; }
	public string StatDescription { get; set; }
	public int    FinalValue { get; set; }


	//this is called in our CharacterStats script. It builds the stat (without modifiers)
	public BaseStat(int baseValue, string statName, string statDescription)
	{
		this.StatModfiers = new List<StatBonus> (); //prepare our list of StatBonus, empty at first
		this.BaseValue = baseValue;
		this.StatName = statName;
		this.StatDescription = statDescription;
	}

	//called in our CharacterStats script to add modifiers..
	//..will be attatched to items somehow?
	public void AddStatBonus(StatBonus statBonus)
	{
		this.StatModfiers.Add (statBonus);
	}

	public void RemoveStatBonus(StatBonus statBonus)
	{
		this.StatModfiers.Remove (statBonus);
	}

	//Must be called to get base stat + all modifiers
	public int CalculateFinalValue()
	{							//as x
		this.StatModfiers.ForEach (x => this.FinalValue += x.BonusValue);
		FinalValue += BaseValue;
		return FinalValue;
	}
}
