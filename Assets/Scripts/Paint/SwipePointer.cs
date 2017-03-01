using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePointer : MonoBehaviour {

	Plane objPlane;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(1)))
		{
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray,out hit,100.0f)) {
				Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
				transform.position = hit.point;
				transform.LookAt (hit.transform);
			}
		}
	}
}