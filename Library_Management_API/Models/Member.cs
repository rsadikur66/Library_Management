using System;
using System.Collections.Generic;

namespace Library_Management_API.Models
{
    public partial class Member
    {
        public Member()
        {
            BorrowedBooks = new HashSet<BorrowedBook>();
        }

        public int MemberId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<BorrowedBook> BorrowedBooks { get; set; }
    }
}
