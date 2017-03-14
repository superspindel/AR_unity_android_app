using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Prefab configuration for the buttongroup containing the main button and its sub buttons.
public class ButtonGroupPref : Prefab {
	public List<SubMenu> SubMenuList { get; set; }
	public SetupMenu SetMenu { get; set; } // The parent setup menu that its created inside, if need be.
	public SimpleObjectPool SubButtonPool { get; set; }
	public SimpleObjectPool MainButtonPool { get; set; }
	public SimpleObjectPool SubMenuGroupPool { get; set; }
	public GameObject SubMenugrp { get; set; } // The Gameobject that will contain the group of sub buttons
	public SubMenuGroupPref SubMenuGroupScript { get; set; } // The script of the sub menu group


	// Setup will instantiate the variables above and create the main button, sub menu group and toggle off the submenu. 
	// Input is a MenuGroup that contains the information for the main button aswell as the list of sub buttons.
	// Input is also a the parent Setup menu that contains the pools for the objects to be created.
	public void Setup(MenuGroup menuGrp, SetupMenu setMenu)
	{
		this.SubMenuList = menuGrp.SubMenus;
		this.SetMenu = setMenu;
		this.SubButtonPool = setMenu.SubButtonPool;
		this.MainButtonPool = setMenu.MainButtonPool;
		this.SubMenuGroupPool = setMenu.SubMenuGroupPool;

		this.AddMainButton (menuGrp.Title, menuGrp.Icon);
		this.AddSubMenuGroup ();
		this.ToggleSubMenu ();
	}

	// Creates the Main button
	// Input is the Title of the button aswell as the icon for the button.
	private void AddMainButton(string title, Sprite icon)
	{
		GameObject mainButton = this.MainButtonPool.GetObject ();
		mainButton.transform.SetParent (this.transform);
		MainButtonPref mBut = mainButton.GetComponent<MainButtonPref> ();
		mBut.Setup (title, icon, this);
	}
	// Creates the sub menu group, and also calls setup on that gameobjects script to create the buttons within the group.
	private void AddSubMenuGroup()
	{
		this.SubMenugrp = this.SubMenuGroupPool.GetObject ();
		this.SubMenugrp.transform.SetParent (this.transform);
		this.SubMenuGroupScript = this.SubMenugrp.GetComponent<SubMenuGroupPref> ();
		SubMenuGroupScript.Setup (this.SubMenuList, this.SubButtonPool);
	}
	// Script to toggle the sub menu group and display the buttons within the group. 
	// Function gets called from the main button when clicked.
	public void ToggleSubMenu()
	{
		if (this.SubMenugrp.activeSelf) 
		{
			this.SubMenugrp.SetActive (false);
			this.SubMenuGroupScript.ReturnChildren ();
		} else 
		{
			this.SubMenugrp.SetActive (true);
			this.SubMenuGroupScript.AddSubMenus (SubMenuList);
		}
	}

	public override void ReturnChildren()
	{
		while (this.transform.childCount > 0) 
		{
			GameObject toRemove = this.transform.GetChild (0).gameObject;
			PooledObject script = toRemove.GetComponent<PooledObject> ();
			if (script.Pool == MainButtonPool) {
				MainButtonPool.ReturnObject (toRemove);
			} 
			else 
			{
				toRemove.GetComponent<Prefab> ().ReturnChildren ();
				SubMenuGroupPool.ReturnObject (toRemove);
			}
		}
	}
}
