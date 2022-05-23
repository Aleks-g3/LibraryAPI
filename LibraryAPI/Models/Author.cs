using System;

namespace LibraryAPI.Models
{
    public class Author
    {
        /// <summary>
        /// First name and last name separated with space
        /// </summary>
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static Author Create(AuthorEntity author) =>
            new Author()
            {
                Name = $"{author.FirstName} {author.LastName}",
                DateOfBirth = author.DateOfBirth ?? DateTime.MinValue
            };
    }
}
