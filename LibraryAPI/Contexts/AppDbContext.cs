using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookAuthorEntity> BookAuthors { get; set; }
        public DbSet<StatusHistoryEntity> StatusHistories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookEntity>().ToTable("Books");
            builder.Entity<BookEntity>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).IsRequired();
                entity.Property(p => p.Title);
                entity.HasOne(p => p.CurrentStatus).WithOne(p => p.Book).HasForeignKey<StatusHistoryEntity>(p => p.BookId);
                entity.Property(p => p.Language).HasMaxLength(50);
                entity.Property(p => p.PublicationDate).HasMaxLength(7);
                entity.Property(p => p.Genre).HasConversion<string>();
                entity.Property(p => p.PageNumber);
                entity.HasOne(p => p.BookAuthor).WithOne(p => p.Book).HasForeignKey<BookAuthorEntity>(p => p.BookId);
            });

            builder.Entity<AuthorEntity>().ToTable("Authors");
            builder.Entity<AuthorEntity>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).IsRequired();
                entity.Property(p => p.FirstName);
                entity.Property(p => p.LastName);
                entity.Property(p => p.DateOfBirth).HasMaxLength(7);
                entity.HasMany(p => p.BookAuthors).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId);
            });
            
            builder.Entity<BookAuthorEntity>().ToTable("BookAuthors");
            builder.Entity<BookAuthorEntity>(entity =>
            {
                entity.HasKey(p => new { p.BookId, p.AuthorId });
                entity.HasOne(p => p.Author).WithMany(p => p.BookAuthors);
                entity.HasOne(p => p.Book).WithOne(p => p.BookAuthor);
            });
            

            builder.Entity<StatusHistoryEntity>().ToTable("StatusHistory");
            builder.Entity<StatusHistoryEntity>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).IsRequired();
                entity.Property(p => p.ModifiedDate).IsRequired().HasMaxLength(7);
                entity.Property(p => p.Status).HasConversion<string>().IsRequired();
                entity.HasOne(p => p.Book).WithOne(p => p.CurrentStatus).HasForeignKey<BookEntity>(p => p.CurrentStatusId);
            });
            
        }
    }
}
