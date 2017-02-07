using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that contains the data for the different menu options. Is used to create buttons in the extra menu with sub buttons.
[System.Serializable]
public class MenuGroup {

	public string Title;
	public Sprite Icon;
	public List<SubMenu> SubMenus;

	public MenuGroup(string title, Sprite icon, List<SubMenu> subMenus)
	{
		this.Title = title;
		this.Icon = icon;
		this.SubMenus = subMenus;
	}
}
