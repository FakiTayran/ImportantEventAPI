using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImportantEventEntities
{
    public class AppUser : IdentityUser
    {
        public ICollection<Event> Events { get; set; }

    }
}
