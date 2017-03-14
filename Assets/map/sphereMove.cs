using UnityEngine;
using System.Collections;


/// <summary>
/// The Class move the sver worker arond in the envierment.
/// @auther Samuel Karlsson
/// </summary>
public class sphereMove : MonoBehaviour {

    private Rigidbody rb;
    //public speed variabel so adjust the workers movment speed
    public int speed = 10;

    
    /// <summary>
    /// used to iniselait 
    /// </summary>
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	/// <summary>
    /// update the workers position
    /// </summary>
    void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movment * speed);
	}
}
