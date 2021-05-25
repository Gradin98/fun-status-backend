using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }

        public virtual List<Incident> Incidents { get; set; }
    }
}
