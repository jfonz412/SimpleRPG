using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
	//declare variable here so it's avaibable to the whole class
	NavMeshAgent playerAgent;

	void Start()
	{
		// When initiated, set playerAgent to NavMeshAgent (a component for pathfinding)
		playerAgent = GetComponent<NavMeshAgent> (); //get the NavMeshAgent for the object this script is attatched to
	}

	void Update () {                        //STOPS PLAYER FROM MOVING WHEN DIALOGUE PANEL IS ACTIVE
		if (Input.GetMouseButtonDown (0) && !DialogueSystem.Instance.dialoguePanel.activeInHierarchy) 
		{
			MoveCamera (); //call this when you click the mouse
		}
	}

	void MoveCamera()
	{
		// Think ray of sunshine
		// Creates a Ray from the Main camera to the mouse position (when clicked)
		Ray cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition); 

		//creates new RayCastHit object to get info from raycast
		RaycastHit cameraInfo;

		// check for collisions in the Ray
		// out means the arg has no value but will be defined by the method

		// Basically Physics.Raycast starts from the camera to the mouse
		// It uses info from the Raycase (camera info) to check for any collisions
		// to make a new game object with the object the Ray collided with
		// If the object has an Interactive Object tag, it calls the Interactable script
		// (which is a component) and then calls the MoveToInteraction method, passing the player
		// in as an argument
		if (Physics.Raycast (cameraRay, out cameraInfo, Mathf.Infinity)) 
		{
			GameObject interactedObject = cameraInfo.collider.gameObject;
			if (interactedObject.tag == "Interactable Object") {
				//work with the Interactable script on this object
				interactedObject.GetComponent<Interactable> ().MoveToInteraction (playerAgent);
			} 
			else
			{
				playerAgent.stoppingDistance = 0;
				playerAgent.destination = cameraInfo.point;
			}
		}
	}
}
