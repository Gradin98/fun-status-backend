using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PingGraph : BaseEntity
    {
        public string Name { get; set; }

        public string Uri { get; set; }
    }
}
