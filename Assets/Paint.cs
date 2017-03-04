using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PaintMode{Trail, Arrows}

public class Paint : MonoBehaviour {

	public PaintMode mode;

	// arrows
	public GameObject Model;
	private List<GameObject> _arrows = new List<GameObject>();

	// Use this for initialization
	void Start () {
		mode = PaintMode.Arrows;
	}
	
	// Update is called once per frame
	void Update () {
		if (mode == PaintMode.Trail) 
		{
			transform.GetComponent<TrailRenderer> ().enabled = true;
			_updateTrail ();
		}
		if (mode == PaintMode.Arrows) 
		{
			transform.GetComponent<TrailRenderer> ().enabled = false;
			_updateArrows ();
		}

	}

	public void SetModeTrail(){
		mode = PaintMode.Trail;
	}

	public void SetModeArrows(){
		mode = PaintMode.Arrows;
	}

	public void ClearAllArrows(){
		foreach(GameObject g in _arrows){
			Destroy(g);
		}
	}

	private void _updateTrail(){
		if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || Input.GetMouseButton (0))) {

			Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (mRay, out hit, 100.0f)) { // if hit
				Debug.Log ("You selected the " + hit.transform.name);

				gameObject.GetComponent<TrailRenderer> ().time = 1;
				// Spawn the arrow
				this.transform.position = hit.point;
			}else {
				gameObject.GetComponent<TrailRenderer> ().time = _decreaseTimeOnTrail();
			}
		} else {
			gameObject.GetComponent<TrailRenderer> ().time = _decreaseTimeOnTrail();
		}
	}

	private void _updateArrows(){
		if (((Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) || Input.GetMouseButtonDown (0))) {
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


	private float _decreaseTimeOnTrail(){
		float time = gameObject.GetComponent<TrailRenderer> ().time;
		if (time <= 0) {
			return 0;
		}
		return (time - Time.deltaTime * 1);
	}
}
