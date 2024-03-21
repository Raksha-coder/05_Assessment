using Application.DTO_Layer;
using Application.Responses;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AssessmentCQ.Command
{
    public class postAssessmentAlongwithQues:IRequest<GlobalResponse>
    {
        public Assessmentdto? AssDto { get; set; }

        public List<AssementQuestionsdto>? AssListQue { get; set; }
    }

    public class postAssessmentAlongwithQuesHandler:IRequestHandler<postAssessmentAlongwithQues,GlobalResponse>
    {
        public readonly IHealthDbContext _context;
        public postAssessmentAlongwithQuesHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<GlobalResponse> Handle(postAssessmentAlongwithQues request, CancellationToken cancellationToken)
        {
            try
            {
                var _find =    await  _context.AssessmentsTable.Where(a => a.Id == request.AssDto.UpdateId).FirstOrDefaultAsync();


                if (_find != null)
                {
                    _find.isActive = true;
                    _find.Name = request.AssDto.Name;
                    _find.isScorable = request.AssDto.isScorable;
                    _find.AssementsQue = new List<AssementQuestions>();

                    foreach (var questionDto in request.AssListQue)
                    {
                        _find.AssementsQue.Add(new AssementQuestions
                        {
                            isActive = true,
                            Questions = questionDto.Questions,
                            Response_Type = questionDto.Response_Type,
                            isRequired = questionDto.isRequired,
                            AssessmentId = _find.Id
                        });
                    }
                }
                else
                {
                    var newAssessment = new Assessment()
                    {
                        isActive = true,
                        Name = request.AssDto.Name,
                        isScorable = request.AssDto.isScorable,
                        AssementsQue = new List<AssementQuestions>(),
                    };


                    foreach (var questionDto in request.AssListQue)
                    {
                        newAssessment.AssementsQue.Add(new AssementQuestions
                        {
                            isActive = true,
                            Questions = questionDto.Questions,
                            Response_Type = questionDto.Response_Type,
                            isRequired = questionDto.isRequired,
                            AssessmentId = newAssessment.Id

                        });
                    }

                    _context.AssessmentsTable.Add(newAssessment);
                }

                await _context.SaveChangesAsync();

                return new GlobalResponse()
                {

                    Status = 200,
                    Message = "Successfully added",
                    Error = null
                };


            }
            catch(Exception ex)
            {
                return new GlobalResponse()
                {

                    Status = 400,
                    Message = "error occurred",
                    Error = ex.Message
                };
            }
        }
    }

}
