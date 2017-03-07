using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {

    // Use this for initialization
    bool firstFrame = true;
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (firstFrame)
        {
            GetComponent<NavMeshAgent>().destination = new Vector3(70.0f, 0.7f, 51.7f);
            firstFrame = false;
        }
		
	}
}
