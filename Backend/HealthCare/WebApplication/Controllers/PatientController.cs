using Application.PatientCQ.Command;
using Application.PatientCQ.Query;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication.Controllers
{
    public class PatientController : ApiController
    {


        [HttpPost("addPatient")]

        public async Task<IActionResult> PostCart([FromBody] PostPatient patient)
        {
            var response = await Mediator.Send(patient);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }


        }



        [HttpPost("PatientToAssessment")]

        public async Task<IActionResult> PostPatientAssessment([FromBody] PostPatientToAssessmentCommand patient)
        {
            var response = await Mediator.Send(patient);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }


        }





        [HttpGet("Patients")]

        public async Task<IActionResult> GetAllPatients()
        {
            var patient = await Mediator.Send(new GetPatients());

            if (patient != null)
            {
                return Ok(patient);
            }
            else
            {
                return BadRequest(patient);
            }
        }


        [HttpGet("Patient/id")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var patient = await Mediator.Send(new GetPatientByIdQuery { Id = id });

            if (patient.Status == 200)
            {
                return Ok(patient);
            }
            else
            {
                return BadRequest(patient);
            }
        }


        [HttpPut("id")]

        public async Task<IActionResult> Update([FromBody] EditPatientById command)
        {
            var patient = await Mediator.Send(command);

            if (patient.Status == 200)
            {
                return Ok(patient);
            }
            else
            {
                return BadRequest(patient);
            }
        }



        //view 


        [HttpPost("PatientAssessmentView")]
        public async Task<IActionResult> ViewAssessmentById([FromBody] PatientAssessmentListByIdQuery command )
        {
            var patient = await Mediator.Send(command);

            if (patient == null)
            {
                var result = new PatientAssessmentViewResponse()
                {
                   Status = 400,
                   Message = "Patient Not Found",
                   PatientQuestionResponse = null,
                   Error = null
                };
                return BadRequest(result);
            }
            else
            {
                var result = new PatientAssessmentViewResponse()
                {
                    Status = 200,
                    Message = "Successful",
                    PatientQuestionResponse = patient.Item1,
                    Error = null
                };
                return Ok(result);
            }
         
            
         
        }





        //
        [HttpGet("PatientAssessmentView/id")]
        public async Task<IActionResult> ViewAssessmentById(int _id)
        {
            var patient = await Mediator.Send(new PatientAssessmentListById { Id = _id});

            if (patient == null)
            {
                var result = new PatientAssessmentViewResponse()
                {
                    Status = 400,
                    Message = "Patient Not Found",
                    PatientAssessement = null,
                    Error = null
                };
                return BadRequest(result);
            }
            else
            {
                var result = new PatientAssessmentViewResponse()
                {
                    Status = 200,
                    Message = "Successful",
                    PatientAssessement = patient.Item1,
                    Error = null
                };
                return Ok(result);
            }



        }




    }
}
