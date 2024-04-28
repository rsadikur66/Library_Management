namespace Library_Web_Front.Models
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } 
        public string AuthorBio { get; set; } 

        public IEnumerable<AuthorViewModel> authorList { get; set;}
    }
}
