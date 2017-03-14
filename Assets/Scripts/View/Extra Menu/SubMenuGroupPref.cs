using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Sub menu group prefab script, for setup of the group by adding the sub menus 
// and possibly removing the sub menus by returning them to the pool.
public class SubMenuGroupPref : Prefab {
	
	private SimpleObjectPool _subButtonPool;

	// Setup, takes a list of sub menus and a pool to get the button objects from.
	// Runs the add sub menus function that creates the sub buttons.
	public void Setup(List<SubMenu> subMenuList, SimpleObjectPool subButtonPool)
	{
		this._subButtonPool = subButtonPool;
		this.AddSubMenus (subMenuList);
	}

	// AddSubMenus takes a list of the sub menus to be created and instantiates the objects and adds them to the scene from the pool.
	public void AddSubMenus(List<SubMenu> subMenuList)
	{
		foreach (SubMenu sbMenu in subMenuList)
		{
			GameObject subButton = this._subButtonPool.GetObject ();
			subButton.transform.SetParent (this.transform);
			SubButtonPref subBut = subButton.GetComponent<SubButtonPref> ();
			subBut.Setup (sbMenu, this);
		}
	}
	// RemoveSubs goes through the group object and returns all the children objects to the pool, the sub buttons.
	public override void ReturnChildren()
	{
		while (this.transform.childCount > 0)
		{
			GameObject toRemove = this.transform.GetChild(0).gameObject;
			this._subButtonPool.ReturnObject(toRemove);
		}
	}
}
