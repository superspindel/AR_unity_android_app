using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	public class TaskButtonScript : MonoBehaviour {

		public Text TaskLabel;
		public Text XpLabel;
		public TaskToggleScript TaskToggle;
		public Button TaskButton;

		private Task _task;
		private TaskScrollList scrollList;

		// Use this for initialization
		void Start () {
			
		}
			
		public void checkout(bool togglecheck){
			// TODO: Task.check = togglecheck; 
			scrollList.showAddButton (togglecheck);
		}

		public void Setup(Task currentTask, TaskScrollList currentScrollList)
		{
			_task = currentTask;
			TaskLabel.text = _task.Title;
			XpLabel.text = _task.TotalXp.ToString() + "xp";
			scrollList = currentScrollList;
			TaskToggle = this.GetComponentInChildren<TaskToggleScript>();
			// TODO: Check taskToggle.Setup (this, currentTask.check);
		}
	}
}