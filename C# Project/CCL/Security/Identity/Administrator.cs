using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Administrator : UserBase
    {
        public Administrator(Guid id, string name)
            : base(id, name, nameof(Administrator))
        {
        }
    }
}
