using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PatientToAssessment
    {
        public int Id { get; set; }

        //fk of patient
        public int PatientId { get; set; }
        public Patient Patients { get; set; } = null!;

        //assessment
        public int AssessmentId { get; set; }
        public Assessment Assessment { get; set; } = null!;

        public DateTime Assessment_Date { get; set; }

        //
        public ICollection<PatientToAssessmentDetails> Details { get; set; }

    }
}
