using SocketIOClient.Messages;
using System;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using Assets.Scripts.Models;
using Assets.Scripts.Interactive;
using System.Collections.Generic;

namespace Assets.Scripts
{
    /// <summary>
    /// Add me to an object in the scene, like the camera. Also add CommunicationsApi aswell, after that you're all set
    /// </summary>
    class Starter : MonoBehaviour
    {
        private float _InitTimeOut = 1.0f;
        public static float _SendTimeOut = 2.5f;
        private float _SendTimeCount = 0f;
        private bool _ConnectionIdFetched = false;
        public string ConnectionId = "";

        public GameObject GamePerson;

		public List<Person> Persons = new List<Person>();

		void OnLevelWasLoaded()
		{
			Update ();
		}

        void Start()
        {
            
        }
        void Update()
        {
            if (_InitTimeOut <= 0)
            {
                if (!_ConnectionIdFetched)
                {
                    if (CommunicationsApi.IsAvailable)
                    {
                        //Gets the users own session id
                        CommunicationsApi.Socket.Emit("Person.you", null, "", o =>
                        {
                            SocketIOClient.Messages.JsonEncodedEventMessage m = (SocketIOClient.Messages.JsonEncodedEventMessage)o;
                            var tmp = (o as JsonEncodedEventMessage).GetFirstArgAs<string[]>();
                            ConnectionId = tmp[0];
                        });
                        _ConnectionIdFetched = true;
                    }
                }
                if (_SendTimeCount <= 0)
                {
                    print("Getting pos for you");
                    //Moving player
                    

                    //All other users
                    DataStore.List<Person>(o =>
                    {
                        foreach (Person p in o)
                        {
                            //Skips the local session
                            if (p.Id == ConnectionId)
                            {
                                continue;
                            }
                            //Check if the person is new
                            if (!Persons.Contains(p))
                            {
                                print("====== A New Person Has Entered The Realm ======");
                                Persons.Add(p);
                                //p.gameobject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                                //p.gameobject.transform.position = new Vector3(4.0f, 1.0f, 37.0f);
                                p.gameobject = Instantiate(GamePerson);
                                p.gameobject.transform.position = p.Location;
                                p.gameobject.name = "Person: " + p.Id;
                                //NavMeshAgent agent = p.gameobject.AddComponent<NavMeshAgent>();
                                NavMeshAgent agent = p.gameobject.GetComponent<NavMeshAgent>();
                                agent.acceleration = 100.0f;
                            }
                            else
                            {
                                if(p.gameobject != null)
                                {
                                    NavMeshAgent person = p.gameobject.GetComponent<NavMeshAgent>();
                                    NavMeshPath path = new NavMeshPath();
                                    float totalDistance = 0.0f;
                                    Vector3 prevPos = person.gameObject.transform.position;

                                    person.CalculatePath(p.Location, path);
                                    foreach (Vector3 subPath in path.corners)
                                    {
                                        totalDistance += Vector3.Distance(prevPos, subPath);
                                        prevPos = subPath;
                                    }

                                    person.speed = totalDistance / _SendTimeOut;
                                    person.SetPath(path);
                                }
                            }
                        }
                    });
                    _SendTimeCount = _SendTimeOut;
                }
                else { _SendTimeCount -= Time.deltaTime; }
            }
            else {_InitTimeOut -= Time.deltaTime;}
        }
    }
}
