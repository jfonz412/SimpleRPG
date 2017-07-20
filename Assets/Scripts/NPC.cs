using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherits from Interactable class instead of the standard MonoBehavior class
public class NPC : Interactable {
	public string[] dialogue;
	public new string name;

	public override void Interact()
	{
		// pass dialogue info to a DialougeSystem object, called Instance
		DialogueSystem.Instance.AddNewDialogue (dialogue, name);
		Debug.Log ("Interacting with NPC");
	}
}
