using System;

namespace CCL.Security.Identity
{
    public class User : UserBase
    {
        public User(Guid id, string name)
            : base(id, name, nameof(User))
        {
        }
    }
}