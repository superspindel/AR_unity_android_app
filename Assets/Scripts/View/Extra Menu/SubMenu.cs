using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// sub menu class for sub menu objects, its used to setup the prefab buttons.
[System.Serializable]
public class SubMenu {

	public string Title;
	public string Target; // possible target for the button to some other panel / for eventhandler

	public SubMenu(string title, string target)
	{
		this.Title = title;
		this.Target = target;
	}
}
