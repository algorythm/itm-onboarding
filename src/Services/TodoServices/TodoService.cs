using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using todoProject.Data;
using todoProject.Data.Models;

namespace todoProject.Services.TodoServices
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserResolver _userResolver;

        public TodoService(ApplicationDbContext context, IMapper mapper, IUserResolver userResolver)
        {
            _context = context;
            _mapper = mapper;
            _userResolver = userResolver;
        }

        public async Task<TodoListDto> CreateTodoAsync(TodoListDto todo)
        {
            var todoToCreate = _mapper.Map<Todo>(todo);
            todoToCreate.OwnerId = _userResolver.CurrentUserId;

            await _context.AddAsync(todoToCreate);
            await _context.SaveChangesAsync();

            return _mapper.Map<TodoListDto>(todoToCreate);
        }

        public async Task<TodoListDto[]> GetAllTodosAsync()
        {
            var todos = await _context.Todos
                .Where(t => t.OwnerId == _userResolver.CurrentUserId)
                .ToArrayAsync();
            
            return _mapper.Map<TodoListDto[]>(todos);
        }

        public async Task<TodoListDto> GetById(int id)
        {
            var currentUser = await _userResolver.GetCurrentUserAsync();
            var todo = await _context.Todos
                .FindAsync(id);
            
            if (todo.OwnerId != currentUser.Id) return null;
            
            return _mapper.Map<TodoListDto>(todo);
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null) return;
            if (todo.OwnerId != _userResolver.CurrentUserId) return;

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoListDto> UpdateTodoAsync(TodoListDto updatedTodo)
        {
            var originalTodo = await _context.Todos.FindAsync(updatedTodo.Id);

            if (originalTodo == null) return null;
            if (originalTodo.Owner.Id != _userResolver.CurrentUserId) return null;

            originalTodo.Title = updatedTodo.Title;
            originalTodo.Done  = updatedTodo.Completed;
            originalTodo.DateExpired = updatedTodo.DateExpired;

            await _context.SaveChangesAsync();

            return _mapper.Map<TodoListDto>(originalTodo);
        }
    }
}