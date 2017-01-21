using System;
using System.Collections.Generic;

namespace Application
{
	[System.Serializable]
	public class Task
	{
		public int id;
		public string title;
		public List<SubTask> subtasks;

		public Task ()
		{
		}
	}
}

