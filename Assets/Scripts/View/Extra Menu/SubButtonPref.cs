using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubButtonPref : MonoBehaviour {
	public Text TextField;
	private Transform Target;
	private SubMenuGroupPref ParentGroup;

	public void Setup(SubMenu SbMenu, SubMenuGroupPref Parent)
	{
		this.TextField.text = SbMenu.Title;
		this.Target = SbMenu.Target;
		this.ParentGroup = Parent;
	}


}
