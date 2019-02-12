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

        [HttpPost]
        public async Task<IActionResult> CreateTodoAsync([FromBody] TodoListDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The given model is incorrectly formatted.");
            }

            var todo = await _todoService.CreateTodoAsync(dto);

            if (todo == null)
            {
                return BadRequest("Todo could not be created.");
            }

            return CreatedAtRoute("GetTodoById", new { id = todo.Id }, todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> CompleteTodo(int id)
        {
            var todo = await _todoService.GetById(id);

            if (todo == null) 
            {
                return NotFound();
            }

            todo.Completed = true;

            var updatedTodo = await _todoService.UpdateTodoAsync(todo);

            return Ok(updatedTodo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoAsync(int id, [FromBody] TodoListDto todo)
        {
            var originalTodo = await _todoService.GetById(id);

            if (originalTodo == null)
            {
                return NotFound();
            }

            if (id != todo.Id)
            {
                return BadRequest($"The given id does not match the id of the given todo ({id} != {todo.Id}).");
            }

            var updatedTodo = await _todoService.UpdateTodoAsync(todo);
            
            return Ok(updatedTodo);
        }
    }
}