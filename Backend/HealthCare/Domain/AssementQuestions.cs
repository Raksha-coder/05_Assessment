using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AssementQuestions
    {
      public int Id { get; set; }

      public bool isActive { get; set; }

      public string Questions { get; set; }

      public string Response_Type { get; set; }

      public bool isRequired { get; set; }

        //
      public int AssessmentId { get; set; }

      public Assessment Assessment { get; set; }

        //

     public QuestionResponses QuestionResponses { get; set; }
        //one question => one response (Answer)

        public ICollection<PatientToAssessmentDetails> Details { get; set; } = null!;

    }
}
