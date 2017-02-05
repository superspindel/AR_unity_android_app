﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App{
	public class TaskScrollList : MonoBehaviour {
		public GameObject ThisPage;
		private List<Task> TaskList;
		public Transform ContentPanel;
		public SimpleObjectPool ButtonObjectPool;
		public AddTaskButtonScript AddTaskButton;
		public Pageswapper PageSwapperReference;
		private List<Task> CheckedList = new List<Task>();

		void Start () {
				RefreshDisplay ();
		}

		// Removes and adds buttons
		public void RefreshDisplay()
		{
			RemoveTaskButtons ();
			AddTaskButtons ();
		}

		public void GetTaskList()
		{
			
		}

		private void AddTaskButtons()
		{
			for (int i = 0; i < TaskList.Count; i++)
			{
				if (TaskList [i].UserId == 0) { // TODO: check if no one "has task"
					Task task = TaskList [i]; 
					task.Id = i.ToString (); //TODO REMOVE
					GameObject newButton = ButtonObjectPool.GetObject ();
					newButton.transform.SetParent (ContentPanel);
					TaskButtonScript taskButton = newButton.GetComponent<TaskButtonScript> ();
					taskButton.Setup (task, this, this.PageSwapperReference);
				}
			}
		}

		private void RemoveTaskButtons ()
		{
			while (ContentPanel.childCount > 0) 
			{
				GameObject toRemove = ContentPanel.GetChild (0).gameObject;
				ButtonObjectPool.ReturnObject (toRemove);
			}
		}



		private void addTask(Task taskToAdd)
		{
			this.TaskList.Add (taskToAdd);
		}

	
		private void removeTask(Task taskToRemove)
		{
			for (int i = this.TaskList.Count - 1; i >= 0; i--) 
			{
				if(this.TaskList[i] == taskToRemove)
				{
					this.TaskList.RemoveAt(i);
				}
			}
		}

		public void SelectTask(Task taskToAdd)
		{
			Debug.Log ("added: " + taskToAdd.Id + " To list");
			CheckedList.Add (taskToAdd);

		}


		public void RemoveSelectedTask(Task taskToRemove)
		{
			for (int i = this.CheckedList.Count - 1; i >= 0; i--) 
			{
				if(this.CheckedList[i] == taskToRemove)
				{
					this.CheckedList.RemoveAt(i);
				}
			}
			Debug.Log ("Removed : " + taskToRemove.Id + " from list");
		}


		// Adds checked tasks
		public void AddCheckedTasks(){
			foreach (Task taskToAdd in CheckedList) {
				Debug.Log ("Added task: " + taskToAdd.Id + " to your active tasks");
				taskToAdd.UserId = "123"; // TODO: get the real userID
			}
			RefreshDisplay ();
		}


		public void showAddButton(bool toggle){
						
		}

		public void EnterPage(List<Task> taskList){
			this.TaskList = taskList;
			this.ThisPage.SetActive (true);
			AddTaskButtons ();
		}

		public void LeavePage(){
			RemoveTaskButtons ();
			this.ThisPage.SetActive (false);
		}
	}
}