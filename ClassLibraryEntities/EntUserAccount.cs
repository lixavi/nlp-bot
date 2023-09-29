using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class EntUserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Role { get; set; } = "University";
        public string? InstituteId { get; set; }

    }
}
