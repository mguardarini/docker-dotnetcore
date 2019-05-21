using System;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;
using TodoService.Controllers;
using Shouldly;
using System.Text;
using TodoService.Models;

namespace TodoService.IntegrationTests
{
    public class TodoEndpointTests
    {
        private string _endpoint = "/api/todo";
        private string _url;

        public TodoEndpointTests()
        {
            _url = Environment.GetEnvironmentVariable("API_URL") + _endpoint;
        }
        
        [Fact]
        public async void should_add_a_post()
        {
            var todo = new TodoModel{ Checked = false, Text = "Test Text" };
            
            using(HttpClient client = new HttpClient())
            {
                var result = await client.PostAsync(_url, new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json"));
                var expectedModel = JsonConvert.DeserializeObject<TodoModel>(await result.Content.ReadAsStringAsync());

                var response = await client.GetAsync($"{_url}/{expectedModel.Id}");
                var actualModel = JsonConvert.DeserializeObject<TodoModel>(await result.Content.ReadAsStringAsync());

                actualModel.Id.ShouldBe(expectedModel.Id);
                actualModel.Text.ShouldBe(expectedModel.Text);
            }

        }
    }
}
