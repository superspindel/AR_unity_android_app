using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public enum PopUpType{general, startup, tools, reward};

public class PopUp : MonoBehaviour {

	public GameObject topPanel, startupView, generalView;
	public string panelTitle, title, content;

	private Button exitButton;

	public void enterPopup(PopUpType type, string panelTitle, string title, string content){
		this.gameObject.SetActive (true);
		if (type == PopUpType.general) {
			setActivePopUpView (PopUpType.general);
			generalView.transform.FindChild ("Title").GetComponent<Text> ().text = title;
			generalView.transform.FindChild ("Content").GetComponent<Text> ().text = content;
		}
		topPanel.transform.FindChild ("Title").GetComponent<Text> ().text = panelTitle;

		// setup exit button
		this.exitButton = topPanel.transform.FindChild("ExitButton").GetComponent<Button> ();
		exitButton.onClick.AddListener (leavePopup);
	}
			
	private void setActivePopUpView(PopUpType type){
		startupView.gameObject.SetActive(false);
		generalView.gameObject.SetActive(false);
		if(type == PopUpType.general)
			generalView.gameObject.SetActive(true);
		if(type == PopUpType.startup)
			startupView.gameObject.SetActive(false);
	}

	void leavePopup(){
		transform.gameObject.SetActive (false);
	}
}
