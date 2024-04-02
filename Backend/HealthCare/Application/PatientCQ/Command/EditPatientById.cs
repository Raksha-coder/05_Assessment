using Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.PatientCQ.Command
{
    public class EditPatientById:IRequest<GlobalResponse>
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DOB { get; set; }
    }
    public class EditPatientByIdHandler : IRequestHandler<EditPatientById, GlobalResponse>
    {
        public readonly IHealthDbContext _context;
        public EditPatientByIdHandler(IHealthDbContext context)
        {
            _context = context;
        }

        public async Task<GlobalResponse> Handle(EditPatientById request, CancellationToken cancellationToken)
        {
            try
            {
                var patientExistOrNot = await _context.PatientTable.Where(p => p.Id == request.Id).FirstOrDefaultAsync();

                if (patientExistOrNot == null)
                {
                    return new GlobalResponse()
                    {
                        Status = 400,
                        Message = "Patient not found",
                        Error = "Patient not found with the specified ID"
                    };

                }
                else
                {
                    patientExistOrNot.Firstname = request.Firstname;
                    patientExistOrNot.Lastname = request.Lastname;
                    patientExistOrNot.DOB = request.DOB;

                    await _context.SaveChangesAsync();

                    return new GlobalResponse()
                    {
                        Status = 200,
                        Message = "Sucessfully updated patient",
                        Error = null!
                    };


                }
            }
            catch(Exception ex)
            {

                return new GlobalResponse()
                {
                    Status = 400,
                    Message = "Error found",
                    Error = ex.Message
                };
            }
           
        }
    }

}
