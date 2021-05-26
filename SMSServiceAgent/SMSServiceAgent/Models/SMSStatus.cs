using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMSServiceAgent.Models
{
    public class SMSStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}