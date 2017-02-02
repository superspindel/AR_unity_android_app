using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenu : MonoBehaviour {

	public string Title { get; private set; }
	public Transform Target { get; private set; }

	public SubMenu(string Title, Transform Target)
	{
		this.Title = Title;
		this.Target = Target;
	}
}
