using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetWatch.Classes
{
    [Serializable]
    public class Executioner
    {
        public int Id;
        public int ready;
        public float lastPlace1;
        public float lastPlace2;
    }
}