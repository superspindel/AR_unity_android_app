using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class subMenus
{
	public string title;// { get; private set; }
	public Transform target;// { get; private set; }

	public subMenus(string title, Transform target)
	{
		this.title = title;
		this.target = target;
	}
}
[System.Serializable]
public class MenuGroups
{
	public string title;// { get; private set; }
	public Sprite icon;// { get; private set; }
	public List<subMenus> submenus;// { get; private set; }

	public MenuGroups(string title, Sprite icon, List<subMenus> submenus)
	{
		this.title = title;
		this.icon = icon;
		this.submenus = submenus;
	}
}


public class SetupMenu : MonoBehaviour {

	public List<MenuGroups> menuGroupList;
	public SimpleObjectPool buttonGroupPool;
	public SimpleObjectPool subButtonPool;
	public SimpleObjectPool mainButtonPool;
	public SimpleObjectPool subButtonGroupPool;


	public void createMenu()
	{
		for (int i = 0; i < menuGroupList.Count; i++)
		{
			MenuGroups menuGroup = this.menuGroupList [i];
			GameObject menuGroupPrefab = this.buttonGroupPool.GetObject ();
			menuGroupPrefab.transform.SetParent (this.transform);
			ButtonGroup btngrp = menuGroupPrefab.GetComponent<ButtonGroup> ();
			btngrp.Setup (menuGroup.submenus, menuGroup.title, menuGroup.icon, this);
		}
	}

	public void Start()
	{
		this.createMenu ();
	}
}
