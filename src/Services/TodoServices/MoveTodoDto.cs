using System.ComponentModel.DataAnnotations;
using todoProject.Services.TodoServices;

namespace todoProject
{
    public class MoveTodoDto
    {
        [Required]
        public int newIndex { get; set; }
        [Required]
        public int oldIndex { get; set; }
        [Required]
        public TodoListDto element { get; set; }
    }
}