using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class connectionScript : MonoBehaviour {
	private Button connectionButton;
	private Text buttonText;
	private ScreenStream remoteStream;
	private Paint paintScript;

	// Use this for initialization
	void Start () {
		this.connectionButton = gameObject.GetComponent<Button> ();
		this.remoteStream = GameObject.FindGameObjectWithTag ("remoteStream").GetComponent<ScreenStream> ();
		this.buttonText = gameObject.GetComponentInChildren<Text> ();
		this.paintScript = GameObject.FindGameObjectWithTag("Painter").GetComponent<Paint>();
		this.connectionButton.onClick.AddListener (() => {
			this.remoteStream.PublishStream = !this.remoteStream.PublishStream;
			if (this.remoteStream.PublishStream)
			{
				this.buttonText.text = "Disconnect";
				this.remoteStream.RemoteMouse.Updated += o => { HandleInput(o as Assets.Scripts.Model.RemoteSupportMouse); };
			}
			else
			{
				this.buttonText.text = "Connect";
				this.remoteStream.RemoteMouse.Updated -= o => { HandleInput(o as Assets.Scripts.Model.RemoteSupportMouse); };
			}
		});

	}
	/*
	 * 	public class InputContainer {
		public Vector3 pos;
		public bool clicked;
	}
	 * 
	 */

	public void HandleInput(Assets.Scripts.Model.RemoteSupportMouse inputMouse)
	{
		//Debug.Log ("mouseMovement");
		if (inputMouse.Down) {
			Vector3 mousePos = new Vector3 (inputMouse.Position.X, 800-inputMouse.Position.Y, inputMouse.Position.Z);
			inpCont newInput = new inpCont ();
			newInput.clicked = true;
			newInput.pos = mousePos;
			paintScript._updateArrows (newInput);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	/*
	 * 					RemoteMouse.Updated += o => {
						if (RemoteMouse.Down)
						{
							Debug.Log(RemoteMouse.Position.X);
							Debug.Log(RemoteMouse.Position.Y);
							Debug.Log(RemoteMouse.Position.Z);
							Debug.Log("SWAG");
						}
					};
	*/
}
