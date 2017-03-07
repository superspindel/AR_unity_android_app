using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// sub menu class for sub menu objects, its used to setup the prefab buttons.
[System.Serializable]
public class SubMenu {

	public string Title;
	public UnityEngine.Events.UnityAction Target; // possible target for the button to some other panel / for eventhandler

	public SubMenu(string Title, UnityEngine.Events.UnityAction Target)
	{
		this.Title = Title;
		this.Target = Target;
	}

	public void setButton(Button button)
	{
		button.onClick.AddListener (this.Target);
	}
}
