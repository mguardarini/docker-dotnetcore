using Newtonsoft.Json;

namespace TodoService.Models
{
    public class TodoModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("checked")]
        public bool Checked { get; set; }
    }
}
