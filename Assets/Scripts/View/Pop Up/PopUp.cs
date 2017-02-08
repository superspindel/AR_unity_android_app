using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public enum PopUpType{General, Startup, Tools, Reward};

public class PopUp : MonoBehaviour {

	[Header("PopUp Content Panel in ScrollView")]
	public  GameObject	PopUpContentPanel; 
	private GameObject 	_startupRoutinePopupView, 
						_generalPopupView, 
						_subTaskInformationPopupView, 
						_popupTopPanel;
	//private GameObject 	_activePopupView; 

	private Button 		_exitButton;
	private Pageswapper _pageswapper;
	private Text 		_popUpPanelText;
	private Color		_standardColor;
	private Color 		_warningColor;

	void Awake(){
		_startupRoutinePopupView 		= PopUpContentPanel.transform.FindChild("StartupPopupView").gameObject; 
		_generalPopupView 				= PopUpContentPanel.transform.FindChild("GeneralPopupView").gameObject;
		_subTaskInformationPopupView	= PopUpContentPanel.transform.FindChild("SubTaskInformationPopupView").gameObject;
		_popupTopPanel					= transform.FindChild("Background").FindChild("Top Panel").gameObject;

		_pageswapper = GameObject.Find ("Page Swapper").GetComponent<Pageswapper> ();
		this._popUpPanelText = _popupTopPanel.transform.FindChild ("Title").GetComponent<Text> ();

		// exit button
		this._exitButton = _popupTopPanel.transform.FindChild("ExitButton").GetComponent<Button> ();
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
		_setActivePopupView(_subTaskInformationPopupView);
		_setPopupPanelTitle("Information");
		_setPopUpPanelColor (this._standardColor);
		_subTaskInformationPopupView.transform.GetChild(0).GetComponent<Text> ().text = subTask.Title;
		Debug.Log (subTask.Warning);
		_subTaskInformationPopupView.transform.GetChild(1).GetComponent<Text> ().text = subTask.Warning;
		_subTaskInformationPopupView.transform.GetChild(2).GetComponent<Text> ().text = subTask.Information;
	}

	// Use for notification
	public void OpenGeneralPopup(string title, string content){
		_setActivePopupView (_generalPopupView);
		_setPopupPanelTitle ("Notification");
		_setPopUpPanelColor (this._standardColor);
		_generalPopupView.transform.FindChild ("Title").GetComponent<Text> ().text = title;
		_generalPopupView.transform.FindChild ("Content").GetComponent<Text> ().text = content;
	}

	public void OpenErrorPopup(string title, string content){
		_setActivePopupView (_generalPopupView);
		_setPopupPanelTitle ("Error");
		_setPopUpPanelColor (this._warningColor);
		_generalPopupView.transform.FindChild ("Title").GetComponent<Text> ().text = title;
		_generalPopupView.transform.FindChild ("Content").GetComponent<Text> ().text = content;
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
		_popupTopPanel.GetComponent<Image> ().color = color;
		}
}
