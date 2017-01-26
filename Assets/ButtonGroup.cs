using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroup : MonoBehaviour {
	public Text TextField;
	public Image icon;
	public List<subMenus> lstsub;
	private SetupMenu setMenu;
	public SimpleObjectPool subButtonPool;

	public void Setup(List<subMenus> lstsub, string title, Sprite icon, SetupMenu setMenu)
	{
		this.lstsub = lstsub;
		this.TextField.text = title;
		this.icon.sprite = icon;
		this.setMenu = setMenu;
		addSubMenus ();
	}

	private void addSubMenus()
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
