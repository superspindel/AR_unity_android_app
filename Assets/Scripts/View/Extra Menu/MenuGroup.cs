using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGroup {

	public string Title { get; set; }
	public Sprite Icon { get; set; }
	public List<SubMenu> SubMenus { get; set; }

	public MenuGroup(string Title, Sprite Icon, List<SubMenu> SubMenus)
	{
		this.Title = Title;
		this.Icon = Icon;
		this.SubMenus = SubMenus;
	}
}
