using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AddObstacleComponent : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        NavMeshObstacle temp = gameObject.AddComponent<NavMeshObstacle>();
        temp.carving = true;

        for(int i = 0; i<transform.childCount; i++)
        {
            NavMeshObstacle loopTemp = transform.GetChild(i).gameObject.AddComponent<NavMeshObstacle>();
            loopTemp.carving = true;

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
