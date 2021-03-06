﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: REMOVE CLASS USE API

public class DataContainer : MonoBehaviour {

	// get @ login
	public int UserId;

	// Personal Tasks
	public List<Task> ActiveTasks;
	public List<Task> AvalibleTasks;

	// Global achievement / Badge
	public List<Achievement> AchievementList;
	public List<Badge> BadgeList;

	// Personal Profile
	public User ActiveUser;

	// Personal Settings
	public ArrayList SettingsArray;


// Functions for testing
	// creates one task with n subtasks in active
	/*public void createTestTaskList(){ 
		// Create TaskData
		Task testTask = new Task();
		testTask.id 			= 0;
		testTask.title 			= "TestTask 1";
		testTask.description 	= "Description of TestTask 1";
		testTask.totalxp 		= 1337;
		testTask.location		= new Vector3(0f,0f,0f);
		testTask.status			= Status.InProgress;
		testTask.tools			= new List<Tool>(); 
		testTask.subTasks		= new List<SubTaskData>(); 

		// Create SubTaskData
		for (int i = 0; i < test_nrOfSubTasks; i++) {
			SubTask testSubTask = new SubTask ();
			testSubTask.id 			= i;
			testSubTask.title 		= "SubTask[" + i + "]";
			testSubTask.information = "information for subtask nr " + i;
			testSubTask.warning 	= "Warning";
			testSubTask.tools		= new List<Tool>(); 
			testSubTask.tools.Add(new Tool("helm"));
			testSubTask.status		= Status.InProgress;
			testSubTask.isBonus		= (Random.value > 0.5); // true or false

			testTask.subTasks.Add (testSubTask);
		}

		// Add to activeTasks
		this.activeTasks.Add (testTask);
	}*/
}
