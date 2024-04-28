using Library_Management_API.Models;

namespace Library_Web_Front.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; } = null!;
        public int AvailableCopies { get; set; }
        public string? Isbn { get; set; }
        public int TotalCopies { get; set; }
        public int? AuthorId { get; set; }

        //public virtual Author? Author { get; set; }
        //public virtual ICollection<BorrowedBook> BorrowedBooks { get; set; }
    }
}
