using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model
{
    public class RemoteSupportMouse : NetworkDataObject
    {
        public bool Down { get; set; }
        public Position Position { get; set; }
    }
}
