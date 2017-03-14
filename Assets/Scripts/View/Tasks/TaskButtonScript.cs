using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App{
	public class TaskButtonScript : MonoBehaviour {

		public Text TaskLabel;
		public Text XpLabel;
		public TaskToggleScript TaskToggle;
		public Button TaskButton;
		private Pageswapper _pageswap;

		private Task _task;
		private TaskScrollList _scrollList;

		// Use this for initialization
		void Start () {
			//_pageswap = GameObject.Find ("Page Swapper").GetComponent<Pageswapper> ();
			//TaskButton.onClick.AddListener (HandleClick);
		}
			
		public void Checkout(bool togglecheck)
		{
			if (togglecheck) {
				_scrollList.SelectTask (_task);
			} else {
				_scrollList.RemoveSelectedTask (_task);
			}
			//scrollList.showAddButton (togglecheck);
		}

		public void HandleClick()
		{
			Debug.Log ("1: Task ID: " + _task.Id);
			//_pageswap.gotoSpecificTaskPage (_task.Id);
			//TODO
		}

		public void Setup(Task currentTask, TaskScrollList currentScrollList, Pageswapper pageswapper)
		{
			TaskButton.onClick.AddListener (HandleClick);
			_pageswap = pageswapper;
			_task = currentTask;
			TaskLabel.text = _task.Title + " [" +_task.Id + "]";
			XpLabel.text = _task.TotalXp.ToString() + "xp";
			_scrollList = currentScrollList;
			TaskToggle = this.transform.FindChild("Toggle").GetComponent<TaskToggleScript>();
			TaskToggle.Setup (this);
		}
	}
}