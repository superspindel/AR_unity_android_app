using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTrail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || Input.GetMouseButton (0))) {

			Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (mRay, out hit, 100.0f)) { // if hit
				Debug.Log ("You selected the " + hit.transform.name);

				gameObject.GetComponent<TrailRenderer> ().time = 1;
				// Spawn the arrow
				this.transform.position = hit.point;
			}else {
				gameObject.GetComponent<TrailRenderer> ().time = decreaseTimeOnTrail();
			}
		} else {
			gameObject.GetComponent<TrailRenderer> ().time = decreaseTimeOnTrail();
		}
	}

	private float decreaseTimeOnTrail(){
		float time = gameObject.GetComponent<TrailRenderer> ().time;
		if (time <= 0) {
			return 0;
		}
		return (time - Time.deltaTime * 1);
	}
}
