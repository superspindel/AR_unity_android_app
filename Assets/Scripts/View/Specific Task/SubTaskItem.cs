using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SubTaskItem : MonoBehaviour {

	private Status 	_status;
	private bool 	_hasTool, _hasHelp, _hasInfo, _hasWarning;
	private bool 	_isBonus;

	private GameObject 	_buttonGroup;
	private Text 		_textField;
	private Toggle 		_progressToggle;
	private Toggle 		_bonusToggle;

	private Button 		_warningButton, _infoButton, _helpButton, _toolButton;

	private Pageswapper _pageSwapper;

	public string Warning, Info;
	public List<Tool> Tools;

	// Use this for initialization
	void Awake () {
		this._buttonGroup 		= this.transform.FindChild ("ButtonGroup").gameObject;
		this._textField 		= this.transform.FindChild ("Name").GetComponent<Text>();
		this._progressToggle 	= this.transform.FindChild ("Toggle").GetComponent<Toggle>();
		this._bonusToggle		= this.transform.FindChild ("Toggle-Bonus").GetComponent<Toggle>();
		this._warningButton 	= this._buttonGroup.transform.FindChild("Warning").GetComponent<Button> ();
		this._infoButton 		= this._buttonGroup.transform.FindChild("Info").GetComponent<Button> ();
		this._helpButton 		= this._buttonGroup.transform.FindChild("Help").GetComponent<Button> ();
		this._toolButton 		= this._buttonGroup.transform.FindChild("Tool").GetComponent<Button> ();

		_progressToggle.onValueChanged.AddListener (toggleListener);
		_bonusToggle.onValueChanged.AddListener (toggleListener);

		// TODO:
		//_warningButton.onClick.AddListener 	(_pageSwapper.dostuff);
		//_infoButton.onClick.AddListener 	(_pageSwapper.dostuff);
		//_helpButton.onClick.AddListener 	(_pageSwapper.dostuff);
		//_toolButton.onClick.AddListener 	(_pageSwapper.dostuff);

		this._pageSwapper = GameObject.Find ("Page Swapper").GetComponent<Pageswapper>();
	}

	// When first enabled
	void Start () {
		refresh ();
	}

	public void setBonus(bool b){
		_isBonus = b;
		refreshBonus ();
	}

	// Sets variables and refresh button grp();
	public void setAvalibeButtons(bool w, bool t, bool i, bool h){
		this._hasWarning = w;
		this._hasTool = t;
		this._hasInfo = i;
		this._hasHelp = h;

		refreshButtonGroup ();
	}

	// Sets title text
	public void setText(string s){
		this._textField.text = s;
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
		this._status = s;
		refreshTextColor ();
		GameObject.Find ("Specific Task View").transform.GetComponent<SpecificTaskView>().refresh ();
	}


	// Refresh UI
	public void refresh(){
		refreshButtonGroup ();
		refreshTextColor ();
	}

	private void refreshButtonGroup (){
		this._buttonGroup.transform.Find ("Tool").gameObject.SetActive (_hasTool);
		this._buttonGroup.transform.Find ("Help").gameObject.SetActive (_hasHelp);
		this._buttonGroup.transform.Find ("Info").gameObject.SetActive (_hasInfo);
		this._buttonGroup.transform.Find ("Warning").gameObject.SetActive (_hasWarning);
	}

	private void refreshTextColor(){
		if (_status == Status.InProgress) {
			this._textField.color = Color.black;
		}
		if (_status == Status.Completed) {
			this._textField.color = Color.green;
		}
		if (_status == Status.Aborted) {
			this._textField.color = Color.red;
		}
	}

	private void refreshBonus(){
		this.transform.FindChild ("Toggle").gameObject.SetActive(!_isBonus);
		this.transform.FindChild ("Toggle-Bonus").gameObject.SetActive(_isBonus);
	}

}
