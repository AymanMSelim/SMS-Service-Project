using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SMSServiceAgent.Models
{
    public class SMSSendingLog
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SMS")]
        public int SMSId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("SMSStatus")]
        public int StatusId { get; set; }

        public DateTime LastStatusChangeTime { get; set; }

        public virtual SMS SMS { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual SMSStatus SMSStatus { get; set; }
    }
}