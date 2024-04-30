using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Library_Web_Front.Models
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        [Display(Name = "Registration Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RegistrationDate { get; set; }
    }
}
