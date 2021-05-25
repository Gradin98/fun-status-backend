using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Incident : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public int TrackerId { get; set; }
        public virtual Tracker Tracker { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
