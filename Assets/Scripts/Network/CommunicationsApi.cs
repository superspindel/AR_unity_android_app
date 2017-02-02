using System;
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

    private bool _shouldReconnect = true;

    // Use this for initialization
	void Start ()
	{
	    Socket = new Client(ServerUrl);
	    Socket.Opened += ClientOnOpened;
        Socket.Message += ClientOnMessage;
        Socket.SocketConnectionClosed += ClientOnSocketConnectionClosed;
        Socket.Error += ClientOnError;
        Socket.RetryConnectionAttempts = 100000;
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
        Debug.Log("Opened connection!");
    }
    
    // Update is called once per frame
	void Update () {
	}
}
