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

	public List<MenuGroup> MenuData;


	// Creates a menu with the menu groups in the list. Also calls setup on all groups to instantiate their buttons and sub buttons.
	public void CreateMenu(List<MenuGroup> menuGroupList)
	{
		foreach (MenuGroup menuGrp in menuGroupList)
		{
			// TODO: Check MenuGrp.Available
			GameObject menuGroupPrefab = this.ButtonGroupPool.GetObject ();
			menuGroupPrefab.transform.SetParent (this.transform);
			ButtonGroupPref btngrp = menuGroupPrefab.GetComponent<ButtonGroupPref> ();
			btngrp.Setup (menuGrp, this);
		}
	}

	void Start()
	{
		//EnterPage ();
	}

	void FixedUpdate()
	{
		Settings.SaveFile ();
	}

	public void EnterPage()
	{
		this.gameObject.SetActive (true);
		CreateMenu (this.GetMenu ());
	}

	public void LeavePage()
	{
		while (this.transform.childCount > 0) 
		{
			GameObject toRemove = this.transform.GetChild (0).gameObject;
			toRemove.GetComponent<ButtonGroupPref> ().ReturnChildren ();
		}
	}

	public void UpdatePage()
	{
		this.LeavePage ();
		this.EnterPage ();
	}

	private List<MenuGroup> GetMenu()
	{
		List<MenuGroup> Menus = new List<MenuGroup> ();
		if (Settings.application.Account) 
		{
			Menus.Add (this.MenuData [0]);
		}
		if (Settings.application.Help) 
		{
			Menus.Add (this.MenuData [1]);
		}
		if (Settings.application.Remote) 
		{
			Menus.Add (this.MenuData [2]);
		}
		return Menus;
	}
	// TODO: 	Function for leavePage, go through each object and return them to the pool.
	// 			Also, Get data from some settings or create a base MenuGroup to show always.
}
