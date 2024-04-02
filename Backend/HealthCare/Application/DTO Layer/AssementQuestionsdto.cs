using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_Layer
{
    public class AssementQuestionsdto
    {

        //id ke hisab se hi edit hoga
        public int id { get; set; }
        public string Questions { get; set; }

        public string Response_Type { get; set; }

        public bool isRequired { get; set; }

        //fk
        public int AssessmentId { get; set; }


        //question answer
        public string? Responses { get; set; }

    }
}
