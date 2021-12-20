using Newtonsoft.Json;

namespace CMPE399_Project.Model
{
    public class LoginModel
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}