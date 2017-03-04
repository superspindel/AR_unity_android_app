using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePointer : MonoBehaviour {
	
	public GameObject Model;
	private List<GameObject> _arrows = new List<GameObject>();

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || Input.GetMouseButtonDown (1))) {
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			if (Physics.Raycast (ray, out hit, 100.0f)) { // if hit
				Debug.Log ("You selected the " + hit.transform.name);

				// Spawn the arrow
				GameObject newArrow = Instantiate(Model);
				newArrow.transform.position = hit.point;
				newArrow.transform.up = hit.normal * -1;
				newArrow.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
				newArrow.transform.SetParent (hit.transform);

				_arrows.Add (newArrow);
			}
		}
	}

	public void clearAllArrows(){
		foreach(GameObject g in _arrows){
			Destroy(g);
		}
	}
}