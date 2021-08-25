using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ARD_project.Data
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
        public virtual ICollection<UserTasks> UserTasks { get; set; }
    }
}
