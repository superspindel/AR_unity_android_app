using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	public class TaskButtonScript : MonoBehaviour {

		public Text taskLabel;
		public Text xpLabel;
		public taskToggleScript taskToggle;
		public Button taskButton;

		private Task task;
		private TaskScrollList scrollList;

		// Use this for initialization


		void Start () {
			
		}
			
		public void checkout(bool togglecheck){
			task.check = togglecheck;
			scrollList.showAddButton (togglecheck);
		}

		public void Setup(Task currentTask, TaskScrollList currentScrollList)
		{
			task = currentTask;
			taskLabel.text = task.Title;
			xpLabel.text = task.Totalxp.ToString() + "xp";
			scrollList = currentScrollList;
			taskToggle = this.GetComponentInChildren<taskToggleScript>();
			taskToggle.Setup (this, currentTask.check);
		}
	}
}