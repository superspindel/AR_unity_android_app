using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainButton : MonoBehaviour {
	public Text textField;
	public Image imageIcon;
	private ButtonGroup parent;
	public Button butncmp;

	public void Setup(string title, Sprite icon, ButtonGroup parent)
	{
		imageIcon.sprite = icon;
		textField.text = title;
		this.parent = parent;
		butncmp.onClick.AddListener (handleClick);
	}

	public void handleClick()
	{
		this.parent.toggleSubMenu ();
	}
}
