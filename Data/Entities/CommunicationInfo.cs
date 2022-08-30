using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CommunicationInfo
    {
        public  ObjectId _id { get; set; }
        public int InfoType { get; set; }
        public string Info { get; set; }
    }
}
