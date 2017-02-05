using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for sub button prefab. Setup for the gameobject to set the variables.
public class SubButtonPref : MonoBehaviour {
	public Text TextField;
	private Transform Target;
	private SubMenuGroupPref ParentGroup;

	// Setup for sub button prefab. Takes a sub menu object that contains the information and the script of the parent sub menu group.
	public void Setup(SubMenu SbMenu, SubMenuGroupPref Parent)
	{
		this.TextField.text = SbMenu.Title;
		this.Target = SbMenu.Target;
		this.ParentGroup = Parent;
	}

	// TODO: 	onClick event to enter the settings view of this sub button.


}
