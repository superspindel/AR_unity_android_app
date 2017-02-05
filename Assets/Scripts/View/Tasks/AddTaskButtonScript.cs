using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App{
	public class AddTaskButtonScript : MonoBehaviour {
		public TaskScrollList scrollList;
		public Button ButtonComponent;


		void Start () {
			ButtonComponent.onClick.AddListener (HandleClick);
		}


		public void HandleClick(){
			scrollList.AddCheckedTasks ();
		}

		void Update () {
			
		}
	}
}