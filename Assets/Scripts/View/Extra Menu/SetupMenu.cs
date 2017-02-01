using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupMenu : MonoBehaviour {

	public SimpleObjectPool ButtonGroupPool;
	public SimpleObjectPool SubButtonPool;
	public SimpleObjectPool MainButtonPool;
	public SimpleObjectPool SubMenuGroupPool;

	public void createMenu(List<MenuGroup> MenuGroupList)
	{
		foreach (MenuGroup MenuGrp in MenuGroupList)
		{
			GameObject MenuGroupPrefab = this.ButtonGroupPool.GetObject ();
			MenuGroupPrefab.transform.SetParent (this.transform);
			ButtonGroupPref btngrp = MenuGroupPrefab.GetComponent<ButtonGroupPref> ();
			btngrp.Setup (MenuGrp, this);
		}
	}
}
