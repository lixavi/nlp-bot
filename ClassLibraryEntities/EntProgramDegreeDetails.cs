using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class EntProgramDegreeDetails
    {
        public string? ProgramDegreeDetailsId { get; set; }
        public string? Duration { get; set; }
        public string? DegreeName { get; set; }
        public string? Programs { get; set; }
        public string? Matric { get; set; }
        public string? FSC { get; set; }
        public string? BS { get; set; }
        public string? TotalSemesters { get; set; }
        public string? TotalFee { get; set; }
        public string? SemesterFee { get; set; }
        public string? ClosingMerit { get; set; }
        public string? ApprovedById { get; set; }
        public bool Morning { get; set; } 
        public bool Evening { get; set; } 
        public bool Weekened { get; set; } 
        public string? CityId { get; set;}

        public string? PassingDegreeGroups { get; set; }
        public string? ProgramDegreeId { get; set; }
        public string? InstituteId { get; set; }
        public string? type { get; set; }
       


    }
}