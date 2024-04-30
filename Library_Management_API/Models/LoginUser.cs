using System;
using System.Collections.Generic;

namespace Library_Management_API.Models
{
    public partial class LoginUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string LoginPassword { get; set; } = null!;
    }
}
