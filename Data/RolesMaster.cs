using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARD_project.Data
{
    public partial class RolesMaster
    {
        public RolesMaster()
        {
            UserRoles = new HashSet<UserRoles>();
        }
        [Key]
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}