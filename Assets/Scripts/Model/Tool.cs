using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
	string name;
	public Tool(string name)
	{
		this.name = name;
	}

	public override string ToString()
	{
		return this.name;
	}


}
