using BusinessLayer.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTypeController : ControllerBase
    {
        private readonly AppointmentTypeServices _service;

        public AppointmentTypeController(AppointmentTypeServices service)
        {
            _service = service;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAppointmentType([FromBody] AppointmentTypeDTO dto)
        {
            var result =await _service.AddAppointmentType(dto);

            return result.Status switch
            {
                ResultStatus.Success => CreatedAtAction(nameof(GetAppointmentTypeById), new { id = result.Data }, result.Data),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAppointmentType([FromBody] AppointmentTypeDTO dto)
        {
            var result =await _service.UpdateAppointmentType(dto);

            return result.Status switch
            {
                ResultStatus.Updated => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAppointmentType(int id)
        {
            var result =await _service.DeleteAppointmentType(id);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Message),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetAppointmentTypeById(int id)
        {
            var result =await _service.GetAppointmentTypeById(id);

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Data),
                ResultStatus.NotFound => NotFound(result.Message),
                ResultStatus.InternalError => StatusCode(500, result.Message),
                _ => BadRequest(result.Message)
            };
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllAppointmentTypes()
        {
            var result =await _service.GetAllAppointmentTypes();

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
