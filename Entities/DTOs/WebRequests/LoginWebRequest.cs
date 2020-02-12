namespace Entities.WebRequests
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class LoginWebRequest
    {
        [JsonProperty("username")]
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
    }
}
