using Newtonsoft.Json;

namespace ARD_project.Model
{
    public class LoginModel
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}