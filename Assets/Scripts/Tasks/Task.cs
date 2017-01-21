using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Application{
	
	[System.Serializable]
	public class Task
	{
		public int id;
		public string title;
		public int Totalxp;
		public List<SubTask> subtasks;

		public Task ()
		{
		}
	}
}
