using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public enum PopUpType{general, startup, tools, reward};

public class PopUp : MonoBehaviour {
	
	public GameObject 	StartupView;
	public GameObject 	GeneralView;
	public GameObject 	TopPanel;

	private Button 		_exitButton;

	private Pageswapper _pageswapper;

	void Awake(){
		_pageswapper = GameObject.Find ("Page Swapper").GetComponent<Pageswapper> ();
	}


	public void enterPopup(){
		// setup exit button
		this._exitButton = TopPanel.transform.FindChild("ExitButton").GetComponent<Button> ();
		_exitButton.onClick.AddListener (_pageswapper.leavePopup);

		// Setup Panel Title
		setPanelTitle("Panel Title");
		setContentTitle ("Content Title");


		// 
		setActivePopUpView (PopUpType.general);
	}


	private void setActivePopUpView(PopUpType type){
		StartupView.gameObject.SetActive(false);
		GeneralView.gameObject.SetActive(false);
		if(type == PopUpType.general)
			GeneralView.gameObject.SetActive(true);
		if(type == PopUpType.startup)
			StartupView.gameObject.SetActive(false);
	}




	public void setPanelTitle(string s){
		this.TopPanel.transform.FindChild ("Title").GetComponent<Text> ().text = s;
	}

	public void setContentTitle(string s){
		GeneralView.transform.FindChild ("Title").GetComponent<Text> ().text = s;
	}

	public void setContentText(string s){
		GeneralView.transform.FindChild ("Content").GetComponent<Text> ().text = s;
	}

}
