﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButtonGroup : MonoBehaviour {
	public List<SubTask> Lstsub { get; private set; }
	public ActiveTasksSetup SetMenu { get; private set; }
	public SimpleObjectPool SubButtonPool { get; private set; }
	public SimpleObjectPool MainButtonPool { get; private set; }
	public SimpleObjectPool SubButtonGroupPool { get; private set; }
	public GameObject Sbtgrp { get; private set; }
	public ActiveSubButtonGroup SubButtonGroupScript { get; private set; }

	private List<GameObject> _itemsFromMainButtonPool;
	private List<GameObject> _itemsFromSubGroupPool;

	void Awake(){
		_itemsFromMainButtonPool = new List<GameObject> ();
		_itemsFromSubGroupPool = new List<GameObject> ();
	}

	public void Setup(List<SubTask> lstsub, string title, ActiveTasksSetup setMenu)
	{
		this.Lstsub = lstsub;
		this.SetMenu = setMenu;
		this.SubButtonPool = setMenu.SubButtonPool;
		this.MainButtonPool = setMenu.MainButtonPool;
		this.SubButtonGroupPool = setMenu.SubButtonGroupPool;

		this.AddMainButton (title);
		this.AddSubMenuGroup ();
		this.ToggleSubMenu ();
	}


	private void AddMainButton(string title)
	{
		GameObject mainButton = this.MainButtonPool.GetObject ();
		_itemsFromMainButtonPool.Add (mainButton);
		mainButton.transform.SetParent (this.transform);
		ActiveTaskButton mbut = mainButton.GetComponent<ActiveTaskButton> ();
		mbut.Setup (title, this);
	}

	private void AddSubMenuGroup()
	{
		GameObject subButGrp = this.SubButtonGroupPool.GetObject ();
		_itemsFromSubGroupPool.Add (subButGrp);
		subButGrp.transform.SetParent (this.transform);
		ActiveSubButtonGroup sbtg = subButGrp.GetComponent<ActiveSubButtonGroup> ();
		sbtg.Setup (this.Lstsub, this.SubButtonPool);
		this.Sbtgrp = subButGrp;
		this.SubButtonGroupScript = Sbtgrp.GetComponent<ActiveSubButtonGroup> ();
	}

	public void RemoveMenu()
	{
		Sbtgrp.GetComponent<ActiveSubButtonGroup> ().RemoveSubs ();
		foreach (GameObject toRemove in _itemsFromSubGroupPool) {
			SubButtonGroupPool.ReturnObject (toRemove);
		}
		foreach (GameObject toRemove in _itemsFromMainButtonPool) {
			MainButtonPool.ReturnObject (toRemove);
		}
	}

	public void ToggleSubMenu()
	{
		if (this.Sbtgrp.activeSelf) 
		{
			this.Sbtgrp.SetActive (false);
			this.SubButtonGroupScript.RemoveSubs ();
		} else 
		{
			this.Sbtgrp.SetActive (true);
			this.SubButtonGroupScript.AddSubMenus (Lstsub);
		}
	}
}
