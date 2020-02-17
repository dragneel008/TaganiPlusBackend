using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Users
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual UserDetails UserDetails { get; set; }
    }
}
