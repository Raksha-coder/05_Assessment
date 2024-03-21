using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_Layer
{
    public class AssementQuestionsdto
    {
        

        public string Questions { get; set; }

        public string Response_Type { get; set; }

        public bool isRequired { get; set; }

        //fk
        public int AssessmentId { get; set; }

    }
}
