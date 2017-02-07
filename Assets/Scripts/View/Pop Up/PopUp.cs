﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public enum PopUpType{General, Startup, Tools, Reward};

public class PopUp : MonoBehaviour {
	
	public GameObject 	StartupRoutinePopupView, GeneralPopupView, SubTaskInformationPopupView, PopupTopPanel;
	//private GameObject 	_activePopupView; 

	private Button 		_exitButton;
	private Pageswapper _pageswapper;
	private Text 		_popUpPanelText;
	private Color		_standardColor;
	private Color 		_warningColor;

	void Awake(){
		_pageswapper = GameObject.Find ("Page Swapper").GetComponent<Pageswapper> ();
		this._popUpPanelText = PopupTopPanel.transform.FindChild ("Title").GetComponent<Text> ();

		// exit button
		this._exitButton = PopupTopPanel.transform.FindChild("ExitButton").GetComponent<Button> ();
		_exitButton.onClick.AddListener (_pageswapper.LeavePopup);

		_standardColor = new Color32(0x38, 0x49, 0x67, 0xFF);
		_warningColor = new Color32 (0xB2, 0x3F, 0x46, 0xFF);
	}

	public void ClosePopup (){
		this.gameObject.SetActive (false);
	}

	public void OpenStartupRoutinePopup(){
		// Setup Panel Title
		_setPopupPanelTitle("Startup Routine");
	}

	public void OpenSubTaskInformationPopup(SubTask subTask){
		_setActivePopupView(SubTaskInformationPopupView);
		_setPopupPanelTitle("Information");
		_setPopUpPanelColor (this._standardColor);
		SubTaskInformationPopupView.transform.GetChild(0).GetComponent<Text> ().text = subTask.Title;
		Debug.Log (subTask.Warning);
		SubTaskInformationPopupView.transform.GetChild(1).GetComponent<Text> ().text = subTask.Warning;
		SubTaskInformationPopupView.transform.GetChild(2).GetComponent<Text> ().text = subTask.Information;
	}

	// Use for notification
	public void OpenGeneralPopup(string title, string content){
		_setActivePopupView (GeneralPopupView);
		_setPopupPanelTitle ("Notification");
		_setPopUpPanelColor (this._standardColor);
		GeneralPopupView.transform.FindChild ("Title").GetComponent<Text> ().text = title;
		GeneralPopupView.transform.FindChild ("Content").GetComponent<Text> ().text = content;
	}

	public void OpenErrorPopup(string title, string content){
		_setActivePopupView (GeneralPopupView);
		_setPopupPanelTitle ("Error");
		_setPopUpPanelColor (this._warningColor);
		GeneralPopupView.transform.FindChild ("Title").GetComponent<Text> ().text = title;
		GeneralPopupView.transform.FindChild ("Content").GetComponent<Text> ().text = content;
	}

	private void _setActivePopupView(GameObject popup){
		//_activePopupView.SetActive(false); no need to?
		popup.SetActive(true);
		this.gameObject.SetActive (true);
	}

	private void _setPopupPanelTitle(string s){
		_popUpPanelText.text = s;
	}

	private void _setPopUpPanelColor(Color32 color){
		PopupTopPanel.GetComponent<Image> ().color = color;
		}
}
