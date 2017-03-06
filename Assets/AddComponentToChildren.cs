using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AddComponentToChildren : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        NavMeshObstacle temp = gameObject.AddComponent<NavMeshObstacle>();
        temp.size = gameObject.GetComponent<MeshFilter>().mesh.bounds.size;
        temp.carving = true;

        for(int i = 0; i < transform.childCount; i++)
        {
            NavMeshObstacle temp2 = transform.GetChild(i).gameObject.AddComponent<NavMeshObstacle>();
            //transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
            temp2.size = gameObject.GetComponent<MeshFilter>().mesh.bounds.size;
            temp2.carving = true;
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
