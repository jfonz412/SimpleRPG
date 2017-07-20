using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class just serves to give us bonus values to be added into our final stat value
// each one gives us one bonus value.
public class StatBonus {
	public int BonusValue { get; set; }

	public StatBonus(int bonusValue)
	{
		this.BonusValue = bonusValue;
		Debug.Log ("New stat bonus initiated");
	}
}
