using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This class will be used as a base for all our interactable objects
public class Interactable : MonoBehaviour {
	
	[HideInInspector]
	public NavMeshAgent playerAgent; //can't be private because this is passed around between objects

	private bool hasInteracted; // move to object before we interact with it

	// 'virtual' allows us to override this function
	public virtual void MoveToInteraction(NavMeshAgent playerAgent) //in this case this is the player
	{																//passed in from WorldInteraction
		hasInteracted = false;
		this.playerAgent = playerAgent; //sets this class' playerAgent to the Player
		playerAgent.stoppingDistance = 4f;
		playerAgent.destination = this.transform.position;

	}

	void Update()
	{
		if(!hasInteracted && playerAgent != null && !playerAgent.pathPending) //make sure player exists and isn't pathfinding
		{
			if(playerAgent.remainingDistance <= playerAgent.stoppingDistance)
			{
				Interact ();
				hasInteracted = true;
			}
		}
	}

	// this is the base class to be overwritten by interable objects
	public virtual void Interact()
	{
		Debug.Log("Interacting with base class");
	}
}
