using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Position
    {
        public float X;
        public float Y;
        public float Z;

        /// <summary>
        /// Used for casting from Position -> Vector3
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator Vector3(Position p)
        {
            return new Vector3(p.X, p.Y, p.Z);
        }

        /// <summary>
        /// Used for casting from Vector3 -> Position
        /// </summary>
        /// <param name="p"></param>
        public static implicit operator Position(Vector3 p)
        {
            return new Position { X = p.x, Y = p.y, Z = p.z };
        }

        /// <summary>
        /// No idé.....
        /// </summary>
        /// <param name="b"></param>
        public static implicit operator Position(string b)
        {
            return new Position();
        }
    }
    [System.Serializable]
    public class Person : NetworkDataObject
    {
        public Position RawLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        internal Vector3 Location { get; set; }
        internal GameObject gameobject { get; set; }

        public Person()
        {

        }
    }
}
