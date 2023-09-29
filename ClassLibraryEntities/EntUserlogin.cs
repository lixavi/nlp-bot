using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class EntUserlogin
    {

        public string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? ContactNo { get; set; }
        public string? Role { get; set; } = "User";
        public string? City { get; set; }
        public string? Gender { get; set; }
    }
}
