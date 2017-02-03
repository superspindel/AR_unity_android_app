using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script for the Extra menu panel, creates the menu when swapping to the panel. 
public class SetupMenu : MonoBehaviour {

	public SimpleObjectPool ButtonGroupPool;
	public SimpleObjectPool SubButtonPool;
	public SimpleObjectPool MainButtonPool;
	public SimpleObjectPool SubMenuGroupPool;

	// Creates a menu with the menu groups in the list. Also calls setup on all groups to instantiate their buttons and sub buttons.
	public void createMenu(List<MenuGroup> MenuGroupList)
	{
		foreach (MenuGroup MenuGrp in MenuGroupList)
		{
			GameObject MenuGroupPrefab = this.ButtonGroupPool.GetObject ();
			MenuGroupPrefab.transform.SetParent (this.transform);
			ButtonGroupPref btngrp = MenuGroupPrefab.GetComponent<ButtonGroupPref> ();
			btngrp.Setup (MenuGrp, this);
		}
	}

	public void EnterPage()
	{
		// read settings page
	}

	public void LeavePage()
	{
		while (this.transform.childCount > 0) 
		{
			GameObject ToRemove = this.transform.GetChild (0).gameObject;
			ToRemove.GetComponent<ButtonGroupPref> ().ReturnChildren ();
		}
	}

	public void UpdatePage()
	{
		
	}

	// TODO: 	Function for leavePage, go through each object and return them to the pool.
	// 			Also, Get data from some settings or create a base MenuGroup to show always.
}
