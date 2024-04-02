using Application.AssessmentCQ.Command;
using Application.AssessmentCQ.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AssessmentController : ApiController
    {
        [HttpGet("Assessmentnames")]
        public async Task<IActionResult> GetAssessmentNames()
        {
            var _assessmentNames = await Mediator.Send(new getAssessmentName());

            if (_assessmentNames.Status == 200)
            {
                return Ok(_assessmentNames);
            }
            else
            {
                return BadRequest(_assessmentNames);
            }
        }


        //


        [HttpGet("AssessmentnamesById")]
        public async Task<IActionResult> GetAssessmentsById(int id)
        {
            var _assessment = await Mediator.Send(new getAssessmentsAlongWithQuestion { Id = id });

            if (_assessment.Status == 200)
            {
                return Ok(_assessment);
            }
            else
            {
                return BadRequest(_assessment);
            }
        }



        [HttpPost("AssismentQuestions")]

        public async Task<IActionResult> PostCart([FromBody] postAssessmentAlongwithQues AssQuestion)
        {
            var Value = await Mediator.Send(AssQuestion);

            if (Value.Status == 200)
            {
                return Ok(Value);
            }
            else
            {
                return BadRequest(Value);
            }


        }

    }
}
