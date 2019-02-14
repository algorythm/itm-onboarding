using System;
using Microsoft.AspNetCore.Identity;

namespace todoProject.Data.Models
{
    public class Todo : IAuditable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; } = false;
        public string OwnerId { get; set; }
        public virtual IdentityUser Owner { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateExpired { get; set; }
    }
}