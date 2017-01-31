using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskData {

	// Task
	public int id;
	public string title;
	public string description;
	public int totalxp; // get from subtasks
	public Vector3 location;
	public Status status;
	//public TIDSVARIABEL statusUpdated;
	public List<Tool> tools; // TODO: add Tool class, helm etc . + get from subtask
	public int userid; // more users later
	public List<string> hints;

	// List of SubTaskData for this Task
	public List<SubTaskData> subTasks;
	// TODO:predefine nr of regular/bonus?


	// Use this for initialization
	public TaskData () {
		Debug.Log ("TaskData is Awake");
		//tools = getToolsFromSubTasks ();
	}

	//TODO:getToolsFromSubTasks () {}
}
