namespace Library_Management_API.Models
{
    public class BorrowedBookDetails
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string BookStatus { get; set; }
        public string MemberName { get; set; }
    }
}
