using System.ComponentModel.DataAnnotations;

namespace todoProject.Services.TodoServices
{
    public class TodoListDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}