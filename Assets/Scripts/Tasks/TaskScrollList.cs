using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	public class TaskScrollList : MonoBehaviour {
		public List<Task> taskList;
		public Transform contentPanel;
		public SimpleObjectPool buttonObjectPool;

		// Use this for initialization
		
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
			for (int i = 0; i < taskList.Count; i++)
			{
					Task task = taskList [i];
					GameObject newButton = buttonObjectPool.GetObject ();
					newButton.transform.SetParent (contentPanel);
					TaskButtonScript taskButton = newButton.GetComponent<TaskButtonScript>();
					taskButton.Setup (task, this);
			}
				
		}

		private void RemoveTaskButtons ()
		{
			while (contentPanel.childCount > 0) 
			{
				GameObject toRemove = transform.GetChild (0).gameObject;
				buttonObjectPool.ReturnObject (toRemove);
			}
		
		}

		private void addTask(Task taskToAdd, TaskScrollList scrollList)
		{
			scrollList.taskList.Add (taskToAdd);
		}

		private void removeTask(Task taskToRemove, TaskScrollList scrollList)
		{
			for (int i = scrollList.taskList.Count - 1; i >= 0; i--) 
			{
				if(scrollList.taskList[i] == taskToRemove)
				{
					scrollList.taskList.RemoveAt(i);
				}
			}
		}
	}

}