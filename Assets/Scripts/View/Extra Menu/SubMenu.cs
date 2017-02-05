using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// sub menu class for sub menu objects, its used to setup the prefab buttons.
public class SubMenu : MonoBehaviour {

	public string Title { get; private set; }
	public Transform Target { get; private set; } // possible target for the button to some other panel / for eventhandler

	public SubMenu(string Title, Transform Target)
	{
		this.Title = Title;
		this.Target = Target;
	}
}
