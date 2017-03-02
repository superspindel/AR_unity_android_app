using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePointer : MonoBehaviour {
	
	private GameObject _model;

	// Use this for initialization
	void Start () {
		_model = transform.FindChild ("Arrows Green").gameObject;
		_model.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || Input.GetMouseButton (1))) {
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			if (Physics.Raycast (ray, out hit, 100.0f)) {
				_model.SetActive (true);
				Debug.Log ("You selected the " + hit.transform.name); // ensure you picked right object
				transform.position = hit.point;
				transform.LookAt (hit.transform);
			}
		} else {
			_model.SetActive (false);
		}

	}
}