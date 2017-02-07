using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App{
	public class AddTaskButtonScript : MonoBehaviour {
		public TaskScrollList ScrollList;
		public Button ButtonComponent;
		public Text TextComponent;

		void Start () {
			ButtonComponent.onClick.AddListener (HandleClick);
		}

		// Changes the text of the Text component to display the number of tasks currently selected
		public void ChangeText(int taskCount){
			if (taskCount > 0) {
				TextComponent.text = "Add Tasks (" + taskCount.ToString() + ")";
			} else {
				TextComponent.text = "Add Tasks";
			}
		}


		public void HandleClick(){
			ScrollList.AddCheckedTasks ();
		}

		void Update () {
			
		}
	}
}