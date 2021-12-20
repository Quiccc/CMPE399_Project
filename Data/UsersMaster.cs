using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMPE399_Project.Data
{
    public partial class UsersMaster
    {
        public UsersMaster()
        {
            RefreshToken = new HashSet<RefreshToken>();
            UserRoles = new HashSet<UserRoles>();
            UserTasks = new HashSet<UserTasks>();
        }
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<UserTasks> UserTasks { get; set; }
    }
}