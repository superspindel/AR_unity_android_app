using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIOClient;

public class SocketClient : MonoBehaviour
{

    public string ServerUrl;
    private Client _client;
	// Use this for initialization
	void Start ()
	{
	    _client = new Client(ServerUrl);
	    _client.Opened += ClientOnOpened;
        _client.Message += ClientOnMessage;
        _client.SocketConnectionClosed += ClientOnSocketConnectionClosed;
        _client.Error += ClientOnError;

	    _client.Connect();
	}

    private void ClientOnError(object sender, ErrorEventArgs errorEventArgs)
    {
        Debug.Log("Error");
        Debug.Log(errorEventArgs.Message);
    }

    private void ClientOnSocketConnectionClosed(object sender, EventArgs eventArgs)
    {
        throw new NotImplementedException();
    }

    private void ClientOnMessage(object sender, MessageEventArgs messageEventArgs)
    {
        if (messageEventArgs != null)
        {
            
        }
    }

    private void ClientOnOpened(object sender, EventArgs eventArgs)
    {
        Debug.Log("Opened");
    }

    // Update is called once per frame
	void Update () {
		
	}
}
