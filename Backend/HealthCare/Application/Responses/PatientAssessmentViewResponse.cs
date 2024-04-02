using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO_Layer;

namespace Application.Responses
{
    public class PatientAssessmentViewResponse
    {

        public int Status { get; set; }

        public string Message { get; set; }

        public  List<PatientAssessmentDTO> PatientAssessement {  get; set; }

        public List<AssessmentPatientGetDTO> PatientQuestionResponse { get; set; }
        public string Error { get; set; }
    }
}
