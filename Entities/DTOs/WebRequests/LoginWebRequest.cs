namespace Entities.WebRequests
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class LoginWebRequest
    {
        [JsonProperty("email")]
        [Required(ErrorMessage = "Please enter your email.")]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
    }
}
