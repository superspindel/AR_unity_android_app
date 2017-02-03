using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSubButton : MonoBehaviour {
	public Text TextField;
	private Transform Target;
	private ActiveSubButtonGroup ParentGroup;

	public void Setup(string Title, Transform Target, ActiveSubButtonGroup Parent)
	{
		this.TextField.text = Title;
		this.Target = Target;
		this.ParentGroup = Parent;
	}
}
