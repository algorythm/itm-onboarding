using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoProject.Data;
using todoProject.Data.Models;

namespace todoProject.Services.TodoServices
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationDbContext _context;

        public TodoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoListDto> CreateTodoAsync(TodoListDto todo)
        {
            var todoToCreate = new Todo
            {
                Title = todo.Title,
                Done = todo.Completed
            };

            await _context.AddAsync(todoToCreate);
            await _context.SaveChangesAsync();

            return new TodoListDto
            {
                Id = todoToCreate.Id,
                Title = todoToCreate.Title,
                Completed = todoToCreate.Done
            };
        }

        public async Task<TodoListDto[]> GetAllTodosAsync()
        {
            return await _context.Todos
                .Select(t => new TodoListDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Completed = t.Done
                })
                .ToArrayAsync();
        }

        public async Task<TodoListDto> GetById(int id)
        {
            return await _context.Todos
                .Select(t => new TodoListDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Completed = t.Done
                })
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}