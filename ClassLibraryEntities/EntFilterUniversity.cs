using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class EntFilterUniversity
    {
        public string? Title { get; set; }
        public string? ProgramDegreeId { get; set; }
        public string? InstituteId{ get; set; }
        public string? DegreeName { get; set; }
        public string? PassingDegreeGroups { get; set; }
        public string? CityId { get; set; }
        public string? CityName { get; set; }
        public string? Departments { get; set; }
        public  string? percentage { get; set; }
        public string? logo { get; set; }
        public bool? admission_Open_Close { get; set; }

    }
}
