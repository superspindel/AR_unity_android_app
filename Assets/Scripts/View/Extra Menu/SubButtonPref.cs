using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Script for sub button prefab. Setup for the gameobject to set the variables.
public class SubButtonPref : MonoBehaviour {

	public Text TextField;
	private SubMenuGroupPref _parentGroup;
	private Pageswapper _pageswapper;
	private Button _Button;

	// Setup for sub button prefab. Takes a sub menu object that contains the information and the script of the parent sub menu group.
	public void Setup(SubMenu sbMenu, SubMenuGroupPref parent)
	{
		this.TextField.text = sbMenu.Title;
		this._parentGroup = parent;
		this._pageswapper 		= GameObject.FindWithTag ("Pageswapper").GetComponent<Pageswapper>();
		this._Button = transform.GetComponent<Button> ();
		this._Button.onClick.RemoveAllListeners ();
		if (sbMenu.Target == "Leaderboard") 
		{
			this._Button.onClick.AddListener (this._pageswapper.GoToLeaderboardPage);
		}
	}

	// TODO: 	onClick event to enter the settings view of this sub button.


}
