using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Contexts
{
    public class AppContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookAuthorEntity> BookAuthors { get; set; }
        public DbSet<StatusHistoryEntity> StatusHistories { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BookEntity>().ToTable("Books");
            builder.Entity<BookEntity>().HasKey(p => p.Id);
            builder.Entity<BookEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<BookEntity>().Property(p => p.Title);
            builder.Entity<BookEntity>().HasOne(p => p.CurrentStatus).WithOne(p => p.Book).HasForeignKey<StatusHistoryEntity>(p => p.BookId);
            builder.Entity<BookEntity>().Property(p => p.Language).HasMaxLength(50);
            builder.Entity<BookEntity>().Property(p => p.PublicationDate).HasMaxLength(7);
            builder.Entity<BookEntity>().Property(p => p.Genre);
            builder.Entity<BookEntity>().Property(p => p.PageNumber);
            builder.Entity<BookEntity>().HasOne(p => p.BookAuthor).WithOne(p => p.Book).HasForeignKey<BookAuthorEntity>(p => p.BookId);
            builder.Entity<BookEntity>().HasOne(p => p.StatusHistory).WithOne(p => p.Book).HasForeignKey<StatusHistoryEntity>(p => p.BookId);

            builder.Entity<AuthorEntity>().ToTable("Authors");
            builder.Entity<AuthorEntity>().HasKey(p => p.Id);
            builder.Entity<AuthorEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<AuthorEntity>().Property(p => p.FirstName);
            builder.Entity<AuthorEntity>().Property(p => p.LastName);
            builder.Entity<AuthorEntity>().Property(p => p.DateOfBirth).HasMaxLength(7);
            builder.Entity<AuthorEntity>().HasMany(p => p.BookAuthors).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId);

            builder.Entity<BookAuthorEntity>().ToTable("BookAuthors");

            builder.Entity<StatusHistoryEntity>().ToTable("StatusHistory");
            builder.Entity<StatusHistoryEntity>().HasKey(p => p.Id);
            builder.Entity<StatusHistoryEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<StatusHistoryEntity>().Property(p => p.ModifiedDate).IsRequired().HasMaxLength(7);
            builder.Entity<StatusHistoryEntity>().Property(p => p.Status).IsRequired();
        }
    }
}
