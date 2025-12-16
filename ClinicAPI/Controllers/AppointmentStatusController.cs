using BusinessLayer.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentStatusController : ControllerBase
    {
        private readonly AppointmentStatusServices _service;

        public AppointmentStatusController(AppointmentStatusServices service)
        {
            _service = service;
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddAppointmentStatus([FromBody] AppointmentStatusRequestDTOs dto)
        {
            var result = await _service.AddAppointmentStatus(dto);

            return result.Status switch
            {
                ResultStatus.Success => Created(nameof(GetAppointmentstatusByID), result.Data),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateAppointmentStatus([FromBody] AppointmentStatusRequestDTOs dto)
        {
            var result = await _service.UpdateAppointmentStatus(dto);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAppointmentStatus(int id)
        {
            var result = await _service.DeleteAppointmentStatus(id);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AppointmentStatus>> GetAppointmentstatusByID(int id)
        {
            var result = await _service.GetAppointmentStatusById(id);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<AppointmentStatus>>> GetAllStatuses()
        {
            var result = await _service.GetAllAppointmentStatuses();

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.Conflict => Conflict(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }
    }
}
