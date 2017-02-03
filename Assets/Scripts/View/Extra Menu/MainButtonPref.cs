using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtonPref : MonoBehaviour {
	public Text TextField;
	public Image ImageIcon;
	private ButtonGroupPref Parent;
	public Button Butncmp;

	public void Setup(string Title, Sprite Icon, ButtonGroupPref Parent)
	{
		ImageIcon.sprite = Icon;
		TextField.text = Title;
		this.Parent = Parent;
		Butncmp.onClick.AddListener (HandleClick);
	}

	public void HandleClick()
	{
		this.Parent.ToggleSubMenu ();
	}
}
