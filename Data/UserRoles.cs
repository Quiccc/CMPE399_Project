using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARD_project.Data
{
    public partial class UserRoles
    {
        [Key]
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public virtual RolesMaster Role { get; set; }
        public virtual UsersMaster User { get; set; }
    }
}