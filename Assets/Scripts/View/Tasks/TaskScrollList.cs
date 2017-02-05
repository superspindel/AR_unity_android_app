using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	public class TaskScrollList : MonoBehaviour {
		public List<Task> TaskList;
		public Transform ContentPanel;
		public SimpleObjectPool ButtonObjectPool;
		public AddTaskButtonScript AddTaskButton;
		private List<Task> _checkedList = new List<Task>();

		void Start () {
				RefreshDisplay ();

		}

		// Removes and adds buttons
		public void RefreshDisplay()
		{
			RemoveTaskButtons ();
			AddTaskButtons ();
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
					taskButton.Setup (task, this);
				}
			}
		}

		private void RemoveTaskButtons ()
		{
			while (ContentPanel.childCount > 0) 
			{
				GameObject toRemove = transform.GetChild (0).gameObject;
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
		}

		public void SelectTask(Task taskToAdd)
		{
			Debug.Log ("added: " + taskToAdd.Id + " To list");
			_checkedList.Add (taskToAdd);

		}


		public void RemoveSelectedTask(Task taskToRemove)
		{
			for (int i = this._checkedList.Count - 1; i >= 0; i--) 
			{
				if(this._checkedList[i] == taskToRemove)
				{
					this._checkedList.RemoveAt(i);
				}
			}
			Debug.Log ("Removed : " + taskToRemove.Id + " from list");
		}


		// Adds checked tasks
		public void AddCheckedTasks(){
			foreach (Task taskToAdd in _checkedList) {
				Debug.Log ("Added task: " + taskToAdd.Id + " to your active tasks");
				taskToAdd.UserId = 123; // TODO: get the real userID
			}
			RefreshDisplay ();
		}


		public void ShowAddButton(bool toggle){
						
		}

	}
}