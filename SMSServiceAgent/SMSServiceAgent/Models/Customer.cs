using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMSServiceAgent.Models
{
    public class Customer
        
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreateAt { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public List<SMSSendingLog> CustomerSMSLogs { get; set; }
    }
}