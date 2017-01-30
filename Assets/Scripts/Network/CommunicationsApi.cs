﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Application;
using UnityEngine;
using SocketIOClient;

public class CommunicationsApi : MonoBehaviour
{

    public string ServerUrl;

    public static bool IsAvailable
    {
        get { return Socket != null && Socket.IsConnected; }
    }
    public static Client Socket { get; private set; }

    // Use this for initialization
	void Start ()
	{
	    Socket = new Client(ServerUrl);
	    Socket.Opened += ClientOnOpened;
        Socket.Message += ClientOnMessage;
        Socket.SocketConnectionClosed += ClientOnSocketConnectionClosed;
        Socket.Error += ClientOnError;

	    Socket.Connect();
    }

    void OnDestroy()
    {
        if (Socket != null)
        {
            Socket.Close();
        }
    }

    private void ClientOnError(object sender, ErrorEventArgs errorEventArgs)
    {
        Debug.Log("Error");
        Debug.Log(errorEventArgs.Message);
    }

    private void ClientOnSocketConnectionClosed(object sender, EventArgs eventArgs)
    {
    }

    private void ClientOnMessage(object sender, MessageEventArgs messageEventArgs)
    {
        if (messageEventArgs != null)
        {
            // here for debugging purposes
        }
    }

    private void ClientOnOpened(object sender, EventArgs eventArgs)
    {
        Debug.Log("Opened connection!");
    }
    
    // Update is called once per frame
    private bool _attempt = false;
	void Update () {
	    if (IsAvailable && !_attempt)
	    {
	        _attempt = true;
            DataStore.List<Task>(tasks =>
            {
                foreach (var task in tasks)
                {
                    Debug.Log(task.Title);
                }
            });
        }
	}
}
