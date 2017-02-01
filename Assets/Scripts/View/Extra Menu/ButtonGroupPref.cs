using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupPref : MonoBehaviour {
	public List<SubMenu> SubMenuList { get; set; }
	public SetupMenu SetMenu { get; set; }
	public SimpleObjectPool SubButtonPool { get; set; }
	public SimpleObjectPool MainButtonPool { get; set; }
	public SimpleObjectPool SubButtonGroupPool { get; set; }
	public GameObject SubMenugrp { get; set; }
	public SubMenuGroupPref SubMenuGroupScript { get; set; }

	public void Setup(MenuGroup MenuGrp, SetupMenu SetMenu)
	{
		this.SubMenuList = MenuGrp.SubMenus;
		this.SetMenu = SetMenu;
		this.SubButtonPool = SetMenu.SubButtonPool;
		this.MainButtonPool = SetMenu.MainButtonPool;
		this.SubButtonGroupPool = SetMenu.SubButtonGroupPool;

		this.AddMainButton (MenuGrp.Title, MenuGrp.Icon);
		this.AddSubMenuGroup ();
		this.ToggleSubMenu ();
	}
		

	private void AddMainButton(string Title, Sprite Icon)
	{
		GameObject MainButton = this.MainButtonPool.GetObject ();
		MainButton.transform.SetParent (this.transform);
		MainButtonPref MBut = MainButton.GetComponent<MainButtonPref> ();
		MBut.Setup (Title, Icon, this);
	}

	private void AddSubMenuGroup()
	{
		this.SubMenugrp = this.SubButtonGroupPool.GetObject ();
		this.SubMenugrp.transform.SetParent (this.transform);
		this.SubMenuGroupScript = this.SubMenugrp.GetComponent<SubMenuGroupPref> ();
		SubMenuGroupScript.Setup (this.SubMenuList, this.SubButtonPool);
	}

	public void ToggleSubMenu()
	{
		if (this.SubMenugrp.activeSelf) 
		{
			this.SubMenugrp.SetActive (false);
			this.SubMenuGroupScript.RemoveSubs ();
		} else 
		{
			this.SubMenugrp.SetActive (true);
			this.SubMenuGroupScript.AddSubMenus (SubMenuList);
		}
	}
}
