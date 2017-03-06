using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ccScript : MonoBehaviour {

	private cameraSwitch cameraswitch;
	private Button ccButton;

	// Use this for initialization
	void Start () {
		this.cameraswitch = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<cameraSwitch> ();
		this.ccButton = gameObject.GetComponent<Button> ();
		this.ccButton.onClick.AddListener (cameraswitch.toggle);
	}
}
