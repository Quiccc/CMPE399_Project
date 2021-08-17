using System;
using System.Collections.Generic;

namespace ARD_project.Data
{
    public partial class RolesMaster
    {
        public RolesMaster()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
