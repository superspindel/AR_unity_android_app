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

	// Use this for initialization
	void Awake () {
		this.buttonGroup 	= this.transform.FindChild ("ButtonGroup").gameObject;
		this.textField 		= this.transform.FindChild ("Name").GetComponent<Text>();
		this.progressToggle = this.transform.FindChild ("Toggle").GetComponent<Toggle>();
		this.bonusToggle	= this.transform.FindChild ("Toggle-Bonus").GetComponent<Toggle>();

		progressToggle.onValueChanged.AddListener (toggleListener);
		bonusToggle.onValueChanged.AddListener (toggleListener);
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
