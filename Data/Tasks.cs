using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMPE399_Project.Data
{
    public partial class Tasks
    {
        public Tasks()
        {
            UserTasks = new HashSet<UserTasks>();
        }
        [Key]
        public long TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public virtual ICollection<UserTasks> UserTasks { get; set; }
    }
}
