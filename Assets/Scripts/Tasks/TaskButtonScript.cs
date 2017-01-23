using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
public class TaskButtonScript : MonoBehaviour {

		public TaskButtonScript button;
		public Text taskLabel;
		public Text xpLabel;

		private Task task;
		private TaskScrollList scrollList;
		// Use this for initialization
		
		void Start () {
			
		}
		
			public void Setup(Task currentTask, TaskScrollList currentScrollList)
			{
				task = currentTask;
				taskLabel.text = task.title;
				xpLabel.text = task.Totalxp.ToString() + "xp";
				scrollList = currentScrollList;
			}
	}
	}