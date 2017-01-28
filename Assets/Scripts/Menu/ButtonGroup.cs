using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour {
	private List<subMenus> lstsub;
	private SetupMenu setMenu;
	private SimpleObjectPool subButtonPool;
	private SimpleObjectPool mainButtonPool;
	private SimpleObjectPool subButtonGroupPool;
	private GameObject sbtgrp;
	private subButtonGroup sbtgrpscr;

	public void Setup(List<subMenus> lstsub, string title, Sprite icon, SetupMenu setMenu)
	{
		this.lstsub = lstsub;
		this.setMenu = setMenu;
		this.subButtonPool = setMenu.subButtonPool;
		this.mainButtonPool = setMenu.mainButtonPool;
		this.subButtonGroupPool = setMenu.subButtonGroupPool;

		addMainButton (title, icon);
		addSubMenuGroup ();
		toggleSubMenu ();
	}
		

	private void addMainButton(string title, Sprite icon)
	{
		GameObject MainButton = mainButtonPool.GetObject ();
		MainButton.transform.SetParent (this.transform);
		mainButton mbut = MainButton.GetComponent<mainButton> ();
		mbut.Setup (title, icon, this);
	}

	private void addSubMenuGroup()
	{
		GameObject subButGrp = subButtonGroupPool.GetObject ();
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
