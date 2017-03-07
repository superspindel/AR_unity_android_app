using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputContainer {
	public float x;
	public float y;
	public bool clicked;
}

public class InputConverter : MonoBehaviour {
	public bool testWithMouseInput;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x, y;
		if (testWithMouseInput) {
			if (Input.GetMouseButtonDown (0)) {
				x = Input.mousePosition.x / Screen.width;
				y = Input.mousePosition.y / Screen.height;
			}
		}

	}

	public InputContainer getInput(){
		// get input from server?
		float xServer = 0;
		float yServer = 0;
		bool clickedServer = false;

		InputContainer returnValue = new InputContainer();
		returnValue.x = xServer * Screen.width;
		returnValue.y = yServer * Screen.height;
		returnValue.clicked = clickedServer;

		return returnValue;
	}
}
