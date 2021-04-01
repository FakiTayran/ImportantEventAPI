using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportantEventApi.Dtos
{
    public class EventDto
    {
        public string Time { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}
