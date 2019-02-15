using System;
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
        public double Priority { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateExpired { get; set; }
    }
}