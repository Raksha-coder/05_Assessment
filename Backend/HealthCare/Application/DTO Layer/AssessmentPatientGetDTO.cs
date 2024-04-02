using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_Layer
{
    public class AssessmentPatientGetDTO
    {
        public List<AssessmentDTO>  Question {get;set; }
        public List<ResponseDTO> Response { get; set; }

    }

    public class AssessmentDTO {
        
        public int AssessmentId { get; set; }
        public string? Questionss { get;set; }
    }

    public class ResponseDTO {

        public string? Responsess { get; set; }

    }

}
