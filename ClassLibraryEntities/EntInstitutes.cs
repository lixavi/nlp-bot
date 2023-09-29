using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class EntInstitutes
    {
        public string? Role { get; set; } = "University";
        public string? InstituteId { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Logo { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? CreatedOn { get; set; }
        public string? IsActive { get; set; }
        public string? CityId { get; set; }
        public string? TypeOfId { get; set; }
        public string? Location { get; set; }
        public string? AdminId { get; set; }
        public bool? admission_open_close { get; set; }

    }
}
