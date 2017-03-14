using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSubButton : MonoBehaviour {
	public Text TextField;
	private Transform _target;
	private ActiveSubButtonGroup _parentGroup;

	public void Setup(string title, Transform target, ActiveSubButtonGroup parent)
	{
		this.TextField.text = title;
		this._target = target;
		this._parentGroup = parent;
	}
}
