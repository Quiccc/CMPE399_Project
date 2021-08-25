using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD_project.Data
{
    public partial class UserTasks
    {
        public long TaskId { get; set; }
        public long UserId { get; set; }
        public virtual Tasks Task { get; set; }
        public virtual UsersMaster User { get; set; }
    }
}
