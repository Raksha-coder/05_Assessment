using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DOB { get; set; }

        //
        public ICollection<PatientToAssessment> Patient_Assessment { get; set; }


    }
}
