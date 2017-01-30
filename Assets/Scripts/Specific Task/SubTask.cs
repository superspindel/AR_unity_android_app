using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public enum Status{InProgress, Completed, Aborted};

public class SubTask : MonoBehaviour {

	public Status status;
	public bool hasTool, hasHelp, hasInfo, hasWarning;
	public bool isBonus;

	private GameObject buttonGroup;
	private Text textField;
	private Toggle progressToggle;
	private Toggle bonusToggle;

	private Button warningButton, infoButton, helpButton, toolButton;

	private PopUp popup;

	public string warning, info;
	public List<Tool> tools;

	// Use this for initialization
	void Awake () {
		this.buttonGroup 	= this.transform.FindChild ("ButtonGroup").gameObject;
		this.textField 		= this.transform.FindChild ("Name").GetComponent<Text>();
		this.progressToggle = this.transform.FindChild ("Toggle").GetComponent<Toggle>();
		this.bonusToggle	= this.transform.FindChild ("Toggle-Bonus").GetComponent<Toggle>();
		this.warningButton 	= this.buttonGroup.transform.FindChild("Warning").GetComponent<Button> ();
		this.infoButton 	= this.buttonGroup.transform.FindChild("Info").GetComponent<Button> ();
		this.helpButton 	= this.buttonGroup.transform.FindChild("Help").GetComponent<Button> ();
		this.toolButton 	= this.buttonGroup.transform.FindChild("Tool").GetComponent<Button> ();
		this.popup 			= GameObject.Find ("Canvas").GetComponent<CanvasObjects> ().popup.GetComponent<PopUp> ();

		progressToggle.onValueChanged.AddListener (toggleListener);
		bonusToggle.onValueChanged.AddListener (toggleListener);

		warningButton.onClick.AddListener (warningListener);
		infoButton.onClick.AddListener (infoListener);
		helpButton.onClick.AddListener (helpListener);
		toolButton.onClick.AddListener (toolListener);
	}

	// When first enabled
	void Start () {
		refresh ();
	}

	public void setBonus(bool b){
		isBonus = b;
		refreshBonus ();
	}

	// Sets variables and refresh button grp();
	public void setAvalibeButtons(bool w, bool t, bool i, bool h){
		this.hasWarning = w;
		this.hasTool = t;
		this.hasInfo = i;
		this.hasHelp = h;

		refreshButtonGroup ();
	}

	// Sets title text
	public void setText(string s){
		this.textField.text = s;
	}

	public void toggleListener(bool b){
		if (b) {
			setStatus(Status.Completed);
		} else {
			setStatus(Status.InProgress);
		}
	}

	// when warning icon is clicked
	public void warningListener(){
		this.popup.enterPopup(PopUpType.general, "Warning!", "Warning:", this.warning);
	}

	// when warning icon is clicked
	public void infoListener(){
		this.popup.enterPopup(PopUpType.general, "Information!", "Information:", this.info);
	}

	// when warning icon is clicked
	public void helpListener(){
		this.popup.enterPopup(PopUpType.general, "Help!", "Help:", "HELP");
	}

	public void toolListener(){
		this.popup.enterPopup(PopUpType.general, "Tools!", "Tools:", "TOOLS");
	}

	// Status
	public void setStatus(Status s){
		this.status = s;
		refreshTextColor ();
		GameObject.Find ("Specific Task View").transform.GetComponent<SpecificTaskView>().refresh ();
	}


	// Refresh UI
	public void refresh(){
		refreshButtonGroup ();
		refreshTextColor ();
	}

	private void refreshButtonGroup (){
		this.buttonGroup.transform.Find ("Tool").gameObject.SetActive (hasTool);
		this.buttonGroup.transform.Find ("Help").gameObject.SetActive (hasHelp);
		this.buttonGroup.transform.Find ("Info").gameObject.SetActive (hasInfo);
		this.buttonGroup.transform.Find ("Warning").gameObject.SetActive (hasWarning);
	}

	private void refreshTextColor(){
		if (status == Status.InProgress) {
			this.textField.color = Color.black;
		}
		if (status == Status.Completed) {
			this.textField.color = Color.green;
		}
		if (status == Status.Aborted) {
			this.textField.color = Color.red;
		}
	}

	private void refreshBonus(){
		this.transform.FindChild ("Toggle").gameObject.SetActive(!isBonus);
		this.transform.FindChild ("Toggle-Bonus").gameObject.SetActive(isBonus);
	}
}
