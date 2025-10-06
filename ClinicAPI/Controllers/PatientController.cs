using APILayer.DTOs___Validations;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static BusinessLayer.Patient;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {


        readonly PatientServices _service;
        private readonly PersonServices _personServices;

        public PatientController(PatientServices service,PersonServices personServices)
        {
            _service = service;
            _personServices = personServices;
        }

        /// <summary>
        /// Add a new patient.
        /// </summary>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddNewPatient( [FromBody] PatientRequestDTO patient)
        {

            if (patient.PatientPersonID<= 0)
            {
                var creationUrl = Url.Action("AddPerson", "Person", null, Request.Scheme);


                return BadRequest(new
                {
                    Message = "PersonID is missing. Please create an Person.",
                    CreateTypeUrl = creationUrl
                });
            }
            { var result =await _service.AddNewPatient(patient);

                return result.Status switch
                {
                    ResultStatus.Success => CreatedAtAction(nameof(GetPatientById), new { patientId = result.Data }, result.Data),
                    ResultStatus.Conflict => Conflict(result.Message),
                    ResultStatus.InternalError => StatusCode(500, result.Message),
                    _ => BadRequest(result.Message)
                };
            }
           
        }

        /// <summary>
        /// Update an existing patient.
        /// </summary>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePatient([FromBody] PatientRequestDTO patient)
        {
            var result =await _service.UpdatePatient(patient);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Delete a patient by ID.
        /// </summary>
        [HttpDelete("by{patientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletePatient(int patientId)
        {
            var result =await _service.DeleteByPatientID(patientId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get patient by ID.
        /// </summary>
        [HttpGet("{patientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Patient>> GetPatientById(int patientId)
        {
            var result =await _service.FindByPatientID(patientId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get patient by UserId.
        /// </summary>
        [HttpGet("by{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Patient>> GetPatientByUserId(int userId)
        {
            var result = await _service.FindPatientByUserID(userId);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get patient by UserName.
        /// </summary>
        [HttpGet("by{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Patient>> GetPatientByUserName(string username)
        {
            var result =await _service.FindPatientByUserName(username);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        /// <summary>
        /// Get all patients.
        /// </summary>
        //[HttpGet("all")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<List<Patient>> GetAllPatients()
        //{
        //    var result = _service.GetAllPatients();

        //    return result.Status switch
        //    {
        //        ResultStatus.Success => Ok(result.Data),
        //        ResultStatus.NotFound => NoContent(),
        //        ResultStatus.InternalError => StatusCode(500, result.Message),
        //        _ => BadRequest(result.Message)
        //    };
        //}
    } 
}
