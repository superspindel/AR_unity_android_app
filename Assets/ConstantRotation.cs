using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {

	public float speedX = 0f;
	public float speedY = 0f; 
	public float speedZ = 0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (speedX*Time.deltaTime, speedY*Time.deltaTime, speedZ*Time.deltaTime); //rotates 50 degrees per second around z axis
	}
}
