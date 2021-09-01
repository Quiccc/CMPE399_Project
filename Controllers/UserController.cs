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
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DemoTokenContext _context;

        public UserController(DemoTokenContext context)
        {
            _context = context;
        }

        [Authorize(Roles ="Admin")]
        [Route("get-users")]
        [HttpGet]
        public dynamic GetUsers()
        {
            var Users = from ut in _context.UserTasks
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
                                        where ut.UserId == um.UserId
                                        select new
                                        {
                                            t.TaskId,
                                            t.TaskName,
                                            t.Deadline
                                        }
                        };
           return Users.ToList();
        }
    }
}
