using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoProject.Services.TodoServices;

namespace todoProject.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodosAsync()
        {
            return Ok(await _todoService.GetAllTodosAsync());
        }

        [HttpGet("{id}", Name = "GetTodoById")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            return Ok(await _todoService.GetById(id));
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new TodoListDto { Id = 2, Title = "Create the final API", Completed = false});
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoAsync([FromBody] TodoListDto dto)
        {
            var todo = await _todoService.CreateTodoAsync(dto);

            if (todo == null)
            {
                return BadRequest("Todo could not be created.");
            }

            return CreatedAtRoute("GetTodoById", new { id = todo.Id }, todo);
        }
    }
}