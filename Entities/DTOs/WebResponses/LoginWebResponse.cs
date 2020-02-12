namespace Entities.WebResponses
{
    using Newtonsoft.Json;

    public class LoginWebResponse
    {

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
