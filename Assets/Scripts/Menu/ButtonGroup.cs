using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour {
	public List<subMenus> lstsub { get; private set; }
	public SetupMenu setMenu { get; private set; }
	public SimpleObjectPool subButtonPool { get; private set; }
	public SimpleObjectPool mainButtonPool { get; private set; }
	public SimpleObjectPool subButtonGroupPool { get; private set; }
	public GameObject sbtgrp { get; private set; }
	public subButtonGroup sbtgrpscr { get; private set; }

	public void Setup(List<subMenus> lstsub, string title, Sprite icon, SetupMenu setMenu)
	{
		this.lstsub = lstsub;
		this.setMenu = setMenu;
		this.subButtonPool = setMenu.subButtonPool;
		this.mainButtonPool = setMenu.mainButtonPool;
		this.subButtonGroupPool = setMenu.subButtonGroupPool;

		this.addMainButton (title, icon);
		this.addSubMenuGroup ();
		this.toggleSubMenu ();
	}
		

	private void addMainButton(string title, Sprite icon)
	{
		GameObject MainButton = this.mainButtonPool.GetObject ();
		MainButton.transform.SetParent (this.transform);
		mainButton mbut = MainButton.GetComponent<mainButton> ();
		mbut.Setup (title, icon, this);
	}

	private void addSubMenuGroup()
	{
		GameObject subButGrp = this.subButtonGroupPool.GetObject ();
		subButGrp.transform.SetParent (this.transform);
		subButtonGroup sbtg = subButGrp.GetComponent<subButtonGroup> ();
		sbtg.Setup (this.lstsub, this.subButtonPool);
		this.sbtgrp = subButGrp;
		this.sbtgrpscr = sbtgrp.GetComponent<subButtonGroup> ();
	}

	public void toggleSubMenu()
	{
		if (this.sbtgrp.activeSelf) 
		{
			this.sbtgrp.SetActive (false);
			this.sbtgrpscr.removeSubs ();
		} else 
		{
			this.sbtgrp.SetActive (true);
			this.sbtgrpscr.addSubMenus (lstsub);
		}
	}
}
