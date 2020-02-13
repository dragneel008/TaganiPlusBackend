namespace Entities.WebResponses
{
    using System;
    using Newtonsoft.Json;

    public class LoginWebResponse
    {

        [JsonProperty("userId")]
        public Guid Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
