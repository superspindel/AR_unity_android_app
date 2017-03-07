using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIOClient;

public class CommunicationsApi : MonoBehaviour
{

    private static bool _successfulFirstConnect = false;
    private static bool _attemptingToConnect = false;
    public string ServerUrl;

    public static bool IsAvailable
    {
        get { return Socket != null && Socket.IsConnected; }
    }
    public static Client Socket { get; private set; }

    private bool _shouldReconnect = true;

    private static List<Action> _queuedTasks = new List<Action>();

    // Use this for initialization
	void Start ()
	{
	    Socket = new Client(ServerUrl);
	    Socket.Opened += ClientOnOpened;
        Socket.Message += ClientOnMessage;
        Socket.SocketConnectionClosed += ClientOnSocketConnectionClosed;
        Socket.Error += ClientOnError;
        Socket.RetryConnectionAttempts = 100000;
	    _attemptingToConnect = true;
        Socket.Connect();
	}

    void OnDestroy()
    {
        if (Socket != null)
        {
            _shouldReconnect = false;
            Socket.Close();
        }
    }

    private static void ClientOnError(object sender, ErrorEventArgs errorEventArgs)
    {
        _attemptingToConnect = false;
        Debug.Log("Error");
        Debug.Log(errorEventArgs.Message);
    }

    private void ClientOnSocketConnectionClosed(object sender, EventArgs eventArgs)
    {
        Debug.Log("Lost connection...");
        if (_shouldReconnect)
        {
            Socket.Connect();
        }
    }

    private static void ClientOnMessage(object sender, MessageEventArgs messageEventArgs)
    {
        if (messageEventArgs != null)
        {
            // here for debugging purposes
        }
    }

    private static void ClientOnOpened(object sender, EventArgs eventArgs)
    {
        _successfulFirstConnect = true;
        _attemptingToConnect = false;
        Debug.Log("Opened connection!");
    }

    public static void RunOnMainThread(Action run)
    {
        lock (_queuedTasks)
        {
            _queuedTasks.Add(run);
        }

    }
    // Update is called once per frame
	void Update () {
	    if (Socket != null && !_successfulFirstConnect && !_attemptingToConnect)
	    {
	        _attemptingToConnect = true;
	        //Socket.Connect();
	    }
	    lock (_queuedTasks)
	    {
	        var tasks = _queuedTasks.ToArray();
            _queuedTasks.Clear();
	        foreach(var action in tasks)
	        {
	            action.Invoke();
	        }
	    }
	}
}
