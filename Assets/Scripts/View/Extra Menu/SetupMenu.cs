using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Script for the Extra menu panel, creates the menu when swapping to the panel. 
public class SetupMenu : MonoBehaviour {

	public SimpleObjectPool ButtonGroupPool { get; set; }
	public SimpleObjectPool SubButtonPool { get; set; }
	public SimpleObjectPool MainButtonPool { get; set; }
	public SimpleObjectPool SubMenuGroupPool { get; set; }

	private Pageswapper _pageSwapper;

	private List<MenuGroup> MenuData = new List<MenuGroup> ();

	private Transform group;


	void Awake()
	{
		this._pageSwapper = GameObject.FindWithTag ("Pageswapper").GetComponent<Pageswapper>();
		this.ButtonGroupPool = transform.FindChild ("ButtonGroupPool").GetComponent<SimpleObjectPool> ();
		this.MainButtonPool = transform.FindChild ("MainButtonPool").GetComponent<SimpleObjectPool> ();
		this.SubButtonPool = transform.FindChild ("SubButtonPool").GetComponent<SimpleObjectPool> ();
		this.SubMenuGroupPool = transform.FindChild ("SubMenuGroupPool").GetComponent<SimpleObjectPool> ();
		this.group = transform.FindChild ("Group").transform;
		CreateStandardMenus ();

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

	private void CreateStandardMenus()
	{
		SubMenu one = new SubMenu ("Remote", null);
		SubMenu two = new SubMenu ("AR", null);
		List<SubMenu> list1 = new List<SubMenu> ();
		list1.Add (one);
		list1.Add (two);
		this.MenuData.Add (new MenuGroup ("Support", BadgeDict.GetSprite (4), list1));

		SubMenu three = new SubMenu ("Remote", null);
		SubMenu four = new SubMenu ("AR", null);
		List<SubMenu> list2 = new List<SubMenu> ();
		list2.Add (three);
		list2.Add (four);
		this.MenuData.Add (new MenuGroup ("Account", BadgeDict.GetSprite (3), list2));

		SubMenu five = new SubMenu ("Account", null);
		SubMenu six = new SubMenu ("Application", null);
		List<SubMenu> list3 = new List<SubMenu> ();
		list3.Add (five);
		list3.Add (six);
		this.MenuData.Add (new MenuGroup ("Help", BadgeDict.GetSprite (6), list3));

		SubMenu seven = new SubMenu ("Check", "Leaderboard");
		SubMenu eight = new SubMenu ("Review", "Leaderboard");
		List<SubMenu> list4 = new List<SubMenu> ();
		list4.Add (seven);
		list4.Add (eight);
		this.MenuData.Add (new MenuGroup ("Leaderboard", BadgeDict.GetSprite (10), list4));

	}
}
