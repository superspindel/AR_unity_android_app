﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskData {

	// Task
	public int id;
	public string title;
	public string description;
	public int totalxp;
	public Vector3 location;
	public Status status;
	public List<string> tools;

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
