using System;
using System.Collections.Generic;

namespace Library_Management_API.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public string AuthorBio { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
