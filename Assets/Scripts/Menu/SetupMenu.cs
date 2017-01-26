using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class subMenus
{
	public string title;
	public Transform target;

	public subMenus(string title, Transform target)
	{
		this.title = title;
		this.target = target;
	}

	public string getTitle()
	{
		return title;
	}

	public Transform getTarget()
	{
		return target;
	}
}
[System.Serializable]
public class MenuGroups
{
	public string title;
	public Sprite icon;
	public List<subMenus> submenus;

	public MenuGroups(string title, Sprite icon, List<subMenus> submenus)
	{
		this.title = title;
		this.icon = icon;
		this.submenus = submenus;
	}

	public string getTitle()
	{
		return title;
	}

	public List<subMenus> getSubMenus()
	{
		return submenus;
	}
	public Sprite getIcon()
	{
		return icon;
	}
}


public class SetupMenu : MonoBehaviour {

	public List<MenuGroups> menuGroupList;
	public SimpleObjectPool buttonGroupPool;


	public void createMenu()
	{
		for (int i = 0; i < menuGroupList.Count; i++)
		{
			MenuGroups menuGroup = menuGroupList [i];
			GameObject menuGroupPrefab = buttonGroupPool.GetObject ();
			menuGroupPrefab.transform.SetParent (this.transform);
			ButtonGroup btngrp = menuGroupPrefab.GetComponent<ButtonGroup> ();
			btngrp.Setup (menuGroup.getSubMenus(), menuGroup.getTitle(), menuGroup.getIcon(), this);
		}
	}
}
