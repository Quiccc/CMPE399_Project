﻿using System;
using System.Collections.Generic;

namespace ARD_project.Data
{
    public partial class UsersMaster
    {
        public UsersMaster()
        {
            RefreshToken = new HashSet<RefreshToken>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        public virtual RolesMaster UserRoles { get; set; }
    }
}
