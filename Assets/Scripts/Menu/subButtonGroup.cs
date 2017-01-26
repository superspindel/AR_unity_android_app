using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subButtonGroup : MonoBehaviour {

	public void Setup(List<subMenus> lst, SimpleObjectPool subButtonPool)
	{
		addSubMenus (lst, subButtonPool);
	}


	private void addSubMenus(List<subMenus> lstsub, SimpleObjectPool subButtonPool)
	{
		for (int i = 0; i < lstsub.Count; i++)
		{
			subMenus submenu = lstsub [i];
			GameObject subButton = subButtonPool.GetObject ();
			subButton.transform.SetParent (this.transform);
			SubButton subBut = subButton.GetComponent<SubButton> ();
			subBut.Setup (submenu.getTitle(), submenu.getTarget(), this);
		}
	}
}
