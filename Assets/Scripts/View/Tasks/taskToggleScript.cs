using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace App{
	public class TaskToggleScript : MonoBehaviour {
		
		private TaskButtonScript Parent;
		private Toggle ToggleComponent;
				
		public void HandleClick(bool toggled){
			//Debug.Log (toggled);
			Parent.Checkout (toggled);
			//Debug.Log(toggleComponent.isOn);
			//Debug.Log (Parent.taskLabel.text);
		}

		// Use this for initialization
		void Awake () {
			Parent = transform.parent.gameObject.GetComponent<TaskButtonScript> ();
			ToggleComponent = transform.gameObject.GetComponent<Toggle> ();
			ToggleComponent.onValueChanged.AddListener (HandleClick);
		}

		public void Setup(TaskButtonScript parent){
			this.Parent = parent;
			this.ToggleComponent.isOn = false;
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
}