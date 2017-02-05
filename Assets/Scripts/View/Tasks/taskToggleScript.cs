using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	public class TaskToggleScript : MonoBehaviour {
		
		public TaskButtonScript Parent;
		public Toggle ToggleComponent;
				
		public void HandleClick(bool toggled){
			Debug.Log (toggled);
			Parent.Checkout (toggled);
			//Debug.Log(toggleComponent.isOn);
			//Debug.Log (Parent.taskLabel.text);
		}

		// Use this for initialization
		void Start () {
			ToggleComponent.onValueChanged.AddListener (HandleClick);
		}

		public void Setup(TaskButtonScript parent){
			this.Parent = parent;
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
}