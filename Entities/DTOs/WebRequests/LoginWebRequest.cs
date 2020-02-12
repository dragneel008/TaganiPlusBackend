namespace Entities.WebRequests
{
    using System;
    using Newtonsoft.Json;

    public class LoginWebRequest
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
