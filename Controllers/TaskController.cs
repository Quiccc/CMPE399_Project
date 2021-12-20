using CMPE399_Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CMPE399_Project.Controllers
{
    [Route("/api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DemoTokenContext _context;

        public TaskController(DemoTokenContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "Admin")]
        [Route("get-tasks")]
        [HttpGet]
        public dynamic GetTasks()
        {
            var Tasks = from t in _context.Tasks
                        join ts in _context.TaskStatus
                        on t.TaskStatus equals ts
                        orderby t.Deadline ascending
                        select new
                        {
                            taskId = t.TaskId,
                            taskName = t.TaskName,
                            deadline = t.Deadline,
                            statusId = ts.StatusId,
                            statusName = ts.StatusName,
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

        [Authorize]
        [Route("my-tasks")]
        [HttpGet]
        public dynamic GetUserTasks()
        {
            var activeUserId = (from rt in _context.RefreshToken orderby rt.RefreshTokenId ascending select rt.UserId);

            var userTasks = from ut in _context.UserTasks
                            join t in _context.Tasks
                            on ut.TaskId equals t.TaskId
                            join um in _context.UsersMaster
                            on ut.UserId equals um.UserId
                            join ts in _context.TaskStatus
                            on t.TaskStatus equals ts
                            where ut.UserId == activeUserId.Last()
                            orderby t.Deadline ascending
                            select new
                            {
                                taskId = t.TaskId,
                                taskName = t.TaskName,
                                deadline = t.Deadline,
                                statusId = ts.StatusId,
                                statusName = ts.StatusName,
                                assignedUsers = from ut in t.UserTasks
                                                join um in _context.UsersMaster
                                                on ut.UserId equals um.UserId
                                                where ut.UserId != activeUserId.Last()
                                                select new
                                                {
                                                    userId = um.UserId,
                                                    userFirstName = um.FirstName,
                                                    userLastName = um.LastName
                                                }
                            };
            return userTasks.ToList();
        }
    }
}
