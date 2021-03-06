﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SubTaskItem : MonoBehaviour {

	public string Warning, Info;
	public List<Tool> Tools;

	private string		_id;
	public Status 		Status;

	public  bool 		IsBonus;
	private bool 		_hasTool, _hasHelp, _hasInfo, _hasWarning;
	private GameObject 	_buttonGroup;
	private Text 		_textField;
	private Toggle 		_regularToggle;
	private Toggle 		_bonusToggle;
	private Button 		_warningButton, _infoButton, _helpButton, _toolButton;

	private SpecificTaskView 	_page;
	private Pageswapper			_pageswapper;


	// Use this for initialization
	void Awake () {
		this._buttonGroup 		= this.transform.FindChild ("ButtonGroup").gameObject;
		this._textField 		= this.transform.FindChild ("Name").GetComponent<Text>();
		this._regularToggle 	= this.transform.FindChild ("Toggle").GetComponent<Toggle>();
		this._bonusToggle		= this.transform.FindChild ("Toggle-Bonus").GetComponent<Toggle>();
		this._warningButton 	= this._buttonGroup.transform.FindChild("Warning").GetComponent<Button> ();
		this._infoButton 		= this._buttonGroup.transform.FindChild("Info").GetComponent<Button> ();
		this._helpButton 		= this._buttonGroup.transform.FindChild("Help").GetComponent<Button> ();
		this._toolButton 		= this._buttonGroup.transform.FindChild("Tool").GetComponent<Button> ();
		this._page 				= GameObject.Find ("Specific Task View").transform.GetComponent<SpecificTaskView> ();
		this._pageswapper 		= GameObject.FindWithTag ("Pageswapper").GetComponent<Pageswapper>();

		_regularToggle.onValueChanged.AddListener (_toggleListener);
		_bonusToggle.onValueChanged.AddListener (_toggleListener);

		// TODO:
		_warningButton.onClick.AddListener 	(_infoListener);
		_infoButton.onClick.AddListener 	(_infoListener);
		//_helpButton.onClick.AddListener 	(_pageSwapper.dostuff);
		//_toolButton.onClick.AddListener 	(_pageSwapper.dostuff);
	}

	// Sets variables and de-/activate buttons
	public void SetAvalibeButtons(bool w, bool t, bool i, bool h){
		this._hasWarning = w;
		this._hasTool = t;
		this._hasInfo = i;
		this._hasHelp = h;

		_toolButton.gameObject.SetActive 	(_hasTool);
		_helpButton.gameObject.SetActive 	(_hasHelp);
		_infoButton.gameObject.SetActive 	(_hasInfo);
		_warningButton.gameObject.SetActive (_hasWarning);
	}

	// Set isBonus and activate the right toggle
	public void SetBonus(bool b){
		this.IsBonus = b;
		this._regularToggle.gameObject.SetActive(!IsBonus);
		this._bonusToggle.gameObject.SetActive	( IsBonus);
	}

	// Sets SubTask Text
	public void SetText(string s){
		this._textField.text = s;
	}

	// Set Status and text color
	public void SetStatus(Status s){
		this.Status = s;
		this._textField.color = _getTextColorByStatus();
		this._page.RefreshProgress ();
	}

	public void SetId(string id){
		this._id = id;
	}

	public void SetPrechecked(Status status){
		if (status == Status.Completed) {
			this._regularToggle.isOn = true;
			this._bonusToggle.isOn = true;
		} else if (status == Status.InProgress) {
			this._regularToggle.isOn = false;
			this._bonusToggle.isOn = false;
		}

	}

	// Listeners
	private void _toggleListener(bool b){
		if (b) {
			this.SetStatus(Status.Completed);
		} else {
			this.SetStatus(Status.InProgress);
		}
	}

	private void _infoListener(){
		_pageswapper.OpenPopup_SubTaskInformation (this._id.ToString());
	}

	// Returns a color depending on subtask status, Magenta = No status
	private Color _getTextColorByStatus(){
		if (Status == Status.InProgress)
			 return Color.black;
		if (Status == Status.Completed)
			return Color.green;
		if (Status == Status.Aborted)
			return Color.red;
		return Color.magenta;
	}
}
