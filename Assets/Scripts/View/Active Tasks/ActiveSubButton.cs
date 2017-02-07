using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSubButton : MonoBehaviour {
	public Text TextField;
	private SubTask _subTask;
	private ActiveSubButtonGroup _parentGroup;

	public void Setup(SubTask subtask, ActiveSubButtonGroup parent)
	{
		this.TextField.text = subtask.Title;
		this._subTask = subtask;
		this._parentGroup = parent;
	}
}
