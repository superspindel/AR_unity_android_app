using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSubButtonGroup : MonoBehaviour {
	private SimpleObjectPool subButtonPool;

	public void Setup(List<SubTaskMenus> lst, SimpleObjectPool subButtonPool)
	{
		this.subButtonPool = subButtonPool;
		this.AddSubMenus (lst);
	}


	public void AddSubMenus(List<SubTaskMenus> lstsub)
	{
		for (int i = 0; i < lstsub.Count; i++)
		{
			SubTaskMenus Submenu = lstsub [i];
			GameObject SubButton = this.subButtonPool.GetObject ();
			SubButton.transform.SetParent (this.transform);
			ActiveSubButton SubBut = SubButton.GetComponent<ActiveSubButton> ();
			SubBut.Setup (Submenu.Title, Submenu.Target, this);
		}
	}

	public void removeSubs()
	{
		while (this.transform.childCount > 0)
		{
			GameObject toRemove = this.transform.GetChild(0).gameObject;
			this.subButtonPool.ReturnObject(toRemove);
		}
	}
}
