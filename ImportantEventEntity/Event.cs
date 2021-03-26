using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportantEventEntities
{
    public class Event : BaseEntity
    {
        public string Time  { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

    }
}
