using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButtonGroup : MonoBehaviour {
	public List<SubTaskMenus> lstsub { get; private set; }
	public ActiveTasksSetup setMenu { get; private set; }
	public SimpleObjectPool subButtonPool { get; private set; }
	public SimpleObjectPool mainButtonPool { get; private set; }
	public SimpleObjectPool subButtonGroupPool { get; private set; }
	public GameObject sbtgrp { get; private set; }
	public ActiveSubButtonGroup SubButtonGroupScript { get; private set; }

	public void Setup(List<SubTaskMenus> lstsub, string Title, ActiveTasksSetup setMenu)
	{
		this.lstsub = lstsub;
		this.setMenu = setMenu;
		this.subButtonPool = setMenu.subButtonPool;
		this.mainButtonPool = setMenu.mainButtonPool;
		this.subButtonGroupPool = setMenu.subButtonGroupPool;

		this.AddMainButton (Title);
		this.AddSubMenuGroup ();
		this.ToggleSubMenu ();
	}


	private void AddMainButton(string title)
	{
		GameObject MainButton = this.mainButtonPool.GetObject ();
		MainButton.transform.SetParent (this.transform);
		ActiveTaskButton mbut = MainButton.GetComponent<ActiveTaskButton> ();
		mbut.Setup (title, this);
	}

	private void AddSubMenuGroup()
	{
		GameObject subButGrp = this.subButtonGroupPool.GetObject ();
		subButGrp.transform.SetParent (this.transform);
		ActiveSubButtonGroup sbtg = subButGrp.GetComponent<ActiveSubButtonGroup> ();
		sbtg.Setup (this.lstsub, this.subButtonPool);
		this.sbtgrp = subButGrp;
		this.SubButtonGroupScript = sbtgrp.GetComponent<ActiveSubButtonGroup> ();
	}

	public void ToggleSubMenu()
	{
		if (this.sbtgrp.activeSelf) 
		{
			this.sbtgrp.SetActive (false);
			this.SubButtonGroupScript.removeSubs ();
		} else 
		{
			this.sbtgrp.SetActive (true);
			this.SubButtonGroupScript.AddSubMenus (lstsub);
		}
	}
}
