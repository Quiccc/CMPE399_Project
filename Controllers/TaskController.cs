using ARD_project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARD_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DemoTokenContext _context;

        public TaskController(DemoTokenContext context)
        {
            _context = context;
        }


        [Route("/tasks")]
        [HttpGet]
        public dynamic GetTasks()
        {
            var Tasks = from t in _context.Tasks
                        orderby t.Deadline ascending
                        select new
                        {
                            taskId = t.TaskId,
                            taskName = t.TaskName,
                            deadline = t.Deadline,
                            assignedUsers = from ut in t.UserTasks
                                         join um in _context.UsersMaster
                                         on ut.UserId equals um.UserId
                                         select new
                                         {
                                             userId = um.UserId,
                                             userFirstName = um.FirstName,
                                             userLastName = um.LastName
                                         }
                        };
            return Tasks.ToList();
        }


        [Authorize(Roles = "User")]
        [Authorize(Roles = "Admin")]
        [Route("/usertasks")]
        [HttpGet]
        public dynamic GetUserTasks()
        {
            long activeUserId = long.Parse(User.Identity.Name);
            var userTasks = from ut in _context.UserTasks
                            join t in _context.Tasks
                            on ut.TaskId equals t.TaskId
                            join um in _context.UsersMaster
                            on ut.UserId equals um.UserId
                            where ut.UserId == activeUserId
                            orderby t.Deadline ascending
                            select new
                            {
                                taskId = t.TaskId,
                                taskName = t.TaskName,
                                taskDeadline = t.Deadline,
                                userId = ut.UserId,
                                userFirstName = um.FirstName,
                                userLastName = um.LastName
                            };
            return userTasks.ToList();
        }
    }
}
