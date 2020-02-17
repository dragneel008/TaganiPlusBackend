namespace Entities.DTOs.WebResponses
{
    using Newtonsoft.Json;

    public class ProvincesWebResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
