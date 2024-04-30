using Library_Management_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Library_Web_Front.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Display(Name = "Published Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PublishedDate { get; set; }
        public string Title { get; set; } = null!;
        public int AvailableCopies { get; set; }
        public string? Isbn { get; set; }
        public int TotalCopies { get; set; }
        public int? AuthorId { get; set; }
        public int SelectedAuthorId { get; set; } // Property to hold selected author's ID

        public IEnumerable<AuthorViewModel> AuthorList { get; set; }

        //public virtual Author? Author { get; set; }
        //public virtual ICollection<BorrowedBook> BorrowedBooks { get; set; }
    }
}
