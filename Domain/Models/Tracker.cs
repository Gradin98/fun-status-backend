using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Tracker : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string About { get; set; }
        
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
