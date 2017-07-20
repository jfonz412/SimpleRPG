using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour {
	NavMeshAgent npcAgent;
	Vector3 point_A = new Vector3(0f,0f,0f);

	void Start()
	{
		npcAgent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		npcAgent.destination = point_A;
	}
}
