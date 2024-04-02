using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_Layer
{
    public class AssessmentByIdDto
    {

        public int Id { get; set; }

        public bool isActive { get; set; }
        public string Name { get; set; }

        public int isScorable { get; set; }

        public IList<AssementQuestionsDto> AssementsQue { get; set; }
    }

    public class AssementQuestionsDto
    {
        public int Id { get; set; }

        public bool isActive { get; set; }

        public string Questions { get; set; }

        public string Response_Type { get; set; }

        public bool isRequired { get; set; }
    }

}
