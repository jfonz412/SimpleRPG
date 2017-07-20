using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class inherits from Interactable and will be our base class
// for interacting with objects like signs, crates, ect.
public class ActionItem : Interactable {
	
	//creates a new class that will be overwritten by classes that inherit from ActionItem
	public override void Interact()
	{
		Debug.Log ("Interacting with BASE Action Item");
	}

}
