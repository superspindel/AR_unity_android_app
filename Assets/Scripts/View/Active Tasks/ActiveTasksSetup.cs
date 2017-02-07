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

	private List<ActiveTasksGroup> menuGroupList;
	public List<Task> ActiveTaskList;
	public List<SubTask> SubTaskList; //For Debugging
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
			menuGroupPrefab.transform.SetParent (ContentPanel);
			Task activeTask = this.ActiveTaskList [i];
			ActiveButtonGroup btngrp = menuGroupPrefab.GetComponent<ActiveButtonGroup> ();
			btngrp.Setup (SubTaskList, activeTask.Title, this);
		}
	}

	public void RemoveMenu()
	{
		while (ContentPanel.childCount > 0) 
		{
			GameObject toRemove = ContentPanel.GetChild (0).gameObject;
			toRemove.GetComponent<ActiveButtonGroup> ().RemoveMenu ();
			ButtonGroupPool.ReturnObject (toRemove);
		}
	}

	public void Start()
	{
		//this.CreateMenu (); runs twice with this first time
	}

	public void EnterPage(List<Task> tasklist)
	{
		this.gameObject.SetActive (true); // added / emil

		this.ActiveTaskList = tasklist;
		this.ContentPanel.gameObject.SetActive (true);
		CreateMenu ();
	}

	public void LeavePage()
	{
		RemoveMenu ();
		this.ContentPanel.gameObject.SetActive (false);

		this.gameObject.SetActive (true); // added / emil
	}
}
