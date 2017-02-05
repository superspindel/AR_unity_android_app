using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SubTaskMenus
{
	public string Title;// { get; private set; }
	public Transform Target;// { get; private set; }

	public SubTaskMenus(string sTitle, Transform sTarget)
	{
		this.Title = sTitle;
		this.Target = sTarget;
	}
}
[System.Serializable]
public class ActiveTasksGroup
{
	public string Title;// { get; private set; }
	public Sprite Icon;// { get; private set; }
	public List<SubTaskMenus> SubMenus;// { get; private set; }

	public ActiveTasksGroup(string aTitle, Sprite aIcon, List<SubTaskMenus> subMenus)
	{
		this.Title = aTitle;
		this.Icon = aIcon;
		this.SubMenus = subMenus;
	}
}


public class ActiveTasksSetup : MonoBehaviour {

	public List<ActiveTasksGroup> MenuGroupList;
	public SimpleObjectPool ButtonGroupPool;
	public SimpleObjectPool SubButtonPool;
	public SimpleObjectPool MainButtonPool;
	public SimpleObjectPool SubButtonGroupPool;



	public void CreateMenu()
	{
		for (int i = 0; i < MenuGroupList.Count; i++)
		{
			ActiveTasksGroup menuGroup = this.MenuGroupList [i];
			GameObject menuGroupPrefab = this.ButtonGroupPool.GetObject ();
			menuGroupPrefab.transform.SetParent (this.transform);
			ActiveButtonGroup btngrp = menuGroupPrefab.GetComponent<ActiveButtonGroup> ();
			btngrp.Setup (menuGroup.SubMenus, menuGroup.Title, this);
		}
	}

	public void Start()
	{
		this.CreateMenu ();
	}
}
