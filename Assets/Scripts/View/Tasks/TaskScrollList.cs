using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App{
	public class TaskScrollList : MonoBehaviour {
		private GameObject ThisPage;
		private List<Task> TaskList;
		private Transform ContentPanel;
		private SimpleObjectPool ButtonObjectPool;
		private AddTaskButtonScript AddTaskButton;
		private Pageswapper PageSwapperReference;
		private List<Task> _checkedList = new List<Task>();


		void Awake () {
			//Debug.Log ("im awake");
			this.ThisPage = transform.gameObject;
			this.ContentPanel = transform.FindChild ("Scroll View").FindChild ("Viewport").FindChild ("Content").transform;
			//Debug.Log ("this is the contentpanel" + this.ContentPanel);
			this.ButtonObjectPool = transform.FindChild ("ButtonObjectPool").gameObject.GetComponent<SimpleObjectPool>();
			this.AddTaskButton = transform.FindChild ("AddTasksButton").gameObject.GetComponent<AddTaskButtonScript> ();
			this.PageSwapperReference = GameObject.Find ("Page Swapper").gameObject.GetComponent<Pageswapper> ();
		}

		// Removes and adds buttons
		public void RefreshDisplay()
		{
			RemoveTaskButtons ();
			AddTaskButtons ();
		}

		// Adds the button gameobjects and assigns taskbuttonscripts
		private void AddTaskButtons()
		{
		    if (TaskList == null)
		        return;
			foreach(var task in TaskList)
			{
				if (task.UserId == null) { // TODO: check if no one "has task"
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



		private void AddTask(Task taskToAdd)
		{
			this.TaskList.Add (taskToAdd);
		}

	
		private void RemoveTask(Task taskToRemove)
		{
			for (int i = this.TaskList.Count - 1; i >= 0; i--) 
			{
				if(this.TaskList[i] == taskToRemove)
				{
					this.TaskList.RemoveAt(i);
				}
			}
			ShowAddButtonNumber();
		}

		// Adds a selected task to _checkedList and updates addTaskButton counter
		public void SelectTask(Task taskToAdd)
		{
			Debug.Log ("added: " + taskToAdd.Id + " To list");
			_checkedList.Add (taskToAdd);
			ShowAddButtonNumber ();
		}

		// Removes a selected task from _checkedList and updates addTaskButton counter
		public void RemoveSelectedTask(Task taskToRemove)
		{
			for (int i = this._checkedList.Count - 1; i >= 0; i--) 
			{
				if(this._checkedList[i] == taskToRemove)
				{
					this._checkedList.RemoveAt(i);
				}
			}
			ShowAddButtonNumber ();
			Debug.Log ("Removed : " + taskToRemove.Id + " from list");
		}


		// Adds checked tasks
		public void AddCheckedTasks(){
			while (_checkedList.Count > 0) {
				Task taskToAdd = _checkedList [0];
				Debug.Log ("Added task: " + taskToAdd.Id + " to your active tasks");
				taskToAdd.UserId = "123"; // TODO: get the real userID
				_checkedList.Remove(taskToAdd);
			}
			RefreshDisplay ();
			ShowAddButtonNumber ();
		}

		// Updates the text of the AddTasksButton to display the number of tasks currently selected
		public void ShowAddButtonNumber(){
			AddTaskButton.ChangeText (_checkedList.Count);
		}

		// Script to enter the page used for initialization 
		public void EnterPage(List<Task> taskList){
			//Debug.Log ("Enter Page");
			this.TaskList = taskList; // added back to code // EMIL
			this.gameObject.SetActive (true);
			AddTaskButtons ();
		}

		// Script to Leave Page
		public void LeavePage(){
			RemoveTaskButtons ();
			this.gameObject.SetActive (false);
		}
	}
}