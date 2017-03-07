using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model
{
    class RemoteSupportStream : NetworkDataObject
    {
        public bool Streaming { get; set; }
        public string Image { get; set; }

    }
}
