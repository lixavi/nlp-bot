using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntities
{
    public class EntEducationalInfo
    {
        public string? SID { set; get; }
       
        public string? PassingDSGroup { get; set; }

        public string? Board_University { get; set; }
        public string? ObtainedMarks { get; set; }
        public string? TotalMarks { get; set; }
        public string? Percentage { get; set; }
        public string? PassingYear { get; set; }
        public string? Institute { get; set; }

    }
}
