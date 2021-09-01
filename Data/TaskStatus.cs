﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARD_project.Data
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Tasks>();
        }

        [Key]
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
