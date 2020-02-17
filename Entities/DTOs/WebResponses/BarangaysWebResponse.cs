namespace Entities.DTOs.WebResponses
{
    using Newtonsoft.Json;

    public class BarangaysWebResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
