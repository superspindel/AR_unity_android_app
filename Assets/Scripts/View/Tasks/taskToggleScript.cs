using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	public class taskToggleScript : MonoBehaviour {
		
		public TaskButtonScript Parent;
		public Toggle toggleComponent;
				
		public void HandleClick(bool Toggled){
			//Debug.Log (Toggled);
			Parent.checkout (Toggled);
			//Debug.Log(toggleComponent.isOn);
			//Debug.Log (Parent.taskLabel.text);
		}

		// Use this for initialization
		void Start () {
			toggleComponent.onValueChanged.AddListener (HandleClick);
		}

		public void Setup(TaskButtonScript parent, bool check){
			this.Parent = parent;
			this.toggleComponent.isOn = check;
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
}