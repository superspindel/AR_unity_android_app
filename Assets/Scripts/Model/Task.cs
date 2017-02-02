using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Task Status
public enum Status{InProgress, Completed, Aborted};

[System.Serializable]
public class Task : NetworkDataObject {

	//public bool Available { get; set; }
	//public string Id { get; set; }
	//public DateTime LastModified { get; private set; }

	// Task
	public Status 		Status { get; set; }
	public string 		Title { get; set ; }
	public string 		Description { get; set; }
	public int 			TotalXp { get; set; } 		// get from subtasks
	public Vector3 		Location { get; set; }
	public List<Tool> 	Tools { get; set; } 		// TODO: add Tool class, helm etc . + get from subtask
	public int 			UserId { get; set; } 		// User has this as active task
	public List<string> Hints { get; set; }

	public List<SubTask> SubTasks { get; set; }

	public Task () {
		
	}
		
}