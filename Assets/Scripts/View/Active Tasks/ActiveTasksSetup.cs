﻿using System.Collections;
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

	private List<ActiveTasksGroup> menuGroupList;
	private List<Task> ActiveTaskList;
	public SimpleObjectPool ButtonGroupPool;
	public SimpleObjectPool SubButtonPool;
	public SimpleObjectPool MainButtonPool;
	public SimpleObjectPool SubButtonGroupPool;
	public Transform ContentPanel;


	public void CreateMenu()
	{
		for (int i = 0; i < ActiveTaskList.Count; i++)
		{
			//ActiveTasksGroup menuGroup = this.menuGroupList [i];
			GameObject menuGroupPrefab = this.ButtonGroupPool.GetObject ();
			menuGroupPrefab.transform.SetParent (this.transform);
			Task activeTask = this.ActiveTaskList [i];
			ActiveButtonGroup btngrp = menuGroupPrefab.GetComponent<ActiveButtonGroup> ();
			btngrp.Setup (activeTask.SubTasks, activeTask.Title, this);
		}
	}

	public void RemoveMenu()
	{
		
	}

	public void Start()
	{
		this.CreateMenu ();
	}

	public void EnterPage(List<Task> tasklist)
	{
		this.ActiveTaskList = tasklist;
		this.ContentPanel.gameObject.SetActive (true);
	}

	public void LeavePage()
	{
		this.ContentPanel.gameObject.SetActive (false);
	}
}
