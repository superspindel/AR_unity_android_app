using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubButton : MonoBehaviour {
	public Text textField;
	private Transform target;
	private subButtonGroup parentGroup;

	public void Setup(string title, Transform target, subButtonGroup parent)
	{
		this.textField.text = title;
		this.target = target;
		this.parentGroup = parent;
	}


}
