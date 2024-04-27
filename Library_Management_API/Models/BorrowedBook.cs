using System;
using System.Collections.Generic;

namespace Library_Management_API.Models
{
    public partial class BorrowedBook
    {
        public int BorrowId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; } = null!;
        public int? MemberId { get; set; }
        public int? BookId { get; set; }

        public virtual Book? Book { get; set; }
        public virtual Member? Member { get; set; }
    }
}
