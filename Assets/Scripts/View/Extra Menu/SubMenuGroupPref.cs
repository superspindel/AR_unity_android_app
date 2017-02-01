using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuGroupPref : MonoBehaviour {
	
	private SimpleObjectPool SubButtonPool;

	public void Setup(List<SubMenu> SubMenuList, SimpleObjectPool SubButtonPool)
	{
		this.SubButtonPool = SubButtonPool;
		this.AddSubMenus (SubMenuList);
	}


	public void AddSubMenus(List<SubMenu> SubMenuList)
	{
		foreach (SubMenu SbMenu in SubMenuList)
		{
			GameObject subButton = this.SubButtonPool.GetObject ();
			subButton.transform.SetParent (this.transform);
			SubButtonPref subBut = subButton.GetComponent<SubButtonPref> ();
			subBut.Setup (SbMenu, this);
		}
	}

	public void RemoveSubs()
	{
		while (this.transform.childCount > 0)
		{
			GameObject toRemove = this.transform.GetChild(0).gameObject;
			this.SubButtonPool.ReturnObject(toRemove);
		}
	}
}
