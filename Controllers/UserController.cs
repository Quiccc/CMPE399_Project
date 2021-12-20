using CMPE399_Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMPE399_Project.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DemoTokenContext _context;

        public UserController(DemoTokenContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [Route("get-users")]
        [HttpGet]
        public dynamic GetUsers()
        {
            var Users = (from ut in _context.UserTasks
                         join um in _context.UsersMaster
                         on ut.UserId equals um.UserId
                         orderby um.FirstName ascending
                         select new
                         {
                             userId = um.UserId,
                             userFirstName = um.FirstName,
                             userLastName = um.LastName,
                             userTasks = from ut in um.UserTasks
                                         join t in _context.Tasks
                                         on ut.TaskId equals t.TaskId
                                         join ts in _context.TaskStatus
                                         on t.TaskStatus equals ts
                                         orderby ts.StatusId ascending
                                         select new
                                         {
                                             t.TaskId,
                                             t.TaskName,
                                             t.Deadline,
                                             ts.StatusName
                                         }
                         }).DistinctBy(x => x.userId);
            return Users.ToList();
        }


        [Authorize(Roles = "Admin")]
        [Route("remove-user")]
        [HttpPost]
        public void RemoveUser(long UserId)
        {

        }
    }
}
