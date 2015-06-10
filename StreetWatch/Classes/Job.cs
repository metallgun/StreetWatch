using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetWatch.Classes
{
    [Serializable]
    public class Job
    {
        public int JobId;
        public int ExecutorId;
        public int Status;
        public DateTime confirmDate;
        public DateTime executDate;
    }
}