using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public enum PopUpType{general, startup, tools, reward};

public class PopUp : MonoBehaviour {
	
	public GameObject 	StartupRoutinePopupView, GeneralPopupView, SubTaskInformationPopupView, PopupTopPanel;
	//private GameObject 	_activePopupView; 

	private Button 		_exitButton;
	private Pageswapper _pageswapper;
	private Text 		_popUpPanelText;

	void Awake(){
		_pageswapper = GameObject.Find ("Page Swapper").GetComponent<Pageswapper> ();
		this._popUpPanelText = this.PopupTopPanel.transform.FindChild ("Title").GetComponent<Text> ();

		// exit button
		this._exitButton = PopupTopPanel.transform.FindChild("ExitButton").GetComponent<Button> ();
		_exitButton.onClick.AddListener (_pageswapper.LeavePopup);
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
		SubTaskInformationPopupView.transform.GetChild(0).GetComponent<Text> ().text = subTask.Title;
		SubTaskInformationPopupView.transform.GetChild(1).GetComponent<Text> ().text = subTask.Warning;
		SubTaskInformationPopupView.transform.GetChild(2).GetComponent<Text> ().text = subTask.Information;
	}

	// Use for notification
	public void OpenGeneralPopup(string title, string content){
		_setActivePopupView (GeneralPopupView);
		_setPopupPanelTitle ("Notification");
		GeneralPopupView.transform.FindChild ("Title").GetComponent<Text> ().text = title;
		GeneralPopupView.transform.FindChild ("Content").GetComponent<Text> ().text = content;
	}

	private void _setActivePopupView(GameObject popup){
		//_activePopupView.SetActive(false);
		popup.SetActive(true);
	}

	private void _setPopupPanelTitle(string s){
		_popUpPanelText.text = s;
	}
}
