using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveTaskButton : MonoBehaviour {
	public Text TextField;
	private ActiveButtonGroup _parent;
	public Button Butncmp;
	public Button ArrowButton;
	private int _rotate = -1; // to create toggle behaviour when rotating arrowbutton
	private string _taskId;

	private Pageswapper _pageswapper;

	void Awake(){
		_pageswapper = GameObject.Find ("Page Swapper").GetComponent<Pageswapper> ();
	}
	
	public void Setup(string id, string aTitle, ActiveButtonGroup parent)
	{
		this._taskId = id;
		TextField.text = aTitle;
		this._parent = parent;
		Butncmp.onClick.AddListener (HandleClick);
		ArrowButton.onClick.AddListener (HandleArrowClick);
	}

	public void HandleClick()
	{
		_pageswapper.gotoSpecificTaskPage (this._taskId);
	}

	// Toggles sub menu and rotates arrowbutton
	public void HandleArrowClick()
	{
		this._parent.ToggleSubMenu ();
		_rotate = _rotate * -1;
		this.ArrowButton.transform.Rotate (Vector3.back * 90 * _rotate);
	}
}
