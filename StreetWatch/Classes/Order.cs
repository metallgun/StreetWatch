using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreetWatch.Classes
{
    [Serializable]
    public class Order
    {
        public int IDorder;
        public int IDuser;
        public float Coord1;
        public float Coord2;
        public DateTime CreationDate;
        public DateTime PlanDate;
        public string CreationDateStr;
        public string PlanDateStr;
        public string Comment;
        public int Urgent;
        public int Status;
        public Result result;
    }
}