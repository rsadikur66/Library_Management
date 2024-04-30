using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Library_Web_Front.Models
{
    public class BorrowedBookViewModel
    {

        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        [Display(Name = "Borrow Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BorrowDate { get; set; }
        [Display(Name = "Return Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReturnDate { get; set; }
        public string BookStatus { get; set; }
        public string MemberName { get; set; }
    }
}
