using Application.Responses;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.PatientCQ.Command
{
    public class PostPatient : IRequest<CommonResponse<Patient>>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DOB { get; set; }
    }

    public class PostPatientHandler : IRequestHandler<PostPatient, CommonResponse<Patient>>
    {
        public readonly IHealthDbContext _context;
        public PostPatientHandler(IHealthDbContext context)
        {
            _context = context;
        }


        public async Task<CommonResponse<Patient>> Handle(PostPatient request, CancellationToken cancellationToken)
        {
            try
            {
                var newPatient = new Patient()
                {
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    DOB = request.DOB,
                };

                 _context.PatientTable.Add(newPatient);
                await _context.SaveChangesAsync();


                return new CommonResponse<Patient>()
                {
                    Status = 200,
                    Message = "Successfully added",
                    Response = new List<Patient> { newPatient },
                    Error = null
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

