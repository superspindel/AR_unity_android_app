using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	
	[System.Serializable]
	public class Task : NetworkDataObject
	{
		public string Title { get; set; }

		internal int Totalxp;
		internal List<SubTask> subtasks = new List<SubTask>();
		internal bool available;
		internal bool check;

	    internal bool swag;
	    private bool yolo;

		public void Start ()
		{
			this.available = true;
			this.check = false;
		}
	}
}
