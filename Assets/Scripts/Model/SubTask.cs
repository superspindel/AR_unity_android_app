using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubTask : NetworkDataObject {

	//public bool Available { get; set; }
	//public string Id { get; set; }
	//public DateTime LastModified { get; private set; }
    
	public Status 	Status { get; set; }
	public string 	Title { get; set; }
	public bool 	IsBonus { get; set; }
	public int 		Xp { get; set; }

	// info popup
	public string 	Information { get; set; }	// Information about sub task
	public string 	Warning { get; set; } 		// Same windows as information, but more important.

	public List<Tool> Tools { get; set; } 		// tools needed for specific subtask, (Ex. not helmet)

	public SubTask () {

	}
}