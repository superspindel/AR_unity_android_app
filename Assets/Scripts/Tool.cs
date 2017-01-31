using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {

	public Tool(string name)
	{
		this.name = name;
	}

	public override string ToString()
	{
		return this.name;
	}


}
