using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography.X509Certificates;

// Task Status
public enum Status{InProgress, Completed, Aborted};

public class Position
{
    public float X;
    public float Y;
    public float Z;

    public static implicit operator Vector3(Position p)
    {
        return new Vector3(p.X, p.Y, p.Z);
    }

    public static implicit operator Position(Vector3 p)
    {
        return new Position {X = p.x, Y = p.y, Z = p.z};
    }

    public static implicit operator Position(string b)
    {
        return new Position();
    }
}
[System.Serializable]
public class Task : NetworkDataObject {

	//public bool Available { get; set; }
	//public string Id { get; set; }
	//public DateTime LastModified { get; private set; }

	// Task
    public int RawStatus
    {
        get { return (int) Status; }
        set { Status = (Status) value; }
    }
	internal Status 	Status { get; set; }
	public string 		Title { get; set ; }
	public string 		Description { get; set; }
	public int 			TotalXp { get; set; }       // get from subtasks

    public Position RawLocation
    {
        get { return Location; }
        set { Location = value; }
    }

    internal Vector3 	Location { get; set; }
	public List<Tool> 	Tools { get; set; } 		// TODO: add Tool class, helm etc . + get from subtask
	public string 		UserId { get; set; } 		// User has this as active task
	public List<string> Hints { get; set; }

	public List<SubTask> SubTasks { get; set; }

	public Task ()
	{
	}
		
}