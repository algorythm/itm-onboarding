using Microsoft.AspNetCore.Identity;

namespace todoProject.Data.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; } = false;
        public string OwnerId { get; set; }
        public virtual IdentityUser Owner { get; set; }
    }
}