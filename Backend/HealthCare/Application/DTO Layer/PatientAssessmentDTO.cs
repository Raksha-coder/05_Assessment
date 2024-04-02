using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_Layer
{
    public class PatientAssessmentDTO
    {
        public string? PatientFirstName { get; set; }
        public string? PatientLastName { get; set; }


        public List<ListOfAssessmentNameDTO> AssessmentName { get; set; }
    }


    public class ListOfAssessmentNameDTO
    {
        public int Id { get; set; }

        public int AssessmentId { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
