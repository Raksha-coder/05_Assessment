using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    //this is the response table
    public class PatientToAssessmentDetails
    {
        public int Id { get; set; }

        //
        public int Patient_Assessment_Id { get; set; }
        public PatientToAssessment PatientToAssessment { get; set; } = null!;

        //
        public int Question_Id { get; set; }
        public AssementQuestions AssessmentQuestion { get; set; } = null!;


        public string? Response { get; set; }
    }
}
