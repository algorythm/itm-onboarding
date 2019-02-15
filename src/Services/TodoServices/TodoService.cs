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

            todoToCreate.Priority = todoToCreate.Id * 1000;

            await _context.SaveChangesAsync();

            return _mapper.Map<TodoListDto>(todoToCreate);
        }

        public async Task<TodoListDto[]> GetAllTodosAsync()
        {
            var todos = await _context.Todos
                .Where(t => t.OwnerId == _userResolver.CurrentUserId)
                .OrderBy(t => t.Priority)
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

        public async Task MoveTodoAsync(MoveTodoDto move)
        {
            var currentTodos = _mapper.Map<Todo[]>(await GetAllTodosAsync());
            var currentTodoToMove = await _context.Todos.FindAsync(move.element.Id);

            if (move.element.Id != currentTodos[move.oldIndex].Id)
            {
                // The order has changed during the move and this request
                return;
            }
            if (currentTodos.Length == 0 || currentTodos.Length == 1)
            {
                return;
            }
            if (currentTodoToMove == null)
            {
                return;
            }

            // Todo todoAfterNewPosition = null;
            // Todo todoBeforeNewPosition = null;
            
            if (move.newIndex == 0) 
            {
                var todoAfterNewPosition = currentTodos[1];
                currentTodoToMove.Priority = todoAfterNewPosition.Priority / 2;
            }
            else if (move.newIndex == currentTodos.Length + 1)
            {
                var todoBeforeNewPosition = currentTodos[move.newIndex - 1];
                currentTodoToMove.Priority = todoBeforeNewPosition.Priority + 1000;
            }
            else
            {
                Todo todoBeforeNewPosition = null;
                Todo todoAfterNewPosition  = null;

                if (move.newIndex > move.oldIndex)
                {
                    todoBeforeNewPosition = currentTodos[move.newIndex];
                    todoAfterNewPosition = currentTodos[move.newIndex + 1];
                }
                else
                {
                    todoBeforeNewPosition = currentTodos[move.newIndex - 1];
                    todoAfterNewPosition = currentTodos[move.newIndex];
                }

                var priorityToAdd = (todoAfterNewPosition.Priority - todoBeforeNewPosition.Priority) / 2;

                if (priorityToAdd == 0)
                {
                    priorityToAdd = 100;
                }

                currentTodoToMove.Priority = todoBeforeNewPosition.Priority + priorityToAdd;
            }

            await _context.SaveChangesAsync();
        }
    }
}