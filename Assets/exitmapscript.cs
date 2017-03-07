using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitmapscript : MonoBehaviour {

	private Button exitMapButton;
	// Use this for initialization
	void Start () {
		this.exitMapButton = gameObject.GetComponent<Button> ();
		this.exitMapButton.onClick.AddListener (() => {
			UnityEngine.SceneManagement.SceneManager.LoadScene("_main");	
		});
	}

}
