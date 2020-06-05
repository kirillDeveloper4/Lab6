using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public abstract class UserBase
    {
        public Guid Id { get; }
        public string Name { get; }
        protected string Role { get; }

        public UserBase(Guid id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
    }
}
