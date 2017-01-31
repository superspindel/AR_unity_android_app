using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	
	[System.Serializable]
	public class Task : NetworkDataObject
	{
		public string Title { get; set; }

		public int Totalxp;
		public List<SubTask> subtasks;
		public bool available;
		public bool check;

		public void Start ()
		{
			this.available = true;
			this.check = false;
		}
	}
}
