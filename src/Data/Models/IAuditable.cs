using System;

namespace todoProject.Data.Models 
{
    public interface IAuditable
    {
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}