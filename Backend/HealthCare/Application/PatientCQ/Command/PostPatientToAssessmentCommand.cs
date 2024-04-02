using Application.DTO_Layer;
using Application.Responses;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PatientCQ.Command
{
    public class PostPatientToAssessmentCommand:IRequest<CommonResponse<Patient>>
    {
        public int PatientId { get; set; }
     
        public int AssessmentId { get; set; }

        public List<PatientAssementQuestionsDTO>? AssListQue { get; set; }

    }

    public class PostPatientToAssessmentCommandHandler : IRequestHandler<PostPatientToAssessmentCommand, CommonResponse<Patient>>
    {
        public readonly IHealthDbContext _context;
        public PostPatientToAssessmentCommandHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<CommonResponse<Patient>> Handle(PostPatientToAssessmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newAssessment = new PatientToAssessment()
                {
                    PatientId = request.PatientId,
                    AssessmentId = request.AssessmentId,
                    Assessment_Date = DateTime.Now,
                    Details = new List<PatientToAssessmentDetails>()
                };


                //list of questionid and response
                foreach (var question in request.AssListQue)
                {
                    newAssessment.Details.Add(new PatientToAssessmentDetails
                    {
                        Patient_Assessment_Id = newAssessment.Id,
                        Question_Id = question.Question_Id,
                        Response = question.Response,

                    });
                };

                _context.PatientToAssessmentTable.Add(newAssessment);
                await _context.SaveChangesAsync();



                return new CommonResponse<Patient>()
                {
                    Status = 200,
                    Message = "Successfully added",
                    Response = null!,
                    Error = null!
                };
            }
            catch(Exception ex)
            {
                return new CommonResponse<Patient>()
                {
                    Status = 400,
                    Message = "Error Occured",
                    Response = null!,
                    Error = ex.Message
                };
            }
          
        }
    }
}
