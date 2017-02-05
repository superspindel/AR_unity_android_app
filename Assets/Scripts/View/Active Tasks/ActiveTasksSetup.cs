using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SubTaskMenus
{
	public string Title;// { get; private set; }
	public Transform Target;// { get; private set; }

	public SubTaskMenus(string STitle, Transform STarget)
	{
		this.Title = STitle;
		this.Target = STarget;
	}
}
[System.Serializable]
public class ActiveTasksGroup
{
	public string Title;// { get; private set; }
	public Sprite Icon;// { get; private set; }
	public List<SubTaskMenus> SubMenus;// { get; private set; }

	public ActiveTasksGroup(string ATitle, Sprite AIcon, List<SubTaskMenus> SubMenus)
	{
		this.Title = ATitle;
		this.Icon = AIcon;
		this.SubMenus = SubMenus;
	}
}


public class ActiveTasksSetup : MonoBehaviour {

	public List<ActiveTasksGroup> menuGroupList;
	//public List<Task> ActiveTaskList;
	public SimpleObjectPool buttonGroupPool;
	public SimpleObjectPool subButtonPool;
	public SimpleObjectPool mainButtonPool;
	public SimpleObjectPool subButtonGroupPool;
	public Transform ContentPanel;


	public void CreateMenu()
	{
		for (int i = 0; i < menuGroupList.Count; i++)
		{
			ActiveTasksGroup menuGroup = this.menuGroupList [i];
			GameObject menuGroupPrefab = this.buttonGroupPool.GetObject ();
			menuGroupPrefab.transform.SetParent (this.transform);
			ActiveButtonGroup btngrp = menuGroupPrefab.GetComponent<ActiveButtonGroup> ();
			btngrp.Setup (menuGroup.SubMenus, menuGroup.Title, this);
		}
	}

	public void RemoveMenu()
	{
		
	}

	public void Start()
	{
		this.CreateMenu ();
	}

	public void EnterPage()
	{
		this.ContentPanel.gameObject.SetActive (true);
	}

	public void LeavePage()
	{
		this.ContentPanel.gameObject.SetActive (false);
	}
}
