using Microsoft.AspNetCore.Mvc;
using TodoService.Models;

namespace TodoService.Controllers
{
   
    [Route("api/[controller]")]
    public class TodoController
    {

        public TodoController()
        {
        }

        [HttpPost]
        public TodoModel Post([FromBody]TodoModel model)
        {
            return new TodoModel
            {
                Checked = model.Checked,
                Id = model.Id,
                Description = model.Description
            };
        }

        [HttpGet("{id}")]
        public TodoModel Get()
        {
            return new TodoModel
            {
                Checked = false,
                Id = "1234",
                Description = "Mauro"
            };
        }
    }
}