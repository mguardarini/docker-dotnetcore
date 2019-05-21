using Newtonsoft.Json;

namespace TodoService.Models
{
    public class TodoModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("checked")]
        public bool Checked { get; set; }
    }
}
