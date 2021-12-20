using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMPE399_Project.Model
{
    public class UserModel
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("userRoles")]
        public List<string> UserRoles { get; set; }

    }

}
