using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitPaintscript : MonoBehaviour {

	private Button exitButton;
	// Use this for initialization
	void Start () {
		this.exitButton = gameObject.GetComponent<Button> ();
		this.exitButton.onClick.AddListener (() => {
			UnityEngine.SceneManagement.SceneManager.LoadScene("_main");
		});
	}



}
