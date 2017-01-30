using System;
using System.Collections.Generic;

namespace Application
{
	[System.Serializable]
	public class Task : NetworkDataObject
	{
		public string Title { get; set; }
		public List<SubTask> subtasks;

		public Task ()
		{
		}
	}
}

