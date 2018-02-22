using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadMgmt.Web.Models
{
    public class LeadModel
    {
        public long ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }
        
        [MaxLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required]
        public string LeadType { get; set; }
         
        public string BestTimeToCall { get; set; }

        public List<SelectListItem> LeadTypeList { get; set; } 

    }
}
