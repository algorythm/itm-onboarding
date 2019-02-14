using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoProject.Data.Models;

namespace todoProject.Data.EfConfigurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired();
            builder.HasOne(t => t.Owner).WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(t => t.OwnerId)
                .IsRequired();
            builder.Property(t => t.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(t => t.DateModified).HasDefaultValueSql(null);
            builder.Property(t => t.DateExpired).HasDefaultValueSql(null);
        }
    }
}