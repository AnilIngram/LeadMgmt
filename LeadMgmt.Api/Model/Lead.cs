using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadMgmt.Api.Model
{
    public class Lead
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string LeadType { get; set; }
        public string BestTimeToCall { get; set; }  
    }
}
