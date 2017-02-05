using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App{
	public class AddTaskButtonScript : MonoBehaviour {
		public TaskScrollList ScrollList;
		public Button ButtonComponent;


		void Start () {
            Debug.Log("HEJ");
			ButtonComponent.onClick.AddListener (HandleClick);
		}


		public void HandleClick(){
			ScrollList.AddCheckedTasks ();
		}

		void Update () {
			
		}
	}
}