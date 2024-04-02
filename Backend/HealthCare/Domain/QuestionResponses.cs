using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class QuestionResponses
    {
        public int Id { get; set; } //pk

        public int QuestionId { get; set; }  //fk
        public AssementQuestions AssessmentQuestion { get; set; } = null!;

        public string? Responses { get; set; }
    }
}
