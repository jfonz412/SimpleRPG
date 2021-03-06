using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
	// Allows us to get to DialogueSystem from other classes via DialogueSystem.Instance
	public static DialogueSystem Instance { get; set; } //attribute accessors

	// a list for our lines to be set via inspector
	public List<string> dialogueLines = new List<string>(); //lists are like arrays but "better", in c# you can't dynamicly size arrays

	// allows us to drag Dialog Panel into this object via inspector
	public GameObject dialoguePanel;
	public string     npcName; //will probably be set to hidden soon

	Button continueButton;         //make a button object
	Text   dialogueText, nameText; //make two text objects
	int    dialogueIndex;          //I belive this is for our dialogue array

	// When activated via NPC
	void Awake () {
		//get continue button component through dialogue panel's child 'Continue', same with text and name
		continueButton = dialoguePanel.transform.Find ("Continue").GetComponent<Button> ();
		dialogueText   = dialoguePanel.transform.Find("Text").GetComponent<Text> (); 
		nameText       = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>(); // 0 means get the first child (indexed by 0)

		//what happens when the button is clicked
		// Delegates are used to pass methods as arguments to other methods.
		continueButton.onClick.AddListener (delegate{ ContinueDialogue(); } );
		dialoguePanel.SetActive (false);


		// if Instance is not null and isn't this instance(?)
		if (Instance != null && Instance != this) { 
			Destroy (gameObject); //Destroy self
		} 
		else 
		{
			Instance = this;
		}
	}

	// To be called by NPC, who will pass in their lines and name
	public void AddNewDialogue(string[] lines, string npcName)
	{
		dialogueIndex = 0;
		dialogueLines = new List<string> (lines.Length); //set the list to lines.length
		dialogueLines.AddRange (lines); //appends lines to the the list
		this.npcName = npcName; //set this instances name to the name passed
		CreateDialogue();
		Debug.Log(dialogueLines.Count);
	}

	public void CreateDialogue()
	{
		dialogueText.text = dialogueLines [dialogueIndex];
		nameText.text = npcName;
		dialoguePanel.SetActive (true);
	}

	public void ContinueDialogue()
	{
		if (dialogueIndex < dialogueLines.Count - 1) 
		{
			dialogueIndex++;
			dialogueText.text = dialogueLines [dialogueIndex];
		} 
		else 
		{
			dialoguePanel.SetActive (false);
		}
	}
}
