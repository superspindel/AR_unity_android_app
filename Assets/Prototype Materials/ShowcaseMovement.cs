using UnityEngine;
using System.Collections;

/// <summary>
/// from GhostFreeRoamCamera un modified
/// </summary>
public class ShowcaseMovement : MonoBehaviour {
    
    

	void Update ()
    {
        transform.position += Vector3.forward * Input.GetAxis("Horizontal") * Time.deltaTime;
	}
}
