using BusinessLayer.BusinessLogic;
using BusinessLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLayer.DTOsForPresentationLayer;
using ClinicAPI.temp.DTOs___Validations;
using System.Numerics;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly NurseServices _service;
        private readonly EmployeeServices _employeeservice;

        public NurseController(NurseServices service, EmployeeServices employeeservice)
        {
            _service = service;
            _employeeservice = employeeservice;
        }

        /// <summary>
        /// Add a new nurse.
        /// </summary>
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddNurse( [FromBody] NurseRequestDTO nurse)
        {
            if (nurse.Employee_ID_FK<= 0)
            {
                var creationUrl = Url.Action("AddEmployee", "Employee", null, Request.Scheme);


                return BadRequest(new
                {
                    Message = "nurse.EmployeeID is missing. Please create an Employee .",
                    CreateTypeUrl = creationUrl
                });
            }

            var result = await _service.AddNewNurse(nurse);

            return result.Status switch
            {
                ResultStatus.Success => CreatedAtAction(nameof(GetNurseById), new { nurseId = result.Data }, result.Data),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

    
        

        /// <summary>
        /// Update an existing nurse.
        /// </summary>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateNurse([FromBody] NurseRequestDTO nurse)
        {
            var result =await _service.UpdateNurse(nurse);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Delete a nurse by ID.
        /// </summary>
        [HttpDelete("by{nurseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteNurse(int nurseId)
        {
            var result =await _service.DeleteNurse(nurseId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get nurse by ID.
        /// </summary>
        [HttpGet("by{nurseId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Nurse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Nurse>> GetNurseById(int nurseId)
        {
            var result =await _service.GetNurseById(nurseId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }
    }
}
