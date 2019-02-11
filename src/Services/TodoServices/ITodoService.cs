using System.Threading.Tasks;
using todoProject.Data.Models;

namespace todoProject.Services.TodoServices
{
    public interface ITodoService
    {
        Task<TodoListDto[]> GetAllTodosAsync();
        Task<TodoListDto> GetById(int id);
        Task<TodoListDto> CreateTodoAsync(TodoListDto todo);
    }
}