using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.Users
{
    public partial class User
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
    }
}
