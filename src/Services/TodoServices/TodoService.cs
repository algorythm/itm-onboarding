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

        public TodoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoListDto> CreateTodoAsync(TodoListDto todo)
        {
            var todoToCreate = _mapper.Map<Todo>(todo);

            await _context.AddAsync(todoToCreate);
            await _context.SaveChangesAsync();

            return _mapper.Map<TodoListDto>(todoToCreate);
        }

        public async Task<TodoListDto[]> GetAllTodosAsync()
        {
            var todos = await _context.Todos
                .ToArrayAsync();
            
            return _mapper.Map<TodoListDto[]>(todos);
        }

        public async Task<TodoListDto> GetById(int id)
        {
            var todo = await _context.Todos
                .FindAsync(id);
            
            return _mapper.Map<TodoListDto>(todo);
        }
    }
}