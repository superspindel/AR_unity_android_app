using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSubButtonGroup : MonoBehaviour {
	private SimpleObjectPool _subButtonPool;

	public void Setup(List<SubTask> lst, SimpleObjectPool subButtonPool)
	{
		this._subButtonPool = subButtonPool;
		this.AddSubMenus (lst);
	}


	public void AddSubMenus(List<SubTask> lstsub)
	{
		for (int i = 0; i < lstsub.Count; i++)
		{
			SubTask submenu = lstsub [i];
			GameObject subButton = this._subButtonPool.GetObject ();
			subButton.transform.SetParent (this.transform);
			ActiveSubButton subBut = subButton.GetComponent<ActiveSubButton> ();
			subBut.Setup (submenu, this);
		}
	}

	public void RemoveSubs()
	{
		while (this.transform.childCount > 0)
		{
			GameObject toRemove = this.transform.GetChild(0).gameObject;
			this._subButtonPool.ReturnObject(toRemove);
		}
	}
}
