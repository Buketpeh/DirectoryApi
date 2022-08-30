using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User
    {
        //To do: CreatedAt, UpdatedAt , IsDeleted eklenecek 
        public ObjectId _id { get; set; } 
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<CommunicationInfo> CommunicationInfo { get; set; }
    }
}
