using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveTaskButton : MonoBehaviour {
	public Text TextField;
	private ActiveButtonGroup Parent;
	public Button Butncmp;
	public Button ArrowButton;
	private int rotate = -1; // to create toggle behaviour when rotating arrowbutton
	
	public void Setup(string ATitle, ActiveButtonGroup Parent)
	{
		TextField.text = ATitle;
		this.Parent = Parent;
		Butncmp.onClick.AddListener (handleClick);
		ArrowButton.onClick.AddListener (HandleArrowClick);
	}

	public void handleClick()
	{
		//GameObject.Find ("Page Swapper").GetComponent<Pageswapper> ().gotoSpecificTaskPage ();
		//TODO: show specific task view
	}

	// Toggles sub menu and rotates arrowbutton
	public void HandleArrowClick()
	{
		this.Parent.ToggleSubMenu ();
		rotate = rotate * -1;
		this.ArrowButton.transform.Rotate (Vector3.back * 90 * rotate);
	}
}
