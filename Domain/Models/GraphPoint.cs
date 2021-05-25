using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class GraphPoint : BaseEntity
    {
        public int Value { get; set; }

        [ForeignKey("PingGraph")]
        public int PingGraphId { get; set; }
        public virtual PingGraph PingGraph { get; set; }
    }
}
