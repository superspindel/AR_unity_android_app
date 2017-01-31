using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	public class AddTaskButtonScript : MonoBehaviour {
		public TaskScrollList scrollList;
		public Button ButtonComponent;
		// Use this for initialization
		void Start () {
			ButtonComponent.onClick.AddListener (HandleClick);
		}


		public void HandleClick(){
			scrollList.addCheckedTasks ();
		}
		// Update is called once per frame
		void Update () {
			
		}
	}
}