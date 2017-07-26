using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Every equippable weapon must have these functions
public interface IWeapon {
	List<BaseStat> Stats  { get; set;} // attribute accessors for a list of BaseStats
	void PerformAttack(); // a PerformAttack(); method
	void PerformSpecialAttack();
}
