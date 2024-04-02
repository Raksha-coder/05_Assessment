using Application.DTO_Layer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Http;

namespace Application.PatientCQ.Query
{
    public class PatientAssessmentListByIdQuery:IRequest<Tuple<List<AssessmentPatientGetDTO>>>
    {
        public int Id {  get; set; }

        public int Patient_Assessment_Id { get; set; }
    }
    public class PatientAssessmentListByIdQueryHandler : IRequestHandler<PatientAssessmentListByIdQuery, Tuple<List<AssessmentPatientGetDTO>>>
    {
        public readonly IHealthDbContext _context;
        public PatientAssessmentListByIdQueryHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<Tuple<List<AssessmentPatientGetDTO>>> Handle(PatientAssessmentListByIdQuery request, CancellationToken cancellationToken)
        {
            //assessment name with all question with answer

            var _patientId = await  _context.PatientTable.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

            if(_patientId == null )
            {
                return null;
            }


            //var query = from t1 in _context.PatientTable
            //            join t2 in _context.PatientToAssessmentTable on t1.Id equals t2.PatientId
            //            join t3 in _context.AssessmentsTable on t2.AssessmentId equals t3.Id
            //            where t1.Id == _patientId.Id
            //            select new PatientAssessmentDTO
            //            {
            //                // Select the properties you need
            //                PatientFirstName = t1.Firstname,
            //                PatientLastName = t1.Lastname,
            //                AssessmentName = new List<ListOfAssessmentNameDTO> { 
            //                    new ListOfAssessmentNameDTO { 
            //                        Id = t3.Id,
            //                        Name = t3.Name,
            //                        CreatedAt = t2.Assessment_Date,
            //                    } 
            //                }
            //            };



            var query2 = from t1 in _context.PatientToAssessmentTable
                         join t2 in _context.PatientToAssessmentDetailsTable on t1.Id equals t2.Patient_Assessment_Id
                         join t3 in _context.AssementQuestionsTable on t2.Question_Id equals t3.Id
                         where t1.PatientId == _patientId.Id && t1.Id ==  request.Patient_Assessment_Id
                         select new AssessmentPatientGetDTO
                         {
                             Question = new List<AssessmentDTO> { 
                                 new AssessmentDTO {
                                     AssessmentId = t3.AssessmentId,
                                     Questionss = t3.Questions 
                                 } 
                             },

                             Response = new List<ResponseDTO> {
                                 new ResponseDTO { Responsess = t2.Response } 
                             }
                         };

             
            return Tuple.Create(query2.ToList());




        }
    }

}
