using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

public class connectionScript : MonoBehaviour {
	private Button connectionButton;
	private Text buttonText;
	private ScreenStream remoteStream;
	private Paint paintScript;
	private bool ButtonInitialized = false;

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
                remoteStream.RemoteMouse.Updated += RemoteMouse_Updated; 

			}
			else
			{
				this.buttonText.text = "Connect";
			    remoteStream.RemoteMouse.Updated -= RemoteMouse_Updated;
			}
		});

	}

    private void RemoteMouse_Updated(NetworkDataObject obj)
    {
        HandleInput(obj as RemoteSupportMouse);
    }
    
	public void HandleInput(Assets.Scripts.Model.RemoteSupportMouse inputMouse)
	{
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
		
}
