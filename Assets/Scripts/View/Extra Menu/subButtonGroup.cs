using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subButtonGroup : MonoBehaviour {
	private SimpleObjectPool subButtonPool;

	public void Setup(List<subMenus> lst, SimpleObjectPool subButtonPool)
	{
		this.subButtonPool = subButtonPool;
		this.addSubMenus (lst);
	}


	public void addSubMenus(List<subMenus> lstsub)
	{
		for (int i = 0; i < lstsub.Count; i++)
		{
			subMenus submenu = lstsub [i];
			GameObject subButton = this.subButtonPool.GetObject ();
			subButton.transform.SetParent (this.transform);
			SubButton subBut = subButton.GetComponent<SubButton> ();
			subBut.Setup (submenu.title, submenu.target, this);
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
