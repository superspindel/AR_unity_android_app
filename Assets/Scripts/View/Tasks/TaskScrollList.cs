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
		private List<Task> CheckedList;
		private int _checkedCount = 0;

		void Start () {
				RefreshDisplay ();
		}
		
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



		private void addTask(Task taskToAdd, TaskScrollList scrollList)
		{
			scrollList.TaskList.Add (taskToAdd);
		}

		private void removeTask(Task taskToRemove, TaskScrollList scrollList)
		{
			for (int i = scrollList.TaskList.Count - 1; i >= 0; i--) 
			{
				if(scrollList.TaskList[i] == taskToRemove)
				{
					scrollList.TaskList.RemoveAt(i);
				}
			}
		}

		public void addCheckedTasks(){
			/* TODO: for (int i = 0; i < taskList.Count; i++) {
				if (taskList [i].check) {
					//Debug.Log (taskList [i].title);
					taskList [i].available = false;
					checkedCount--;
				}
				RefreshDisplay ();
			}*/ 
		}

		public void showAddButton(bool toggle){
			if (toggle) {
				_checkedCount++;
			} else {
				_checkedCount--;
			}
			Debug.Log (_checkedCount);
			if (_checkedCount > 0) {
				AddTaskButton.gameObject.SetActive(true);
			} else {
				AddTaskButton.gameObject.SetActive(false);
			}
			
		}
	}
}