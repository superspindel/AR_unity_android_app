using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Script for the Extra menu panel, creates the menu when swapping to the panel. 
public class SetupMenu : MonoBehaviour {

	public SimpleObjectPool ButtonGroupPool;
	public SimpleObjectPool SubButtonPool;
	public SimpleObjectPool MainButtonPool;
	public SimpleObjectPool SubMenuGroupPool;

	private Pageswapper _pageSwapper;

	public Transform group;

	public List<MenuGroup> MenuData;

	void Awake()
	{
		this._pageSwapper = GameObject.FindWithTag ("Pageswapper").GetComponent<Pageswapper>();
	}

	// Creates a menu with the menu groups in the list. Also calls setup on all groups to instantiate their buttons and sub buttons.
	public void CreateMenu(List<MenuGroup> menuGroupList)
	{
		foreach (MenuGroup menuGrp in menuGroupList)
		{
			GameObject menuGroupPrefab = this.ButtonGroupPool.GetObject ();
			menuGroupPrefab.transform.SetParent (this.group);
			ButtonGroupPref btngrp = menuGroupPrefab.GetComponent<ButtonGroupPref> ();
			btngrp.Setup (menuGrp, this);
		}
	}

	public void EnterPage()
	{
		this.gameObject.SetActive (true);
		CreateMenu (this.GetMenu ());
	}

	public void LeavePage()
	{
		while (this.group.childCount > 0) 
		{
			GameObject toRemove = this.group.GetChild (0).gameObject;
			ButtonGroupPref test = toRemove.transform.GetComponent<ButtonGroupPref> ();
			test.ReturnChildren ();
			ButtonGroupPool.ReturnObject (toRemove);
		}
		this.gameObject.SetActive (false);
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
		if (Settings.application.Leaderboard) 
		{
			Menus.Add (this.MenuData [3]);
		}
		return Menus;
	}
}
